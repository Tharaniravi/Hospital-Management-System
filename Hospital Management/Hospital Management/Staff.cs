using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
namespace Hospital_Management
{
    public partial class Staff : Form
    {
        private OleDbConnection con = new OleDbConnection();
        private OleDbDataAdapter adp;
        private DataTable tb;
        private DataRow row;
        public int i;
        public Staff()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Srija-Pooja\Documents\Visual Studio 2010\Projects\Hospital Management\Hospital Management\database\Staffdetails.accdb;Persist Security Info = False;";
        }
        
        String getgender;
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Staff values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + ",'" + getgender + "','" + textBox5.Text + "','" + textBox6.Text + "','"+textBox7.Text+"',"+textBox8.Text+",'"+textBox9.Text+"','"+textBox10.Text+"')";
            MessageBox.Show("Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmd.ExecuteReader();
            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            if (radioButton1.Checked)
            {
                radioButton1.Checked = false;
            }
            else
                if (radioButton2.Checked)
                {
                    radioButton2.Checked = false;
                }
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            getgender = "Female";
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            getgender = "Male";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "update Staff set Salary= " + textBox8.Text + " where Staffid= " + textBox1.Text + "";
            MessageBox.Show("Record Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmd.ExecuteReader();
            con.Close();
            textBox1.Clear();
            textBox8.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from Staff where Staffid=" + textBox1.Text + "";
            MessageBox.Show("Record Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmd.ExecuteReader();
            con.Close();
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            adp = new OleDbDataAdapter("select * from Staff", con);
            tb = new DataTable();
            dataGridView1.DataSource = tb;
            adp.Fill(tb);
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            adp = new OleDbDataAdapter("select * from Staff where Staffid=" + textBox1.Text + "", con);
            tb = new DataTable();
            dataGridView1.DataSource = tb;
            adp.Fill(tb);
            con.Close();
            textBox1.Clear();
        }
    }
}
