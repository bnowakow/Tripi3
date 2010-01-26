﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Msdn.UIFramework;
using System.IO;

namespace Tripi
{
    public partial class LoginForm : UIForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogInClick(object sender, EventArgs e)
        {
            string login = tboxLogin.Text;
            string password = tboxPassword.Text;

            if (CorrectUserCredentials(login, password))
            {
                MainForm form = new MainForm();
                form.ShowDialog();
                Close();
            }

        }

        private bool CorrectUserCredentials(string login, string password)
        {
            return true;
        }
    }
}