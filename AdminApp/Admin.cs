using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class Admin : Form
    {
        private Button currentButton;
        private Form activeForm;
        public Admin()
        {
            InitializeComponent();
        }

        private void ActivateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    //Color color = ColorTranslator.FromHtml("2A9D8F");
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(42, 157, 143); ;
                    currentButton.ForeColor = Color.White;
                }
            }
        }

        private void DisableButton()
        {
            foreach(Control previousBtn in PanelMenu.Controls)
            {
                if(previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(38, 70, 83);
                    previousBtn.ForeColor = Color.Gainsboro;
                }
            }
        }

        private void PanelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender);
            OpenChildForm(new Forms.FormUsers(), sender);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormProducts(), sender);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormCustomers(), sender);
        }

        private void PanelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeForm != null){
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.PanelDesktop.Controls.Add(childForm);
            this.PanelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
