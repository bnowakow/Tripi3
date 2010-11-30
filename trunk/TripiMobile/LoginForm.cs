using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Msdn.UIFramework;
using System.IO;
using Tripi.wcf;
using System.Threading;

namespace Tripi
{
    public partial class LoginForm : UIForm
    {
        private struct UserCredentials
        {
            public string login;
            public string password;
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToogleSIP(object sender, EventArgs e)
        {
            inputPanel.Enabled = !inputPanel.Enabled;
        }

        private void LogInClick(object sender, EventArgs e)
        {
            UserCredentials credentials = new UserCredentials()
            {
                login = tboxLogin.Text,
                password = tboxPassword.Text,
            };

            //Thread thread = new Thread(new ThreadStart(delegate {
                CheckUserCredentials(credentials);
            //}));
            //thread.Start();
        }

        private void LoginUser()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoginUser));
                return;
            }

            User.Login = tboxLogin.Text;
            MainForm form = new MainForm();
            form.ShowDialog();
        }

        private void LoginFailed()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoginFailed));
                return;
            }

            tboxLogin.Text = "";
            tboxPassword.Text = "";
            MessageBox.Show("Incorrect login or password", "Cannot login");
        }

        private void CheckUserCredentials(object param)
        {
            UserCredentials credentials = (UserCredentials)param;
            ServiceManager service = new ServiceManager();
            if (service.LoginUser(credentials.login, credentials.password))
                LoginUser();
            else
                LoginFailed();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            this.MenuBar.LeftMenu = "Exit";
            this.MenuBar.LeftMenuClicked += new EventHandler(ExitApplication);

            this.MenuBar.RightMenu = "SIP";
            this.MenuBar.RightMenuClicked += new EventHandler(ToogleSIP);
        }
    }
}