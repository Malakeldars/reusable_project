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
        public SubmitReport1()
        {
            InitializeComponent();
        }

        private void IDTextbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IDTextbox != null)
                {
                    int submissionId = int.Parse(IDTextbox.Text);
                    U_ServiceReference.U_ServicesSoapClient s = new U_ServiceReference.U_ServicesSoapClient();
                    bool submissionSuccess = s.SubmitReport(submissionId,ReportTextbox.Text);

                    if (submissionSuccess)
                    {
                        using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2OD02U8\\SQLEXPRESS;Initial Catalog=Reuse_db;Persist Security Info=True;User ID=sa;Password=DC@122180"))
                        {
                            string query = "SELECT MAX(ReportId) AS ReportId FROM Reports WHERE SubmissionId = @submissionId";
                            SqlCommand cmd = new SqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@submissionId", submissionId);
                            connection.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                int reportId = (int)reader["ReportId"];
                                MessageBox.Show("Your report ID is: " + reportId.ToString());
                            }
                            else
                            {
                                MessageBox.Show("Submission ID not found in the database.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Submission failed.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter your project's submission ID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }

        private void SubmitReport1_Load(object sender, EventArgs e)
        {

        }
    }
}
