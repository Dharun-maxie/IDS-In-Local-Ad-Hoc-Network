using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Net;
using System.IO;

namespace DDProject
{
    public partial class ProjectLink : Form
    {
        public ProjectLink()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rs;
        ConnectionClass c = new ConnectionClass();
        private void ProjectLink_Load(object sender, EventArgs e)
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
        private void viewRouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router r = new Router();
            r.Show();
        }
        public static string sta = "";
        public static string stb = "";
        public static string stc = "";
        public static string std = "";
        public static string ste = "";
        public static string stf = "";
        private void receiverAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if(sta.Equals("Connected"))
                {
                    MessageBox.Show("Already Connected.");
                    return;

                }

                if(MessageBox.Show("Do You Want To Connect A?", "Connect", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    if(sta == "")
                    {

                        cmd = new SqlCommand("Delete from receiver where nodename=@nodename", con);
                        cmd.Parameters.AddWithValue("nodename", "A");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();


                        cmd = new SqlCommand("Delete from ncstatus where nodename=@nodename", con);
                        cmd.Parameters.AddWithValue("nodename", "A");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();




                        string hname = Dns.GetHostName();
                        IPHostEntry ip = Dns.GetHostEntry(hname);
                        //IPHostEntry ip = Dns.GetHostByAddress("192.9.200.130");
                        //  MessageBox.Show(ip.HostName);
                        IPAddress[] i1 = ip.AddressList;
                        IEnumerator ie = i1.GetEnumerator();
                        string haddress = "";
                        if(ie.MoveNext())
                            haddress = ie.Current.ToString();
                        //  textBox1.Text = haddress;
                        string port = "101";
                        string status = "null";
                        string fsize = "0";
                        string ipstatus = "default";


                        cmd = new SqlCommand("insert into receiver values(@nodename,@ipaddress,@port,@status,@fsize,@ipstatus)", con);
                        cmd.Parameters.AddWithValue("nodename", "A");
                        cmd.Parameters.AddWithValue("ipaddress", haddress);
                        cmd.Parameters.AddWithValue("port", port);
                        cmd.Parameters.AddWithValue("status", status);
                        cmd.Parameters.AddWithValue("fsize", fsize);
                        cmd.Parameters.AddWithValue("ipstatus", ipstatus);
                        int no = cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        cmd = new SqlCommand("insert into ncstatus(nodename) values (@nodename)", con);
                        cmd.Parameters.AddWithValue("nodename", "A");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        ReceiverA ra = new ReceiverA();
                        ra.Show();
                    }
                }


              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void eiverBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if(stb.Equals("Connected"))
                {
                    MessageBox.Show("Already Connected.");
                    return;

                }

                if(MessageBox.Show("Do You Want To Connect B?", "Connect", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    if(stb == "")
                    {

                        cmd = new SqlCommand("Delete from receiver where nodename=@nodename", con);
                        cmd.Parameters.AddWithValue("nodename", "B");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();


                        cmd = new SqlCommand("Delete from ncstatus where nodename=@nodename", con);
                        cmd.Parameters.AddWithValue("nodename", "B");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();




                        string hname = Dns.GetHostName();
                        IPHostEntry ip = Dns.GetHostEntry(hname);
                        //IPHostEntry ip = Dns.GetHostByAddress("192.9.200.130");
                        //  MessageBox.Show(ip.HostName);
                        IPAddress[] i1 = ip.AddressList;
                        IEnumerator ie = i1.GetEnumerator();
                        string haddress = "";
                        if(ie.MoveNext())
                            haddress = ie.Current.ToString();
                        //  textBox1.Text = haddress;
                        string port = "102";
                        string status = "null";
                        string fsize = "0";
                        string ipstatus = "default";


                        cmd = new SqlCommand("insert into receiver values(@nodename,@ipaddress,@port,@status,@fsize,@ipstatus)", con);
                        cmd.Parameters.AddWithValue("nodename", "B");
                        cmd.Parameters.AddWithValue("ipaddress", haddress);
                        cmd.Parameters.AddWithValue("port", port);
                        cmd.Parameters.AddWithValue("status", status);
                        cmd.Parameters.AddWithValue("fsize", fsize);
                        cmd.Parameters.AddWithValue("ipstatus", ipstatus);
                        int no = cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        cmd = new SqlCommand("insert into ncstatus(nodename) values (@nodename)", con);
                        cmd.Parameters.AddWithValue("nodename", "B");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        ReceiverB rb = new ReceiverB();
                        rb.Show();
                    }
                }



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void receiverCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if(stc.Equals("Connected"))
                {
                    MessageBox.Show("Already Connected.");
                    return;

                }

                if(MessageBox.Show("Do You Want To Connect C?", "Connect", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    if(stc == "")
                    {

                        cmd = new SqlCommand("Delete from receiver where nodename=@nodename", con);
                        cmd.Parameters.AddWithValue("nodename", "C");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();


                        cmd = new SqlCommand("Delete from ncstatus where nodename=@nodename", con);
                        cmd.Parameters.AddWithValue("nodename", "C");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();




                        string hname = Dns.GetHostName();
                        IPHostEntry ip = Dns.GetHostEntry(hname);
                        //IPHostEntry ip = Dns.GetHostByAddress("192.9.200.130");
                        //  MessageBox.Show(ip.HostName);
                        IPAddress[] i1 = ip.AddressList;
                        IEnumerator ie = i1.GetEnumerator();
                        string haddress = "";
                        if(ie.MoveNext())
                            haddress = ie.Current.ToString();
                        //  textBox1.Text = haddress;
                        string port = "103";
                        string status = "null";
                        string fsize = "0";
                        string ipstatus = "default";


                        cmd = new SqlCommand("insert into receiver values(@nodename,@ipaddress,@port,@status,@fsize,@ipstatus)", con);
                        cmd.Parameters.AddWithValue("nodename", "C");
                        cmd.Parameters.AddWithValue("ipaddress", haddress);
                        cmd.Parameters.AddWithValue("port", port);
                        cmd.Parameters.AddWithValue("status", status);
                        cmd.Parameters.AddWithValue("fsize", fsize);
                        cmd.Parameters.AddWithValue("ipstatus", ipstatus);
                        int no = cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        cmd = new SqlCommand("insert into ncstatus(nodename) values (@nodename)", con);
                        cmd.Parameters.AddWithValue("nodename", "C");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        ReceiverC rc = new ReceiverC();
                        rc.Show();
                    }
                }



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void receiverDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if(std.Equals("Connected"))
                {
                    MessageBox.Show("Already Connected.");
                    return;

                }

                if(MessageBox.Show("Do You Want To Connect D?", "Connect", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    if(std == "")
                    {

                        cmd = new SqlCommand("Delete from receiver where nodename=@nodename", con);
                        cmd.Parameters.AddWithValue("nodename", "D");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();


                        cmd = new SqlCommand("Delete from ncstatus where nodename=@nodename", con);
                        cmd.Parameters.AddWithValue("nodename", "D");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();




                        string hname = Dns.GetHostName();
                        IPHostEntry ip = Dns.GetHostEntry(hname);
                        //IPHostEntry ip = Dns.GetHostByAddress("192.9.200.130");
                        //  MessageBox.Show(ip.HostName);
                        IPAddress[] i1 = ip.AddressList;
                        IEnumerator ie = i1.GetEnumerator();
                        string haddress = "";
                        if(ie.MoveNext())
                            haddress = ie.Current.ToString();
                        //  textBox1.Text = haddress;
                        string port = "104";
                        string status = "null";
                        string fsize = "0";
                        string ipstatus = "default";


                        cmd = new SqlCommand("insert into receiver values(@nodename,@ipaddress,@port,@status,@fsize,@ipstatus)", con);
                        cmd.Parameters.AddWithValue("nodename", "D");
                        cmd.Parameters.AddWithValue("ipaddress", haddress);
                        cmd.Parameters.AddWithValue("port", port);
                        cmd.Parameters.AddWithValue("status", status);
                        cmd.Parameters.AddWithValue("fsize", fsize);
                        cmd.Parameters.AddWithValue("ipstatus", ipstatus);
                        int no = cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        cmd = new SqlCommand("insert into ncstatus(nodename) values (@nodename)", con);
                        cmd.Parameters.AddWithValue("nodename", "D");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        ReceiverD rd = new ReceiverD();
                        rd.Show();
                    }
                }



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void receiverEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if(ste.Equals("Connected"))
                {
                    MessageBox.Show("Already Connected.");
                    return;

                }

                if(MessageBox.Show("Do You Want To Connect E?", "Connect", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    if(ste == "")
                    {

                        cmd = new SqlCommand("Delete from receiver where nodename=@nodename", con);
                        cmd.Parameters.AddWithValue("nodename", "E");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();


                        cmd = new SqlCommand("Delete from ncstatus where nodename=@nodename", con);
                        cmd.Parameters.AddWithValue("nodename", "E");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();




                        string hname = Dns.GetHostName();
                        IPHostEntry ip = Dns.GetHostEntry(hname);
                        //IPHostEntry ip = Dns.GetHostByAddress("192.9.200.130");
                        //  MessageBox.Show(ip.HostName);
                        IPAddress[] i1 = ip.AddressList;
                        IEnumerator ie = i1.GetEnumerator();
                        string haddress = "";
                        if(ie.MoveNext())
                            haddress = ie.Current.ToString();
                        //  textBox1.Text = haddress;
                        string port = "105";
                        string status = "null";
                        string fsize = "0";
                        string ipstatus = "default";


                        cmd = new SqlCommand("insert into receiver values(@nodename,@ipaddress,@port,@status,@fsize,@ipstatus)", con);
                        cmd.Parameters.AddWithValue("nodename", "E");
                        cmd.Parameters.AddWithValue("ipaddress", haddress);
                        cmd.Parameters.AddWithValue("port", port);
                        cmd.Parameters.AddWithValue("status", status);
                        cmd.Parameters.AddWithValue("fsize", fsize);
                        cmd.Parameters.AddWithValue("ipstatus", ipstatus);
                        int no = cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        cmd = new SqlCommand("insert into ncstatus(nodename) values (@nodename)", con);
                        cmd.Parameters.AddWithValue("nodename", "E");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        ReceiverE re = new ReceiverE();
                        re.Show();
                    }
                }



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void receiverFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if(stf.Equals("Connected"))
                {
                    MessageBox.Show("Already Connected.");
                    return;

                }

                if(MessageBox.Show("Do You Want To Connect F?", "Connect", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    if(stf == "")
                    {

                        cmd = new SqlCommand("Delete from receiver where nodename=@nodename", con);
                        cmd.Parameters.AddWithValue("nodename", "F");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();


                        cmd = new SqlCommand("Delete from ncstatus where nodename=@nodename", con);
                        cmd.Parameters.AddWithValue("nodename", "F");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();




                        string hname = Dns.GetHostName();
                        IPHostEntry ip = Dns.GetHostEntry(hname);
                        //IPHostEntry ip = Dns.GetHostByAddress("192.9.200.130");
                        //  MessageBox.Show(ip.HostName);
                        IPAddress[] i1 = ip.AddressList;
                        IEnumerator ie = i1.GetEnumerator();
                        string haddress = "";
                        if(ie.MoveNext())
                            haddress = ie.Current.ToString();
                        //  textBox1.Text = haddress;
                        string port = "106";
                        string status = "null";
                        string fsize = "0";
                        string ipstatus = "default";


                        cmd = new SqlCommand("insert into receiver values(@nodename,@ipaddress,@port,@status,@fsize,@ipstatus)", con);
                        cmd.Parameters.AddWithValue("nodename", "F");
                        cmd.Parameters.AddWithValue("ipaddress", haddress);
                        cmd.Parameters.AddWithValue("port", port);
                        cmd.Parameters.AddWithValue("status", status);
                        cmd.Parameters.AddWithValue("fsize", fsize);
                        cmd.Parameters.AddWithValue("ipstatus", ipstatus);
                        int no = cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        cmd = new SqlCommand("insert into ncstatus(nodename) values (@nodename)", con);
                        cmd.Parameters.AddWithValue("nodename", "F");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        ReceiverF rf = new ReceiverF();
                        rf.Show();
                    }
                }



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void iDRSMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDRSMaster id = new IDRSMaster();
            id.Show();
        }

        private void selectFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SelectFile sf = new SelectFile();
            sf.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        
            Application.Exit();
        
           
        }

        private void ProjectLink_FormClosed(object sender, FormClosedEventArgs e)
        {
            

        }
   }
}