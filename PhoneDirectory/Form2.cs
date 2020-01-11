using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace PhoneDirectory
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DataTable dt;

        SqlConnection con = new SqlConnection();


        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'phonebookDataSet.createcontact' table. You can move, or remove it, as needed.
            //this.createcontactTableAdapter.Fill(this.phonebookDataSet.createcontact);
            con.ConnectionString = ConfigurationManager.ConnectionStrings["PhoneDirectory.Properties.Settings.phonebookConnectionString"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from createcontact", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
               Create a = new Create();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];


                a.textBox2.Text = row.Cells[1].Value.ToString();
                a.textBox3.Text = row.Cells[2].Value.ToString();
                a.textBox1.Text = row.Cells[0].Value.ToString();
                a.textBox4.Text = row.Cells[3].Value.ToString();
                a.textBox5.Text = row.Cells[4].Value.ToString();
                a.textBox6.Text =row.Cells[5].Value.ToString();
                a.textBox7.Text =row.Cells[6].Value.ToString();
                a.Show();
                dataGridView1.Refresh();
            }
        }

       

    

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
          
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("fname LIKE'{0}%'",textBox1.Text);
            dataGridView1.DataSource = dv;
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
            a.Show();
        }
    }
}
