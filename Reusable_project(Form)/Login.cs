﻿using Reusable_project_Form_;
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


        private SqlConnection Connection = new SqlConnection("Data Source=LAPTOP-77LHTH18\\SQLEXPRESS01;Initial Catalog=Reusable_project;Integrated Security=True;Encrypt=False");

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



        // validate and find the user type
        private string ValidateUser(string email, string password, out int userId)
        {
            userId = -1;
            string role = null;

            try
            {
                Connection.Open();

                // Check for Admin
                SqlCommand admincmd = new SqlCommand("SELECT adminId FROM Admin WHERE email = @email AND password = @password", Connection);
                admincmd.Parameters.AddWithValue("@Email", email);
                admincmd.Parameters.AddWithValue("@Password", password);

                var adminresult = admincmd.ExecuteScalar();
                if (adminresult != null)
                {
                    userId = Convert.ToInt32(adminresult);
                    role = "Admin";
                    return role;
                }

                // Check for User
                SqlCommand usercmd = new SqlCommand("SELECT userId FROM Users WHERE email = @email AND password = @password", Connection);
                usercmd.Parameters.AddWithValue("@Email", email);
                usercmd.Parameters.AddWithValue("@Password", password);

                var userresult = usercmd.ExecuteScalar();
                if (userresult != null)
                {
                    userId = Convert.ToInt32(userresult);
                    role = "User";
                    return role;
                }

                // Check for Referee
                SqlCommand refcmd = new SqlCommand("SELECT refereesId FROM Referees WHERE Email = @email AND password = @password", Connection);
                refcmd.Parameters.AddWithValue("@Email", email);
                refcmd.Parameters.AddWithValue("@Password", password);


                var refresult = refcmd.ExecuteScalar();
                if (refresult != null)
                {
                    userId = Convert.ToInt32(refresult);
                    role = "Referee";
                    return role;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {

                if (Connection.State == System.Data.ConnectionState.Open)
                {
                    Connection.Close();
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
