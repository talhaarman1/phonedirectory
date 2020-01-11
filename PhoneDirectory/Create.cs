using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PhoneDirectory
{
    public partial class Create : Form
    {
        string ImgPath;

        public Create()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sn = new SqlConnection(@"Data Source=.;Initial Catalog=phonebook;Integrated Security=True");
            sn.Open();
            string s = @"insert into createcontact Values('"+ textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox5.Text + "')";
            SqlCommand sc = new SqlCommand(s, sn);
            sc.ExecuteNonQuery();
            this.Close();
            Form2 a = new Form2();
            a.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "JPG|*.jpg|PNG|*.png";
            if (o.ShowDialog() == DialogResult.OK)
            {
                ImgPath = o.FileName;
                pictureBox1.Image = new Bitmap(o.FileName);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "JPG|*.jpg|PNG|*.png";
            if (o.ShowDialog() == DialogResult.OK)
            {
                ImgPath = o.FileName;
                pictureBox1.Image = new Bitmap(o.FileName);
            }
        }

        private void Create_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            SqlConnection sn = new SqlConnection(@"Data Source=.;Initial Catalog=phonebook;Integrated Security=True");
            sn.Open();
            if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && textBox4.Text != null)
            { string s = @"delete from createcontact where fname = '" + textBox1.Text + "' and  lname = '" + textBox2.Text + "' and nname = '" + textBox3.Text + "'";
                SqlCommand sc = new SqlCommand(s, sn);
                sc.ExecuteNonQuery();
                this.Close();
                Form2 a = new Form2();
                a.Show();
             

               
          
            }
            else
            {
                MessageBox.Show("record not found");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
            a.Show();
        }
    }
}