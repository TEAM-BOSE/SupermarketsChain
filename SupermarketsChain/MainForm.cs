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
        private const string TransferDataMessage = "Transferring data...";
        private const string PleaseWaitMessage = "Please wait...";
        private const string GenerateReportMessage = "Generating report...";

        private MsSqlContext msSqlContext;
        private MySqlContext mySqlContext;
        private SQLiteAppContext sqliteContext;
        private BackgroundWorker worker;
        private Requester requester;
        private SaveFileDialog saveDialog;

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
            this.saveDialog = new SaveFileDialog();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.worker.DoWork -= worker_DoMigrateDateFromMsSqlToMySql;
            this.ChangeCursorAndBottonToDefault();
        }

        private void dataTransferBtn_Click(object sender, EventArgs e)
        {
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
            this.ChangeCursorAndBottons(TransferDataMessage, PleaseWaitMessage);

            var migrator =
                new DateBaseMigrator(this.msSqlContext, this.mySqlContext);
            migrator.Changed += migrator_Changed;
            migrator.ExcuteMigration();
        }

        private void migrator_Changed(object sender, EventArgs e)
        {
            var report = (MigrationReportEventArgs)e;
            this.transferStatusRichTextBox.BeginInvoke(((MethodInvoker)delegate()
            {
                this.transferStatusRichTextBox.AppendText(
                  "Status: " + report.Status + " "
                  + "Rows added: " + report.RowsAdded + " "
                  + Environment.NewLine);
            }));
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            string fileName = null;

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
                case "Excel Vendors Financial Result report":
                    this.saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    var dialogResult = this.saveDialog.ShowDialog();

                    if (dialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                    if (dialogResult == DialogResult.OK)
                    {
                        fileName = this.saveDialog.FileName;
                        this.worker.DoWork += worker_GenerateVendorsReport;
                        this.worker.RunWorkerAsync(fileName);
                    }

                    break;
                default: MessageBox.Show("First choose option");
                    break;
            }
        }

        private void worker_GenerateVendorsReport(object sender, DoWorkEventArgs e)
        {
            this.ChangeCursorAndBottons(PleaseWaitMessage, GenerateReportMessage);

            var fileName = e.Argument.ToString();
            this.GenerateVendorsFinReport(fileName);

        }

        private void GenerateVendorsFinReport(string fileName)
        {
            var data = this.requester.RequestVendorsFinResultReportData();
            ExcelReportManager.GenerateVendorsFinResultReport(data, fileName);
        }

        private void getStartDateBnt_Click(object sender, EventArgs e)
        {
            this.startDateTextBox.Text = this.monthCalendar1.SelectionRange.Start.ToString();
        }

        private void getEndDateBtn_Click(object sender, EventArgs e)
        {
            this.endDateTextBox.Text = this.monthCalendar1.SelectionRange.Start.ToString();
        }

        private void ChangeCursorAndBottons(string dataTransferBtnMessage, string reportBtnMessage)
        {
            this.reportBtn.BeginInvoke((MethodInvoker)(delegate()
            {
                this.reportBtn.Text = reportBtnMessage;
                this.reportBtn.IsAccessible = false;
            }));

            this.dataTransferBtn.BeginInvoke(((MethodInvoker)delegate()
            {
                this.dataTransferBtn.Text = dataTransferBtnMessage;
                this.dataTransferBtn.IsAccessible = false;
                this.Cursor = Cursors.WaitCursor;
            }));
        }

        private void ChangeCursorAndBottonToDefault()
        {
            this.reportBtn.Text = "Generate report";
            this.dataTransferBtn.Text = "Transfer data";
            this.Cursor = Cursors.Default;
            this.dataTransferBtn.IsAccessible = true;
        }
    }
}
