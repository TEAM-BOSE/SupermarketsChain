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
    using SupermarketsChain.Controllers;
    using ExcelReport;

    public partial class MainForm : Form
    {
        private MsSqlContext msSqlContext;
        private MySqlContext mySqlContext;
        private SQLiteAppContext sqliteContext;
        private BackgroundWorker worker;
        private Requester requester;

        public MainForm()
        {
            InitializeComponent();
            this.msSqlContext = new MsSqlContext();
            this.mySqlContext = new MySqlContext();
            this.sqliteContext = new SQLiteAppContext();
            this.worker = new BackgroundWorker();
            this.worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            this.monthCalendar1.MaxSelectionCount = 1;
            this.requester = new Requester(this.mySqlContext, sqliteContext);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.worker.DoWork -= worker_DoMigrateDateFromMsSqlToMySql;
            this.dataTransferBtn.IsAccessible = true;
        }

        private void dataTransferBtn_Click(object sender, EventArgs e)
        {
            this.dataTransferBtn.IsAccessible = false;

            switch (this.dataTransferComboBox.Text)
            {
                case "From Oracle to MS SQL":
                    MessageBox.Show(this.dataTransferComboBox.Text);
                    break;
                case "From MS SQL to MySQL":
                    this.worker.DoWork += worker_DoMigrateDateFromMsSqlToMySql;
                    this.worker.RunWorkerAsync();
                    break;
                case "From Zip to MS SQL":
                    MessageBox.Show(this.dataTransferComboBox.Text);
                    break;
                case "From XML to MS SQL":
                    MessageBox.Show(this.dataTransferComboBox.Text);
                    break;
                case "From JSON to Mongo":
                    MessageBox.Show(this.dataTransferComboBox.Text);
                    break;
                default: MessageBox.Show("First choose option");
                    break;
            }
        }

        void worker_DoMigrateDateFromMsSqlToMySql(object sender, DoWorkEventArgs e)
        {
            var response = MessageBox.Show("Are you sure?", "Start transfer", MessageBoxButtons.OKCancel);

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
            var report = (MigrationReportEventArgs)e;
            this.transferStatusRichTextBox.AppendText(
                "Status: " + report.Status + " "
                + "Rows added: " + report.RowsAdded + " "
                + Environment.NewLine);
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure", "Generate report", MessageBoxButtons.OKCancel);

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
                    this.GenerateVendorsFinReport();
                    break;
                default: MessageBox.Show("First choose option");
                    break;
            }
        }

        private void GenerateVendorsFinReport()
        {
            var data = this.requester.RequestVendorsFinResultReportData();
            ExcelReportManager.GenerateVendorsFinResultReport(data);
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
