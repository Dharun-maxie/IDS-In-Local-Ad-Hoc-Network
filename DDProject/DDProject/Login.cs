using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace DDProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox1.Text.Equals("Admin") && textBox2.Text.Equals("Admin"))
            {

                ProjectLink pl = new ProjectLink();
                pl.Show();
            }
            else
                MessageBox.Show("Invalid UserName Or Password.");


        }

        SqlConnection con;
        SqlCommand cmd;
        //SqlDataReader rs;
        ConnectionClass c = new ConnectionClass();
        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
               // MessageBox.Show(this.Width + ":" + this.Height);
                con = new SqlConnection(c.GetConnection());
                con.Open();


                cmd = new SqlCommand("delete from receiver", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from ncstatus", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                string fullpath = Application.StartupPath;
                //MessageBox.Show(fullpath);
                string fullpath1 = fullpath.Substring(0, fullpath.IndexOf("\\bin"));
               // MessageBox.Show(fullpath1);
                fullpath1 = fullpath1 + "\\Upload";
                DirectoryInfo di = new DirectoryInfo(fullpath1);
                FileInfo[] f1 = di.GetFiles();
                if (f1.Length != 0)
                {
                    foreach (FileInfo f2 in f1)

                        f2.Delete();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}