using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Net;
using System.Collections;

namespace DDProject
{
    public partial class SelectFile : Form
    {
        public SelectFile()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rs;
        ConnectionClass c = new ConnectionClass();
        private void SelectFile_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(c.GetConnection());
                con.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        string epath;
        public static string rafname, rbfname, rcfname, rdfname, refname, rffname;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //    richTextBox1.Clear();
                webBrowser1.Navigate("");
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.FileName.Length > 0)
                    {

                        //    richTextBox1.LoadFile(openFileDialog1.FileName,RichTextBoxStreamType.PlainText );
                        // richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText );
                      
                        string fullpath = Application.StartupPath;
                        string fullpath1 = fullpath.Substring(0, fullpath.IndexOf("\\bin"));
                        fullpath1 = fullpath1 + "\\Upload";



                        /*DirectoryInfo di = new DirectoryInfo(fullpath1);
                        FileInfo[] f1 = di.GetFiles();
                        if (f1.Length != 0)
                        {
                            foreach (FileInfo f2 in f1)
                                f2.Delete();
                        }*/

                        FileInfo fi = new FileInfo(openFileDialog1.FileName);

                 

                        string fname = openFileDialog1.FileName;
                        fname = fname.Substring(fname.LastIndexOf("\\") + 1);

                        string fname1 = DateTime.Now.Ticks + "_" + fname;
                        string fullpath2= fullpath.Substring(0, fullpath.IndexOf("\\bin"));
                        fullpath2 = fullpath2 + "\\Upload\\" + fname1;
                        epath = fname1;


                        // MessageBox.Show(fullpath);
                        fi.CopyTo(fullpath2);
                        textBox1.Text = fname;

                        webBrowser1.Navigate(openFileDialog1.FileName);



                    }

                }
                else
                {
                    MessageBox.Show("Select Any One FileName.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Clear();
            groupBox1.Visible = true;
            groupBox1.Location = new System.Drawing.Point(150, 250);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                groupBox2.Location = new System.Drawing.Point(150, 250);
                comboBox2.Items.Clear();
                comboBox2.Text = "";
                if(comboBox1.SelectedIndex == 0)
                {
                    comboBox2.Items.Add("A");
                    comboBox2.Items.Add("B");
                }
                else if(comboBox1.SelectedIndex == 1)
                {
                    comboBox2.Items.Add("C");
                    comboBox2.Items.Add("D");
                }
                else if(comboBox1.SelectedIndex == 2)
                {
                    comboBox2.Items.Add("E");
                    comboBox2.Items.Add("F");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;

            groupBox3.Visible = true;
            groupBox3.Location = new System.Drawing.Point(150, 250);
          
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {


                string hname = Dns.GetHostName();
                IPHostEntry ip = Dns.GetHostEntry(hname);
                //IPHostEntry ip = Dns.GetHostByAddress("192.9.200.130");
                //  MessageBox.Show(ip.HostName);
                IPAddress[] i1 = ip.AddressList;
                IEnumerator ie = i1.GetEnumerator();
                string haddress = "";
                if(ie.MoveNext())
                    haddress = ie.Current.ToString();

                if(!(textBox2.Text.Equals(haddress) || textBox2.Text.Equals("localhost")))
                {
                    MessageBox.Show("Incorrect IPAddress.Please Type Correct IPAddress.");
                    return;
                }



                string router = comboBox1.SelectedItem.ToString();
                string node = comboBox2.SelectedItem.ToString();
                groupBox3.Visible = false;

                cmd = new SqlCommand("select * from receiver where nodename=@nodename", con);
                cmd.Parameters.AddWithValue("nodename", comboBox2.SelectedItem.ToString());
                rs = cmd.ExecuteReader();
                string status = "";
                long fsize = 0;

                string ipaddress = "";
                string ipstatus = "";

                if(rs.Read())
                {
                    ipaddress = rs["ipaddress"].ToString();
                    status = rs["status"].ToString();
                    fsize = long.Parse(rs["fsize"].ToString());
                    ipstatus = rs["ipstatus"].ToString();
                    rs.Close();
                    cmd.Dispose();
                }

                else
                {
                    rs.Close();
                    cmd.Dispose();
                    MessageBox.Show("Receiver " + comboBox2.SelectedItem.ToString() + " Not Connected.Please First Connect Receiver " + comboBox2.SelectedItem.ToString() + ".");
                    return;
                }

                if(status == "null" && fsize == 0)
                {
                    MessageBox.Show("Goto IDRS Master.First Change Node Status.");
                    return;
                }

                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                long fl = fi.Length;
                string ncsta = "";

                if(fl > fsize)
                {
                    MessageBox.Show("DDOS Attack Found.");
                    ncsta = "Attack";
                //    return;
                }

                else if(status.Equals("Block"))
                {
                    MessageBox.Show("BlockMail Attacker Found.");
                    ncsta = "Attack";
                    //return;
                }

                //if(!(ipaddress == textBox2.Text || textBox2.Text.Equals("localhost")))
                //{
                //}

                else if(ipstatus.Equals("changed"))
                {
                    MessageBox.Show("Location Disclosure Attacker Found.");
                    ncsta = "Attack";
                    //return;
                }

                else
                {
                    MessageBox.Show("Successfully Send Your Data");
                    ncsta = "Success";
                    if (comboBox2.SelectedItem.ToString().Equals("A"))
                    
                        rafname = epath;
                     

                    else if (comboBox2.SelectedItem.ToString().Equals("B"))
                        rbfname = epath;

                    else if (comboBox2.SelectedItem.ToString().Equals("C"))
                        rcfname = epath;

                    else if (comboBox2.SelectedItem.ToString().Equals("D"))
                        rdfname = epath;

                    else if (comboBox2.SelectedItem.ToString().Equals("E"))
                        refname = epath;

                    else if (comboBox2.SelectedItem.ToString().Equals("F"))
                        rffname = epath;


                }

                cmd = new SqlCommand("select isnull(max(cstatus),0)+1 from ncstatus ", con);
                int cstatus = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Dispose();

                cmd = new SqlCommand("update ncstatus set router=@router,status=@status,cstatus=@cstatus where nodename=@nodename", con);
                cmd.Parameters.AddWithValue("router", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("status", ncsta);
                cmd.Parameters.AddWithValue("cstatus", cstatus );
                cmd.Parameters.AddWithValue("nodename", comboBox2.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
              

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     /*   private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string fullpath = Application.StartupPath;
                string fullpath1 = fullpath.Substring(0, fullpath.IndexOf("\\bin"));
                fullpath1 = fullpath1 + "\\Upload";
                DirectoryInfo di = new DirectoryInfo(fullpath1);
                FileInfo[] f1 = di.GetFiles();
                if(f1.Length != 0)
                {
                    foreach(FileInfo f2 in f1)
                        
                        f2.Delete();
                }
                textBox1.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox2.Text = "";
                webBrowser1.Navigate("");
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }*/

     
    }
}