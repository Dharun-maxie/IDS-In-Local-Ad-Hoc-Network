using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace DDProject
{
    public partial class IDRSMaster : Form
    {
        public IDRSMaster()
        {
            InitializeComponent();
        }

      
        SqlDataAdapter adp;
        DataTable dt;
        ConnectionClass c = new ConnectionClass();
        private void IDRSMaster_Load(object sender, EventArgs e)
        {
            

        }


        /*private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            path = path.Substring(0, path.LastIndexOf("bin"));
            //MessageBox.Show(path);
            path = path + "LineImage\\";
            string status = "Block";


            if(comboBox1.SelectedIndex == 0)
            {
                ti1.Visible = true;

                ti2.Visible = true;

                ti3.Visible = true;

                ti4.Visible = true;




                if(comboBox2.SelectedIndex == 0)
                {
                    if(status.Equals("Block"))
                    {
                        r1t1.Image = Image.FromFile(path + "redt1.png");
                        r1t2.Image = Image.FromFile(path + "redt1.png");
                        r1t3.Image = Image.FromFile(path + "redt1.png");
                        i1.Image = Image.FromFile(path + "off.jpg");
                    }

                    else if(status.Equals("UnBlock"))
                    {
                        r1t1.Image = Image.FromFile(path + "st1.png");
                        r1t2.Image = Image.FromFile(path + "st1.png");
                        r1t3.Image = Image.FromFile(path + "st1.png");
                        i1.Image = Image.FromFile(path + "on.jpg");
                    }
                    r1t1.Visible = true;
                    r1t2.Visible = true;
                    r1t3.Visible = true;

                }

                else if(comboBox2.SelectedIndex == 1)
                {


                    if(status.Equals("Block"))
                    {
                        r1b1.Image = Image.FromFile(path + "redr1.png");
                        r1b2.Image = Image.FromFile(path + "redr1.png");
                        r1b3.Image = Image.FromFile(path + "redr1.png");
                        i2.Image = Image.FromFile(path + "off.jpg");
                    }

                    else if(status.Equals("UnBlock"))
                    {
                        r1b1.Image = Image.FromFile(path + "sr1.png");
                        r1b2.Image = Image.FromFile(path + "sr1.png");
                        r1b3.Image = Image.FromFile(path + "sr1.png");
                        i2.Image = Image.FromFile(path + "on.jpg");
                    }
                    r1b1.Visible = true;
                    r1b2.Visible = true;
                    r1b3.Visible = true;

                }
            }



            else if(comboBox1.SelectedIndex == 1)
            {
                si1.Visible = true;

                si2.Visible = true;

                si3.Visible = true;

                si4.Visible = true;




                if(comboBox2.SelectedIndex == 0)
                {
                    if(status.Equals("Block"))
                    {
                        r2t1.Image = Image.FromFile(path + "redt1.png");
                        r2t2.Image = Image.FromFile(path + "redt1.png");
                        r2t3.Image = Image.FromFile(path + "redt1.png");
                        i3.Image = Image.FromFile(path + "off.jpg");
                    }

                    else if(status.Equals("UnBlock"))
                    {
                        r2t1.Image = Image.FromFile(path + "st1.png");
                        r2t2.Image = Image.FromFile(path + "st1.png");
                        r2t3.Image = Image.FromFile(path + "st1.png");
                        i3.Image = Image.FromFile(path + "on.jpg");
                    }
                    r2t1.Visible = true;
                    r2t2.Visible = true;
                    r2t3.Visible = true;

                }

                else if(comboBox2.SelectedIndex == 1)
                {


                    if(status.Equals("Block"))
                    {
                        r2b1.Image = Image.FromFile(path + "redr1.png");
                        r2b2.Image = Image.FromFile(path + "redr1.png");
                        r2b3.Image = Image.FromFile(path + "redr1.png");
                        i4.Image = Image.FromFile(path + "off.jpg");
                    }

                    else if(status.Equals("UnBlock"))
                    {
                        r2b1.Image = Image.FromFile(path + "sr1.png");
                        r2b2.Image = Image.FromFile(path + "sr1.png");
                        r2b3.Image = Image.FromFile(path + "sr1.png");
                        i4.Image = Image.FromFile(path + "on.jpg");
                    }
                    r2b1.Visible = true;
                    r2b2.Visible = true;
                    r2b3.Visible = true;

                }
            }




            else if(comboBox1.SelectedIndex == 2)
            {
                bi1.Visible = true;

                bi2.Visible = true;

                bi3.Visible = true;

                bi4.Visible = true;




                if(comboBox2.SelectedIndex == 0)
                {
                    if(status.Equals("Block"))
                    {
                        r3t1.Image = Image.FromFile(path + "redt1.png");
                        r3t2.Image = Image.FromFile(path + "redt1.png");
                        r3t3.Image = Image.FromFile(path + "redt1.png");
                        i5.Image = Image.FromFile(path + "off.jpg");
                    }

                    else if(status.Equals("UnBlock"))
                    {
                        r3t1.Image = Image.FromFile(path + "st1.png");
                        r3t2.Image = Image.FromFile(path + "st1.png");
                        r3t3.Image = Image.FromFile(path + "st1.png");
                        i5.Image = Image.FromFile(path + "on.jpg");
                    }
                    r3t1.Visible = true;
                    r3t2.Visible = true;
                    r3t3.Visible = true;

                }

                else if(comboBox2.SelectedIndex == 1)
                {


                    if(status.Equals("Block"))
                    {
                        r3b1.Image = Image.FromFile(path + "redr1.png");
                        r3b2.Image = Image.FromFile(path + "redr1.png");
                        r3b3.Image = Image.FromFile(path + "redr1.png");
                        i6.Image = Image.FromFile(path + "off.jpg");
                    }

                    else if(status.Equals("UnBlock"))
                    {
                        r3b1.Image = Image.FromFile(path + "sr1.png");
                        r3b2.Image = Image.FromFile(path + "sr1.png");
                        r3b3.Image = Image.FromFile(path + "sr1.png");
                        i6.Image = Image.FromFile(path + "on.jpg");
                    }
                    r3b1.Visible = true;
                    r3b2.Visible = true;
                    r3b3.Visible = true;

                }
            }

        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeNodeStatus cn = new ChangeNodeStatus();
            cn.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                adp = new SqlDataAdapter("select * from ncstatus order by nodename", c.GetConnection ());
                dt = new DataTable();
                adp.Fill(dt);
                if(dt.Rows.Count != 0)
                {


                    string path = Application.StartupPath;
                    path = path.Substring(0, path.LastIndexOf("bin"));
                    //MessageBox.Show(path);
                    path = path + "LineImage\\";
                    string status = "";

                    foreach (DataRow dr in dt .Rows )
                    {
                        status = dr["status"].ToString();

                    if(dr["Router"].ToString ().Equals ("Router 1"))
                    {
                        ti1.Visible = true;

                        ti2.Visible = true;

                        ti3.Visible = true;

                        ti4.Visible = true;




                        if(dr["nodename"].ToString ().Equals ("A"))
                        {
                            if(status.Equals("Attack"))
                            {
                                r1t1.Image = Image.FromFile(path + "redt1.png");
                                r1t2.Image = Image.FromFile(path + "redt1.png");
                                r1t3.Image = Image.FromFile(path + "redt1.png");
                                i1.Image = Image.FromFile(path + "off.jpg");
                            }

                            else if(status.Equals("Success"))
                            {
                                r1t1.Image = Image.FromFile(path + "st1.png");
                                r1t2.Image = Image.FromFile(path + "st1.png");
                                r1t3.Image = Image.FromFile(path + "st1.png");
                                i1.Image = Image.FromFile(path + "on.jpg");
                            }
                            r1t1.Visible = true;
                            r1t2.Visible = true;
                            r1t3.Visible = true;

                        }

                        if(dr["nodename"].ToString().Equals("B"))
                        {


                            if(status.Equals("Attack"))
                            {
                                r1b1.Image = Image.FromFile(path + "redr1.png");
                                r1b2.Image = Image.FromFile(path + "redr1.png");
                                r1b3.Image = Image.FromFile(path + "redr1.png");
                                i2.Image = Image.FromFile(path + "off.jpg");
                            }

                            else if(status.Equals("Success"))
                            {
                                r1b1.Image = Image.FromFile(path + "sr1.png");
                                r1b2.Image = Image.FromFile(path + "sr1.png");
                                r1b3.Image = Image.FromFile(path + "sr1.png");
                                i2.Image = Image.FromFile(path + "on.jpg");
                            }
                            r1b1.Visible = true;
                            r1b2.Visible = true;
                            r1b3.Visible = true;

                        }
                    }



                    else if(dr["Router"].ToString().Equals("Router 2"))
                    {
                        si1.Visible = true;

                        si2.Visible = true;

                        si3.Visible = true;

                        si4.Visible = true;




                 if(dr["nodename"].ToString ().Equals ("C"))
                        {
                            if(status.Equals("Attack"))
                            {
                                r2t1.Image = Image.FromFile(path + "redt1.png");
                                r2t2.Image = Image.FromFile(path + "redt1.png");
                                r2t3.Image = Image.FromFile(path + "redt1.png");
                                i3.Image = Image.FromFile(path + "off.jpg");
                            }

                            else if(status.Equals("Success"))
                            {
                                r2t1.Image = Image.FromFile(path + "st1.png");
                                r2t2.Image = Image.FromFile(path + "st1.png");
                                r2t3.Image = Image.FromFile(path + "st1.png");
                                i3.Image = Image.FromFile(path + "on.jpg");
                            }
                            r2t1.Visible = true;
                            r2t2.Visible = true;
                            r2t3.Visible = true;

                        }

                        else if(dr["nodename"].ToString().Equals("D"))
                        {


                            if(status.Equals("Attack"))
                            {
                                r2b1.Image = Image.FromFile(path + "redr1.png");
                                r2b2.Image = Image.FromFile(path + "redr1.png");
                                r2b3.Image = Image.FromFile(path + "redr1.png");
                                i4.Image = Image.FromFile(path + "off.jpg");
                            }

                            else if(status.Equals("Success"))
                            {
                                r2b1.Image = Image.FromFile(path + "sr1.png");
                                r2b2.Image = Image.FromFile(path + "sr1.png");
                                r2b3.Image = Image.FromFile(path + "sr1.png");
                                i4.Image = Image.FromFile(path + "on.jpg");
                            }
                            r2b1.Visible = true;
                            r2b2.Visible = true;
                            r2b3.Visible = true;

                        }
                    }




                    else if(dr["Router"].ToString().Equals("Router 3"))
                    {
                        bi1.Visible = true;

                        bi2.Visible = true;

                        bi3.Visible = true;

                        bi4.Visible = true;




                        if(dr["nodename"].ToString().Equals("E"))
                        {
                            if(status.Equals("Attack"))
                            {
                                r3t1.Image = Image.FromFile(path + "redt1.png");
                                r3t2.Image = Image.FromFile(path + "redt1.png");
                                r3t3.Image = Image.FromFile(path + "redt1.png");
                                i5.Image = Image.FromFile(path + "off.jpg");
                            }

                            else if(status.Equals("Success"))
                            {
                                r3t1.Image = Image.FromFile(path + "st1.png");
                                r3t2.Image = Image.FromFile(path + "st1.png");
                                r3t3.Image = Image.FromFile(path + "st1.png");
                                i5.Image = Image.FromFile(path + "on.jpg");
                            }
                            r3t1.Visible = true;
                            r3t2.Visible = true;
                            r3t3.Visible = true;

                        }

                        if(dr["nodename"].ToString().Equals("F"))
                        {


                            if(status.Equals("Attack"))
                            {
                                r3b1.Image = Image.FromFile(path + "redr1.png");
                                r3b2.Image = Image.FromFile(path + "redr1.png");
                                r3b3.Image = Image.FromFile(path + "redr1.png");
                                i6.Image = Image.FromFile(path + "off.jpg");
                            }

                            else if(status.Equals("Success"))
                            {
                                r3b1.Image = Image.FromFile(path + "sr1.png");
                                r3b2.Image = Image.FromFile(path + "sr1.png");
                                r3b3.Image = Image.FromFile(path + "sr1.png");
                                i6.Image = Image.FromFile(path + "on.jpg");
                            }
                            r3b1.Visible = true;
                            r3b2.Visible = true;
                            r3b3.Visible = true;

                        }
                    }

                    }




                }
                






            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}