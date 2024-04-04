using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Collections;

namespace DDProject
{
    public partial class InsertNodeDetails : Form
    {
        public InsertNodeDetails()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rs;

        ConnectionClass c = new ConnectionClass();

        private void InsertNodeDetails_Load(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(comboBox1.SelectedIndex != -1)
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    cmd = new SqlCommand("select nodename from receiver where nodename=@nodename", con);
                    cmd.Parameters.AddWithValue("nodename", comboBox1.SelectedItem.ToString());
                    rs = cmd.ExecuteReader();

                    bool b = rs.Read();
                    rs.Close();
                    cmd.Dispose();
                    if(b)
                    {
                        MessageBox.Show("NodeName Already Found.Please Select Another Node Name.");
                        return;
                    }


                    string hname = Dns.GetHostName();
                    IPHostEntry ip = Dns.GetHostEntry(hname);
                    //IPHostEntry ip = Dns.GetHostByAddress("192.9.200.130");
                    //  MessageBox.Show(ip.HostName);
                    IPAddress[] i1 = ip.AddressList;
                    IEnumerator ie = i1.GetEnumerator();
                    string haddress = "";
                    if(ie.MoveNext())
                        haddress = ie.Current.ToString();
                    textBox1.Text = haddress;

                    cmd = new SqlCommand("Select isnull(max(port),100)+1 from receiver", con);

                    textBox2.Text = cmd.ExecuteScalar().ToString();
                    cmd.Dispose();
                    textBox3.Text = "null";
                    textBox4.Text = "0";
                    textBox5.Text = "default";

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                cmd = new SqlCommand("select nodename from receiver where nodename=@nodename", con);
                cmd.Parameters.AddWithValue("nodename", comboBox1.SelectedItem.ToString());
                rs = cmd.ExecuteReader();

                bool b = rs.Read();
                rs.Close();
                cmd.Dispose();
                if(b)
                {
                    MessageBox.Show("NodeName Already Found.Please Select Another Node Name.");
                    return;
                }

                cmd = new SqlCommand("insert into receiver values(@nodename,@ipaddress,@port,@status,@fsize,@ipstatus)", con);
                cmd.Parameters .AddWithValue ("nodename",comboBox1 .SelectedItem .ToString ());
                cmd.Parameters .AddWithValue ("ipaddress",textBox1 .Text );
                cmd.Parameters .AddWithValue ("port",textBox2 .Text );
                cmd.Parameters .AddWithValue ("status",textBox3 .Text );
                cmd.Parameters .AddWithValue ("fsize",textBox4 .Text );
                cmd.Parameters .AddWithValue ("ipstatus",textBox5 .Text );
                int no=  cmd.ExecuteNonQuery ();
                cmd.Dispose ();
                if(no != 0)
                {
                    cmd = new SqlCommand("insert into ncstatus values(@nodename,@status)", con);
                    cmd.Parameters.AddWithValue("nodename", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("status", "NotConnected");
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                MessageBox.Show("Node Details Inserted.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}