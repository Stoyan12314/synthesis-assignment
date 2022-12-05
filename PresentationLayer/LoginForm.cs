using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BuisnessLogicLayer;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
namespace PresentationLayer
{
    public partial class LoginForm : Form
    {
        private IUserManager userManager;
        public LoginForm()
        {
            InitializeComponent();
            userManager = new UserManager(new DBUser());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if(!String.IsNullOrEmpty(tbEmail.Text) && !String.IsNullOrEmpty(tbPassword.Text))
            {
                string email = tbEmail.Text;
                string password = tbPassword.Text;
          
                bool checkEmail = Regex.IsMatch(email, ".*[@].*");
                if (checkEmail is true)
                {
                    if (userManager.CheckLogin(password, email) == null)
                    {
                        MessageBox.Show("Invalid login");
                    }
                    else
                    {
                        MainForm form = new MainForm();
                        this.Hide();
                        form.ShowDialog();
                        
                       

                    }

                }
                else
                {
                    MessageBox.Show("Enter correct email format using '@'!");
                }
            }
        }
    }
}
