namespace SupermarketsChain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Entity;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using SupermarketsChain.MsSQL;
    using SupermarketsChain.MySQL;
    using SupermarketsChain.SQLite;
    using DataMigrations;
    using SupermarketsChain.Models.BindingModels.Reports;

    public partial class MainForm : Form
    {
        private MsSqlContext msSqlContext;
        private MySqlContext mySqlContext;
        private SQLiteAppContext sqliteContext;
        private BackgroundWorker mssqlToMySqlWorker;

        public MainForm()
        {
            InitializeComponent();
            this.msSqlContext = new MsSqlContext();
            this.mySqlContext = new MySqlContext();
            this.sqliteContext = new SQLiteAppContext();
            mssqlToMySqlWorker = new BackgroundWorker();
            this.monthCalendar1.MaxSelectionCount = 1;
            mssqlToMySqlWorker.DoWork += worker_DoMigrateDateFromMsSqlToMySql;
            mssqlToMySqlWorker.RunWorkerCompleted += mssqlToMySqlWorker_RunWorkerCompleted;

        }

        private void mssqlToMySqlWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.dataTransferBtn.IsAccessible = true;
        }

        private void dataTransferBtn_Click(object sender, EventArgs e)
        {

            this.dataTransferBtn.IsAccessible = false;

            switch (this.dataTransferComboBox.Text)
            {
                case "From Oracle to MsSql":
                    MessageBox.Show(this.dataTransferComboBox.Text);
                    break;
                case "From MsSql to MySql":
                    this.mssqlToMySqlWorker.RunWorkerAsync();
                    break;
                case "From Zip to MsSql":
                    MessageBox.Show(this.dataTransferComboBox.Text);
                    break;
                case "From XML to MsSql":
                    MessageBox.Show(this.dataTransferComboBox.Text);
                    break;
                case "From JSON Mongo":
                    MessageBox.Show(this.dataTransferComboBox.Text);
                    break;
                default: MessageBox.Show("First choose option");
                    break;
            }
        }

        void worker_DoMigrateDateFromMsSqlToMySql(object sender, DoWorkEventArgs e)
        {
            var response = MessageBox.Show("Are you sure", "Start transfer", MessageBoxButtons.OKCancel);

            if (response == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                MigrateDataFromMsSqlToMySql();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        private void MigrateDataFromMsSqlToMySql()
        {
            var migrator =
                new DateBaseMigrator(this.msSqlContext, this.mySqlContext);
            migrator.Changed += migrator_Changed;
            migrator.ExcuteMigration();

        }

        private void migrator_Changed(object sender, EventArgs e)
        {
            var report = (MigrationReport)e;
            this.transferStatusRichTextBox.AppendText(
                "Status: " + report.Status + " "
                + "Rows added: " + report.RowsAdd + " "
                + Environment.NewLine);
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure", "Start transfer", MessageBoxButtons.OKCancel);

            switch (this.reportComboBox.Text)
            {
                case "Sales Pdf report":
                    MessageBox.Show(this.reportComboBox.Text);
                    break;
                case "Sales XML report":
                    MessageBox.Show(this.reportComboBox.Text);
                    break;
                case "Sales JSON report":
                    MessageBox.Show(this.reportComboBox.Text);
                    break;
                case "Vendors Financial Result report.xlsx":
                    this.GenerateReport();
                    break;
                default: MessageBox.Show("First choose option");
                    break;
            }
        }

        private void GenerateReport()
        {
            var taxes = this.sqliteContext.Taxes.ToList();

            var vendorsByTax = mySqlContext.Vendors.Include(x => x.Products).ToList()
               .Select(v => new
               {
                   Name = v.Name,
                   Tax = v.Products
                   .Sum(x => x.Incomes.Sum(y => y.Quantity * y.Product.Price
                       * (decimal)taxes.Where(t => t.ProductId == x.Id).Select(t => t.Value).FirstOrDefault()))
               }).ToList();


            var vendors = mySqlContext.Vendors
                .Select(v => new
                {
                    VendorName = v.Name,
                    Incomes = v.Products.Sum(x => x.Incomes.Sum(y => y.Quantity * y.Product.Price)),
                    Expense = v.Expenses.Sum(x => x.Value)
                }).ToList();


            var vendorsData = new List<VendorsFinResultReport>();
            foreach (var ven in vendors)
            {
                var tax = vendorsByTax
                    .Where(v => v.Name == ven.VendorName)
                    .Select(v => v.Tax).FirstOrDefault();
                vendorsData.Add(new VendorsFinResultReport()
                {
                    VendorName = ven.VendorName,
                    Expenses = ven.Expense,
                    Incomes = ven.Incomes,
                    Taxes = tax
                });

            }
        }

        private void getStartDateBnt_Click(object sender, EventArgs e)
        {
            this.startDateTextBox.Text = this.monthCalendar1.SelectionRange.Start.ToString();
        }

        private void getEndDateBtn_Click(object sender, EventArgs e)
        {
            this.endDateTextBox.Text = this.monthCalendar1.SelectionRange.Start.ToString();
        }
    }
}
