using AdminApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = Encrypt.GetSHA256(txtPassword.Text);

            string Role = USERS.Authentication(username, password);


            if(Role != "")
            {
                Admin frm = new Admin();
                frm.Show();
                this.Hide();
            }
            else
            {

            }

        }
    }
}
