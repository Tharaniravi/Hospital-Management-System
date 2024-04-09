using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Hospital_Management
{
    public partial class Admin : Form
    {
        private OleDbConnection con = new OleDbConnection();
        public Admin()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Srija-Pooja\Documents\Visual Studio 2010\Projects\Hospital Management\Hospital Management\database\Adminlogin.accdb;Persist Security Info = False;";
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from login where user='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            OleDbDataReader or = cmd.ExecuteReader();
            int count = 0;
            while (or.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {

                Dashboard da = new Dashboard();
                da.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect Username and Password", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

    }
}
