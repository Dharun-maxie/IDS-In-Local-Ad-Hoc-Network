using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DDProject
{
    class ConnectionClass
    {
        public string GetConnection()
        {
           // return "user id=sa;password=ss1tec#;database=ddos;data source=good";

            string fullpath = Application.StartupPath;
            //MessageBox.Show(fullpath);
            string fullpath1 = fullpath.Substring(0, fullpath.IndexOf("\\bin"));
            // MessageBox.Show(fullpath1);
            //fullpath1 = fullpath1 + "\\Upload";
            return "Data Source=.\\SQLEXPRESS;AttachDbFilename="+fullpath1 +"\\DDOS.mdf;Integrated Security=True;User Instance=True";
        }
    }
}
