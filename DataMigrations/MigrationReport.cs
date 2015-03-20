using System;
namespace DataMigrations
{
    public class MigrationReport : EventArgs
    {
        public string Somestr { get; set; }
        public MigrationReport(string str)
        {
            this.Somestr = str;
        }
    }
}
