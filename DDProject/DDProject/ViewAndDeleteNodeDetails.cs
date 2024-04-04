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
    public partial class ViewAndDeleteNodeDetails : Form
    {
        public ViewAndDeleteNodeDetails()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rs;
        ConnectionClass c = new ConnectionClass();
        SqlDataAdapter adp;
        DataSet ds;
        


        private void ViewAndDeleteNodeDetails_Load(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(c.GetConnection());
                con.Open();
                bindgrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void bindgrid()
        {

            try
            {
                adp = new SqlDataAdapter("select * from receiver", con);
                ds = new DataSet();
                adp.Fill(ds, "xx");
                dataGridView1.DataSource = ds.Tables[0];
                
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

                cmd = new SqlCommand("delete from receiver", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from ncstatus", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                bindgrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                comboBox1.Items.Clear();
                groupBox1.Visible = true;

                cmd = new SqlCommand("select nodename from receiver ", con);
                rs = cmd.ExecuteReader();
                while(rs.Read())
                    comboBox1.Items.Add(rs["nodename"].ToString());
                rs.Close();
                cmd.Dispose();
                bindgrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

      
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                cmd = new SqlCommand("delete from receiver where nodename=@nodename", con);
                cmd.Parameters.AddWithValue("nodename", comboBox1.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                

                cmd = new SqlCommand("delete from ncstatus where nodename=@nodename", con);
                cmd.Parameters.AddWithValue("nodename", comboBox1.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                comboBox1.Items.Remove(comboBox1.SelectedIndex);
                comboBox1.Text = "";

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}