using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SupermarketsChain.MsSQL;
using SupermarketsChain.MySQL;
using DataMigrations;

namespace SupermarketsChain
{
    public partial class SupermarketsChain : Form
    {
        public SupermarketsChain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("asdasd", "Header", MessageBoxButtons.OKCancel);
            var mssqlContext = new MsSqlContext();
            var mysqlContext = new MySqlContext();


            var migrator = new DateBaseMigrator(mssqlContext, mysqlContext);
            migrator.Changed += migrator_Changed;
            migrator.ExcuteMigration();
            MessageBox.Show("Finished");
        }

        private void migrator_Changed(object sender, EventArgs e)
        {
            var myevent = (MigrationReport)e;
            MessageBox.Show(myevent.Somestr);
        }

        void migrator_Changed(object sender, MigrationReport e)
        {
            MessageBox.Show(e.Somestr);
        }
    }
}
