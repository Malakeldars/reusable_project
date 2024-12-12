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

    public partial class assign_ref_project : Form
    {
        private int _adminId;

        private SqlConnection Connection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Reusable_project1;Integrated Security=True;Encrypt=False");

        public assign_ref_project(int adminId)
        {
            InitializeComponent();
            _adminId = adminId;
       

        }
        private void assign_ref_project_Load(object sender, EventArgs e)
        {
            LoadReferees();
            LoadSubmissions();
            LoadAssignments();
        }
        private void LoadReferees()
        {
            string query = "SELECT refereesId, username FROM Referees";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                Ref_combobox.DataSource = dt;
                Ref_combobox.DisplayMember = "username";
                Ref_combobox.ValueMember = "refereesId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading referees: " + ex.Message);
            }
        }

        private void LoadSubmissions()
        {
            string query = "SELECT submissionId, title FROM Submissions WHERE status = 'Pending'";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    submit_combobox.DataSource = dt;
                    submit_combobox.DisplayMember = "title";
                    submit_combobox.ValueMember = "submissionId";
                }
                else
                {
                    submit_combobox.DataSource = null;
                    MessageBox.Show("No submissions with 'Pending' status found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading submissions: " + ex.Message);
            }
        }
            private void LoadAssignments()
        {
            string query = @"
            SELECT sr.RefereeID, r.username AS Username, sr.SubmissionId, s.title AS title
            FROM SubmissionReferees sr
            JOIN Referees r ON sr.RefereeId = r.refereesId
            JOIN Submissions s ON sr.submissionId = s.SubmissionId";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading assignments: " + ex.Message);
            }
        }

        private void Assign_Click(object sender, EventArgs e)
        {
            int refereeId = Convert.ToInt32(Ref_combobox.SelectedValue);
            int submissionId = Convert.ToInt32(submit_combobox.SelectedValue);

            string query = "INSERT INTO SubmissionReferees (RefereeId, SubmissionId) VALUES (@RefereeId, @SubmissionId)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, Connection))
                {
                    cmd.Parameters.AddWithValue("@RefereeId", refereeId);
                    cmd.Parameters.AddWithValue("@SubmissionId", submissionId);

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Referee assigned to submission successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error assigning referee: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            LoadAssignments();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Ref_combobox.SelectedValue != null && submit_combobox.SelectedValue != null)
            {
                int refereeId = Convert.ToInt32(Ref_combobox.SelectedValue);
                int submissionId = Convert.ToInt32(submit_combobox.SelectedValue);

                string query = "DELETE FROM SubmissionReferees WHERE RefereeId = @RefereeId AND SubmissionId = @SubmissionId";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, Connection))
                    {
                        cmd.Parameters.AddWithValue("@RefereeId", refereeId);
                        cmd.Parameters.AddWithValue("@SubmissionId", submissionId);

                        Connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Assignment removed successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No matching assignment found to remove.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing assignment: " + ex.Message);
                }
                finally
                {
                    Connection.Close();
                }

                LoadAssignments();
            }
            else
            {
                MessageBox.Show("Please select a referee and a submission to unassign.");
            }
        }

    }

}
