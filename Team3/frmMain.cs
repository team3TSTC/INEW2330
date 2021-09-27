﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team3
{
    public partial class frmMain : Form
    {
        public static string message = "An error has occurred in the program.";
        int intToggle = 0;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Image myImage = new Bitmap(@"taco.jpg");
            this.BackgroundImage = myImage;

        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            frmNewAccount account = new frmNewAccount();
            this.Hide();
            account.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string strUserName = tbxLogin.Text.Trim();
                string strPassword = tbxPassword.Text.Trim();
                if (strUserName == "")
                {
                    MessageBox.Show("LogIn cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (strPassword == "")
                {
                    MessageBox.Show("Password cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Logon.Verify(strUserName, strPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbxEye_Click(object sender, EventArgs e)
        {
            if (intToggle % 2 == 0)
            {
                tbxPassword.PasswordChar = '\0';
                intToggle++;
            }
            else
            {
                tbxPassword.PasswordChar = '*';
                intToggle++;
            }
        }

        private void lblForgot_Click(object sender, EventArgs e)
        {
            string strLogin = tbxLogin.Text.Trim();
            try
            {
                if (tbxLogin.Text == "")
                {
                    MessageBox.Show("Login cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Logon.VerifyLogon(strLogin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
