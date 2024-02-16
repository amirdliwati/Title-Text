using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mylibrary;
using System.Data.SqlClient;
using Microsoft.AnalysisServices.AdomdClient;
using System.Collections;

namespace TitleText
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList words = new ArrayList(); 
             try
            {
                timer1.Enabled = false;
                progressBar1.Increment(100);
            bool s;
            Index indexing = new Index();
            indexing.path = openFileDialog1.FileName;
            indexing.DeleteIndexes();

            label1.Text = " ";
            s = indexing.ArabicIndexes();

            if (s == true)
                label1.Text = "successfully";
            else
                label1.Text = "Faild";

            Class1 cc = new Class1();
            SqlConnection mycon = new SqlConnection(cc.y);
            mycon.Open();
            SqlCommand mycom2 = new SqlCommand("SELECT top 2 Term, CollFreq FROM Dictionary ORDER BY CollFreq DESC", mycon);
            mycom2.CommandType = CommandType.Text;
            SqlDataReader myreader = mycom2.ExecuteReader();
            while (myreader.Read())
            {
                //textBox1.Text = textBox1.Text + " " + myreader[1].ToString();
                words.Add(myreader[0].ToString());
            }
            myreader.Close();
            mycon.Close();

            AdomdConnection conn = new AdomdConnection();
            conn.ConnectionString = "Data Source=localhost;Initial Catalog=TextTitle";

            conn.Open();

            AdomdCommand cmd = new AdomdCommand();
            cmd.Connection = conn;
            cmd.CommandText = String.Format(@"select [TypeTextMM].[Type] from [TypeTextMM]
                             natural prediction join
                      (select '{0}' as [Word1],
		                      '{1}' as [Word2]) as t",
          words[0], words[1]);

            AdomdDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                textBox1.Text = textBox1.Text + " مقالة" + " " + rdr.GetString(0) + " " + "في" + " " + words[0] +" "+ "و" + " " + words[1];
                
            }


            }
             catch { MessageBox.Show("حدث خطأ الرجاء الأنتباه"); }
             timer1.Enabled = true;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ArrayList words = new ArrayList();
            try
            {
                timer1.Enabled = false;
                progressBar1.Increment(100);
                bool s;
                Index indexing = new Index();
                indexing.path = openFileDialog1.FileName;
                indexing.DeleteIndexes();

                label1.Text = " ";
                s = indexing.ArabicIndexes();

                if (s == true)
                    label1.Text = "successfully";
                else
                    label1.Text = "Faild";

                Class1 cc = new Class1();
                SqlConnection mycon = new SqlConnection(cc.y);
                mycon.Open();
                SqlCommand mycom2 = new SqlCommand("SELECT top 2 Term, CollFreq FROM Dictionary ORDER BY CollFreq DESC", mycon);
                mycom2.CommandType = CommandType.Text;
                SqlDataReader myreader = mycom2.ExecuteReader();
                while (myreader.Read())
                {
                    //textBox1.Text = textBox1.Text + " " + myreader[1].ToString();
                    words.Add(myreader[0].ToString());
                }
                myreader.Close();
                mycon.Close();

                AdomdConnection conn = new AdomdConnection();
                conn.ConnectionString = "Data Source=localhost;Initial Catalog=TextTitle";

                conn.Open();

                AdomdCommand cmd = new AdomdCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format(@"select [TypeTextMM].[Type] from [TypeTextMM]
                             natural prediction join
                      (select '{0}' as [Word1],
		                      '{1}' as [Word2]) as t",
              words[0], words[1]);

                AdomdDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    textBox1.Text = textBox1.Text + " مقالة" + " " + rdr.GetString(0) + " " + "في" + " " + words[0] + " " + "و" + " " + words[1];

                }


            }
            catch { MessageBox.Show("حدث خطأ الرجاء الأنتباه"); }
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                progressBar1.Increment(100);
            openFileDialog1.ShowDialog();
            timer1.Enabled = true;

            }
             catch { MessageBox.Show("حدث خطأ الرجاء الأنتباه"); }
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                progressBar1.Increment(100);
                openFileDialog1.ShowDialog();

            }
            catch { MessageBox.Show("حدث خطأ الرجاء الأنتباه"); }
            timer1.Enabled = true;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(MessageBox.Show("هل تريد الخروج؟", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)) == "Yes")
            {
                this.Close();
            }

        }

       

       
    }
}
