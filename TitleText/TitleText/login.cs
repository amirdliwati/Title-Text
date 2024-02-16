using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using mylibrary;

namespace TitleText
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (textBox1.Text == "" || textBox2.Text == "")
            {


                errorProvider1.SetError(textBox1, "Enter user name");
                errorProvider1.SetError(textBox2, "Enter Password");


            }
            else
            {
                Class1 cc = new Class1();
                SqlConnection mycon = new SqlConnection(cc.y);
                mycon.Open();
                SqlCommand mycom2 = new SqlCommand("loginuser ", mycon);
                SqlParameter p1 = new SqlParameter("@user", textBox1.Text);
                SqlParameter p2 = new SqlParameter("@pass", textBox2.Text);
                mycom2.CommandType = CommandType.StoredProcedure;
                mycom2.Parameters.Add(p1);
                mycom2.Parameters.Add(p2);
                SqlDataReader myreader = mycom2.ExecuteReader();
                if (myreader.HasRows == false)
                {


                    errorProvider1.SetError(button1, "User name Or Password are wrong");

                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    menu f = new menu();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    f.ShowDialog();
                    
                }

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
