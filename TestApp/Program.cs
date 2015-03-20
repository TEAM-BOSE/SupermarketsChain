namespace TestApp
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SupermarketsChain.MsSQL;
    using SupermarketsChain.MySQL;
    using SupermarketsChain.Models;   
    using DataMigrations;


    class Program
    {
        static void Main(string[] args)
        {
            var msSql = new MsSqlContext();
            var mySql = new MySqlContext();
            var migrator = new DateBaseMigrator(msSql, mySql);

            migrator.ExcuteMigration();

           // Console.WriteLine(migrator.changes);
        }
    }
}
