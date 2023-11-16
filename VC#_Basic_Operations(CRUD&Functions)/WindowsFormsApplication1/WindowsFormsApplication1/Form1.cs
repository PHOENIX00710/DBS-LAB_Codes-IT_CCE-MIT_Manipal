using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();
        }
        public void connectDB()
        {
            conn = new OracleConnection("DATA SOURCE=172.16.54.24:1521/ictorcl;USER ID=IT292;PASSWORD=student");
            try
            {
                conn.Open();
                MessageBox.Show("Connected");
            }
            catch
            {
                MessageBox.Show("Error in Connection!!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            connectDB();
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "select * from person";
            command1.CommandType = CommandType.Text;
            OracleDataReader dr = command1.ExecuteReader();
            dr.Read();
            textBox1.Text = dr.GetString(0);
            textBox2.Text = dr.GetString(1);
            textBox3.Text = dr.GetString(2);
            command1.Dispose();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connectDB();
            string person_age = "";
            OracleCommand command2 = conn.CreateCommand();
            command2.CommandText = "@D:/210911292/queries/test.sql";
            command2.CommandType = CommandType.Text;
            command2.ExecuteNonQuery();
            command2.Dispose();
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "select chutiya_kshiteesh() from dual";
            command1.CommandType = CommandType.Text;
            try
            {
                OracleDataReader dr = command1.ExecuteReader();
                dr.Read();
                person_age = dr.GetString(0);
                MessageBox.Show(person_age);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            command1.Dispose();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connectDB();
            OracleCommand c2 = conn.CreateCommand();
            c2.CommandText = "@D:/210911292/queries/srijan.sql";
            c2.CommandType = CommandType.Text;
            c2.Dispose();
            OracleCommand c1 = conn.CreateCommand();
            c1.CommandText = "select gymm(" +"'"+textBox1.Text+"','"+textBox2.Text+"'"+ ") from dual ";
            c1.CommandType = CommandType.Text;
            OracleDataReader dr = c1.ExecuteReader();
            dr.Read();
            string flag=dr.GetString(0).ToString();
            c1.Dispose();
            MessageBox.Show(flag);

            if (flag == "FOUND")
            {
                OracleCommand c3 = conn.CreateCommand();
                c3.CommandText = "insert into panic values (" + "'" + textBox1.Text + "','" + textBox2.Text + "'" + ")";
                c3.CommandType = CommandType.Text;
                c3.ExecuteNonQuery();
                MessageBox.Show("No Skill issue");
                c3.Dispose();
            }
            else {
                MessageBox.Show("Skill issue");
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connectDB();

            // Create command for stored procedure
            OracleCommand c1 = conn.CreateCommand();
            c1.CommandText = "select save_on_location('"+textBox1.Text+"') from dual";
            c1.CommandType = CommandType.Text;
            try
            {
                OracleDataReader dr = c1.ExecuteReader();
                dr.Read();
                MessageBox.Show("Executed");
            }
            catch (Exception ex) { 
                MessageBox.Show("Skill issue: "+ex.Message);
            }
        }

    }
}
