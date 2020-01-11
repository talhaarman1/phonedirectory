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
using System.Threading;
namespace PhoneDirectory
{
    public partial class main : Form
    {
        public main()
        {
            Thread t = new Thread(new ThreadStart(SplashStart));
            t.Start();
            Thread.Sleep(5000);

            InitializeComponent();
            t.Abort();
        }
        public void SplashStart()
        {
            Application.Run(new SplashScreen());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = phonebook; Integrated Security = True");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from login where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Form1 f = new Form1();
                f.Show();

            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
        }
    }
}
