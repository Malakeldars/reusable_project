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
using static Reusable_project_Form_.SubmitProposal;

namespace Reusable_project_Form_
{
    public partial class SubmitReport1 : Form

    {
        int _userId;
        public SubmitReport1(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void IDTextbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {

                string inputText = IDTextbox.Text?.Trim();
                if (!string.IsNullOrEmpty(inputText))
                {
                    if (int.TryParse(inputText, out int submissionId))
                    {
                        string reportTitle = TitleTextbox.Text;
                        U_ServiceReference.U_ServicesSoapClient s = new U_ServiceReference.U_ServicesSoapClient();
                        bool submissionSuccess = s.SubmitReport(submissionId, reportTitle, ReportTextbox.Text);

                        if (submissionSuccess)
                        {
                            using (SqlConnection connection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Reusable_project1;Integrated Security=True;Encrypt=False"))
                            {
                                string query = "SELECT MAX(ReportId) AS ReportId FROM Reports WHERE SubmissionId = @submissionId";
                                SqlCommand cmd = new SqlCommand(query, connection);
                                cmd.Parameters.AddWithValue("@submissionId", submissionId);
                                connection.Open();
                                SqlDataReader reader = cmd.ExecuteReader();
                                if (reader.Read() && reader["ReportId"] != DBNull.Value)
                                {
                                    int reportId = (int)reader["ReportId"];
                                    MessageBox.Show("Your report ID is: " + reportId.ToString());
                                }
                                else
                                {
                                    MessageBox.Show("Submission ID not found in the database.");
                                }
                                reader.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Submission failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid numeric submission ID.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter your project's submission ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MainUserMenu mainUserMenu= new MainUserMenu(_userId);
            mainUserMenu.Show();
            this.Hide();
        }

        private void SubmitReport1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
