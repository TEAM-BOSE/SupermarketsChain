using System;
namespace DataMigrations
{
    public class MigrationReportEventArgs : EventArgs
    {
        public MigrationReportEventArgs(string status, int rowsAdded)
        {
            this.Status = status;
            this.RowsAdded = rowsAdded;
        }

        public string Status { get; set; }

        public int RowsAdded { get; set; }
    }
}
