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
using Entities;
using Entities.Enum;
namespace PresentationLayer
{
    public partial class LoginForm : Form
    {
        ILoginManager loginManager;
        public LoginForm()
        {
            InitializeComponent();
            loginManager = new LoginManager(new DBUser());
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


//\A                  # Start of string
//(?:                 # Start non-capturing group
//[a - z0 - 9!#$%&'*+/=?^_`{|}~-]+  # One or more characters that are allowed in the local part(USER@example.com) of an email address
//(?:                 # Start non-capturing group
//\.                # Literal dot
//[a - z0 - 9!#$%&'*+/=?^_`{|}~-]+ # One or more characters that are allowed in the local part of an email address
//)*                  # End non-capturing group, zero or more times
//@                   # Literal at symbol
//(?:                 # Start non-capturing group
//[a - z0 - 9](?:[a - z0 - 9 -] *[a - z0 - 9]) ?  # One or more characters that are allowed in the domain part of an email address, optionally followed by a hyphen and more characters
//\.                # Literal dot
//)+                  # End non-capturing group, one or more times
//[a - z0 - 9](?:[a - z0 - 9 -] *[a - z0 - 9])?    # One or more characters that are allowed in the domain part of an email address, optionally followed by a hyphen and more characters
//)\Z                  # End of string

                bool checkEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
              
                if (checkEmail is true)
                {
                    User user = loginManager.CheckLogin(password, email);

                    if (user == null)
                    {
                        MessageBox.Show("Invalid login");
                    }
                    else if (user.AccountType == AccountType.Staff)
                    {

                        MainForm form = new MainForm();
                        this.Hide();
                        form.ShowDialog();



                    }
                    else
                    {
                        MessageBox.Show("Can't log in with customers' account");
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
