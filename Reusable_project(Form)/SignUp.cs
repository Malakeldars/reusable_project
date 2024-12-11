using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reusable_project_Form_
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void SignUpbtn_Click_1(object sender, EventArgs e)
        {
            string name = UserNametextbox.Text;
            string email = emailTextbox.Text;
            string password = PasswordTextbox.Text;
            string userType = usertypeDropDown.SelectedIndex.ToString();



            if (userType == "0")
            {
                U_ServiceReference.U_ServicesSoapClient userService = new U_ServiceReference.U_ServicesSoapClient();

                bool success = userService.CreateAccount(password, name, email);

                if (success)
                {
                    MessageBox.Show("User account created successfully!");
                    //SwitchToSignInPage();
                    var login = new Login();
                    login.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to create User account.");
                }
            }

            else if (userType == "1")
            {
                R_ServiceReference.R_ServiceSoapClient RefereeService = new R_ServiceReference.R_ServiceSoapClient();

                bool success = RefereeService.CreateAccount(name, password, email);
                if (success)
                {
                    MessageBox.Show("Referee account created successfully!");
                    //SwitchToSignInPage();
                    var login = new Login();
                    login.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to create Referee account.");
                }
            }
            else
            {
                MessageBox.Show("Please select a valid user type.");
            }




        }

        private void SignUpPagebtn_Click_1(object sender, EventArgs e)
        {
            var SignUp = new SignUp();
            SignUp.Show();
            this.Hide();
        }

        private void signInPagebtn_Click_1(object sender, EventArgs e)
        {
            var login = new Login();
            login.Show();
            this.Hide();
        }

        private void ShowPasswordCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            PasswordTextbox.UseSystemPasswordChar = !PasswordTextbox.UseSystemPasswordChar;

        }

        private void usertypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
