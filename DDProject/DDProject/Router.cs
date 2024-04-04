using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace DDProject
{
    public partial class Router : Form
    {
        public Router()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rs;
        ConnectionClass c = new ConnectionClass();
        Thread t;
        //void changeimage()
        //{
        //    string path = Application.StartupPath;
        //    path = path.Substring(0, path.LastIndexOf("bin"));
        //    while(true)
        //    {
        //        if(ProjectLink.sta.Equals(""))
        //        {
        //            pictureBox1.Image = Image.FromFile(path + "LineImage\\newcement.png");

        //        }

        //        else if(ProjectLink.sta.Equals("Connected"))
        //        {
        //            pictureBox1.Image = Image.FromFile(path+"LineImage\\Green2.png");

        //        }
        //        Thread.Sleep(1000);
        //    }
        //}

        private void Router_Load(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(c.GetConnection());
                con.Open();
             //   t = new Thread(changeimage);
             //   t.Start();
                


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            path = path.Substring(0, path.LastIndexOf("bin"));
            if(ProjectLink.sta.Equals(""))
            {
                pictureBox1.Image = Image.FromFile(path + "LineImage\\newcement.png");

            }

            else if(ProjectLink.sta.Equals("Connected"))
            {
                pictureBox1.Image = Image.FromFile(path + "LineImage\\Green2.png");

            }


            if(ProjectLink.stb.Equals(""))
            {
                pictureBox2.Image = Image.FromFile(path + "LineImage\\newcement.png");

            }

            else if(ProjectLink.stb.Equals("Connected"))
            {
                pictureBox2.Image = Image.FromFile(path + "LineImage\\Green2.png");

            }


            if(ProjectLink.stc.Equals(""))
            {
                pictureBox3.Image = Image.FromFile(path + "LineImage\\newcement.png");

            }

            else if(ProjectLink.stc.Equals("Connected"))
            {
                pictureBox3.Image = Image.FromFile(path + "LineImage\\Green2.png");

            }

            if(ProjectLink.std.Equals(""))
            {
                pictureBox4.Image = Image.FromFile(path + "LineImage\\newcement.png");

            }

            else if(ProjectLink.std.Equals("Connected"))
            {
                pictureBox4.Image = Image.FromFile(path + "LineImage\\Green2.png");

            }

            if(ProjectLink.ste.Equals(""))
            {
                pictureBox5.Image = Image.FromFile(path + "LineImage\\newcement.png");

            }

            else if(ProjectLink.ste.Equals("Connected"))
            {
                pictureBox5.Image = Image.FromFile(path + "LineImage\\Green2.png");

            }

            if(ProjectLink.stf.Equals(""))
            {
                pictureBox6.Image = Image.FromFile(path + "LineImage\\newcement.png");

            }

            else if(ProjectLink.stf.Equals("Connected"))
            {
                pictureBox6.Image = Image.FromFile(path + "LineImage\\Green2.png");

            }
        }

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    ProjectLink p = new ProjectLink();
        //    p.Show();
        //}
    }
}