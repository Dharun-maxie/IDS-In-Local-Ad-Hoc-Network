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
    public partial class ReceiverA : Form
    {
        public ReceiverA()
        {
            InitializeComponent();
        }


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rs;
        ConnectionClass c = new ConnectionClass();
        private void ReceiverA_Load(object sender, EventArgs e)
        {
            try
            {
                //if(MessageBox.Show("Do You Want To Connect A?", "Connect", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //{
                ProjectLink.sta = "Connected";
                con = new SqlConnection(c.GetConnection());
                con.Open();
                //}
                // else 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select * from ncstatus where nodename=@nodename", con);
                cmd.Parameters.AddWithValue("nodename", "A");
                rs = cmd.ExecuteReader();
                string st ="";
                if(rs.Read())
                    st = rs["status"].ToString();
                rs.Close();
                cmd.Dispose();
                if(st.Equals("Success"))
                {
                    string fullpath = Application.StartupPath;
                    string fullpath1 = fullpath.Substring(0, fullpath.IndexOf("\\bin"));
                    fullpath1 = fullpath1 + "\\Upload";
                    DirectoryInfo di = new DirectoryInfo(fullpath1);
                    if (di.Exists)
                    {
                        FileInfo[] fi = di.GetFiles();
                        for (int i = 0; i < fi.Length; i++)
                        {
                            string fname = fi[i].Name ;
                            if (SelectFile.rafname.Equals(fname))
                            {
                                fname = fullpath1 + "\\" + fname;
                                webBrowser1.Navigate(fname);
                                timer1.Enabled = false;
                                break;
                            }
                        }
                    }
                }

                else if(st.Equals ("Attack"))
                {

                  //  webBrowser1.Document.Body.InnerHtml = "";

                    webBrowser1.Navigate("");
                    timer1.Enabled = false;
                    
                }
              
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ReceiverA_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("hai");
            timer1.Enabled = true;
        }

       
    }
}