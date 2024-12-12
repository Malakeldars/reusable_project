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
    public partial class Admin : Form
    {

        private int _adminId;


        private SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2OD02U8\\SQLEXPRESS;Initial Catalog=Reuse_db;Persist Security Info=True;User ID=sa;Password=DC@122180"); 
        public Admin(int adminId)
        {
            InitializeComponent();
            _adminId = adminId;
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Login form = new Login();  
        //    form.ShowDialog();
        //    this.Hide();
        //}

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reusable_projectDataSet.Themes' table. You can move, or remove it, as needed.
            //this.themesTableAdapter.Fill(this.reusable_projectDataSet.Themes);
            populate();
        }

        void populate()
        {
            conn.Open();
            string query = "SELECT * FROM Themes ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataTable();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            conn.Close();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
           // try
            {
                A_ServiceReference.A_ServicesSoapClient Admin = new A_ServiceReference.A_ServicesSoapClient();
                Admin.Create_theme(textBox1.Text, textBox2.Text, dateTimePicker1.Value, float.Parse(textBox4.Text));
                MessageBox.Show("Theme Added Successfully");
                populate();
            }
            //catch {

              //  MessageBox.Show("There is an empty filled");
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            A_ServiceReference.A_ServicesSoapClient Admin = new A_ServiceReference.A_ServicesSoapClient();
            try
            {  int id = int.Parse(textBox3.Text);
                Admin.DeleteTheme(id);
                MessageBox.Show("Item Deleted Successfully");
                populate();
            }
            catch
            {
                MessageBox.Show("Please Enter ID");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            A_ServiceReference.A_ServicesSoapClient admin = new A_ServiceReference.A_ServicesSoapClient();

            if(textBox3.Text != null)
            {
                //try
                //{

                    admin.UpdateTheme(int.Parse(textBox3.Text), textBox1.Text, textBox2.Text, dateTimePicker1.Value, float.Parse((textBox4.Text).ToString()));
                    populate();
                    MessageBox.Show("Data Updated");
            }
                //catch
                //{
                //MessageBox.Show("Please Make Sure That You Have Filled All The Required Filleds");
                //}
            //}
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            conn.Open();

           

            try
            {
                int id;
                if (int.TryParse(textBox3.Text, out id))
                {
                    string query = "SELECT * FROM Themes WHERE themeId = @id";

                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        textBox1.Text = reader["name"].ToString();
                        textBox2.Text = reader["duration"].ToString();
                        dateTimePicker1.Value = (DateTime)reader["deadline"];
                        textBox4.Text = reader["Budget"].ToString();

                     
                    }
                    else
                    {
                        MessageBox.Show("No data found for the provided ID.");
                    }

                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Invalid ID. Please enter a valid integer value.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error accessing the database: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            assign_ref_project assign_Ref_Project = new assign_ref_project(_adminId);
            assign_Ref_Project.Show();
            this.Hide();
        }
    }
}
