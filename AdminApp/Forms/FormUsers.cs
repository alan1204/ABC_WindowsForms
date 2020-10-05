using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AdminApp.Models;

namespace AdminApp.Forms
{
    public partial class FormUsers : Form
    {
        public FormUsers()
        {
            InitializeComponent();
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = USERS.FillRoles();
            cmbRole.DataSource = dt;
            cmbRole.DisplayMember = "Type";
            cmbRole.ValueMember = "ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            USERS User = new USERS(txtUsername.Text, Encrypt.GetSHA256(txtPassword.Text), txtName.Text, txtLastName.Text, cmbRole.SelectedIndex);
            USERS.AddUser(User);
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtName.Text = "";
            txtLastName.Text = "";
            cmbRole.SelectedIndex = 0;
        }
    }
}
