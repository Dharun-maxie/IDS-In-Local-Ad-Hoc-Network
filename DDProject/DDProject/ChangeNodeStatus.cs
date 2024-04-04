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
    public partial class ChangeNodeStatus : Form
    {
        public ChangeNodeStatus()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rs;
        ConnectionClass c = new ConnectionClass();
        private void ChangeNodeStatus_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(c.GetConnection());
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                cmd = new SqlCommand("select * from receiver where nodename=@nodename", con);
                cmd.Parameters.AddWithValue("nodename", textBox1.Text);
                rs = cmd.ExecuteReader();
                if (rs.Read())
                {
                    textBox2.Text = rs["ipaddress"].ToString();
                    textBox3.Text = rs["port"].ToString();
                    textBox4.Text = rs["status"].ToString();
                    textBox5.Text = rs["fsize"].ToString();
                    textBox6.Text = rs["ipstatus"].ToString();
                    rs.Close();
                    cmd.Dispose();
                }
                else
                {
                    rs.Close();
                    cmd.Dispose();
                    MessageBox.Show("Node Name Not Found.Please Type Correct NodeName.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
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

                string ipstatus = "";
                if(textBox2.Text == haddress)
                    ipstatus = "default";
                else
                    ipstatus = "changed";
               
                cmd = new SqlCommand("update receiver set ipaddress=@ipaddress,port=@port,status=@status,fsize=@fsize,ipstatus=@ipstatus where nodename=@nodename", con);
                cmd.Parameters.AddWithValue("ipaddress", textBox2.Text);
                cmd.Parameters.AddWithValue("port", textBox3.Text);
                cmd.Parameters.AddWithValue("status", textBox4.Text);
                cmd.Parameters.AddWithValue("fsize", textBox5.Text);
               // cmd.Parameters.AddWithValue("ipstatus", textBox6.Text);

                cmd.Parameters.AddWithValue("ipstatus", ipstatus );
                cmd.Parameters.AddWithValue("nodename", textBox1.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Node Status Updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox1.Focus();
        }
    }
}