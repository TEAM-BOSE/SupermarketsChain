using System;
namespace DataMigrations
{
    public class MigrationReport : EventArgs
    {
        public MigrationReport(string status, int rowsAdd)
        {
            this.Status = status;
            this.RowsAdd = rowsAdd;
        }

        public string Status { get; set; }

        public int RowsAdd { get; set; }
    }
}
