using Reusable_project_Form_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reusable_project_Form_
{
    public partial class Login : Form
    {


        SqlConnection Connection = new SqlConnection("Data Source=DESKTOP-2OD02U8\\SQLEXPRESS;Initial Catalog=Reuse_db;Persist Security Info=True;User ID=sa;Password=DC@122180");

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reusable_projectDataSet.Themes' table. You can move, or remove it, as needed.
            // this.themesTableAdapter.Fill(this.reusable_projectDataSet.Themes);

        }


        private void logginbtn_Click(object sender, EventArgs e)
        {
            string email = emailTextbox.Text;
            string password = PasswordTextbox.Text;


            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            ValidatorService.ValidatorServiceSoapClient client = new ValidatorService.ValidatorServiceSoapClient();

            var response = client.ValidateUser(email, password);



            if (response.Role != null)
            {
                MessageBox.Show($"Welcome, {response.Role}!");

                if (response.Role == "Admin")
                {
                    Admin Admin = new Admin(response.UserId);
                    Admin.Show();
                }
                else if (response.Role == "User")
                {
                    MainUserMenu MainUserMenu = new MainUserMenu(response.UserId);
                    MainUserMenu.Show();
                }
                else if (response.Role == "Referee")
                {
                    //Referee Referee = new Referee(userId);
                    //Referee.Show();
                }


                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
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

        private void emailTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void ShowPasswordCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            PasswordTextbox.UseSystemPasswordChar = !PasswordTextbox.UseSystemPasswordChar;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
