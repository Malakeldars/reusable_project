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
    public partial class update_delete_proposal : Form
    {
        private int loggedInUserId;
        private SqlConnection Connection = new SqlConnection("Data Source=DESKTOP-2OD02U8\\SQLEXPRESS;Initial Catalog=Reuse_db;Persist Security Info=True;User ID=sa;Password=DC@122180");
        public update_delete_proposal(int userId)
        {
            InitializeComponent();
            loggedInUserId = userId;
        }

        private void update_delete_proposal_Load(object sender, EventArgs e)
        {
            LoadUserTitles(loggedInUserId);
            LoadThemes();
            LoadSubmissions();
        }

        private void LoadUserTitles(int userId)
        {
            string query = "SELECT submissionId, title FROM Submissions WHERE userid = @UserId";

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
                adapter.SelectCommand.Parameters.AddWithValue("@UserId", userId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                titleComboBox.DataSource = dt;
                titleComboBox.DisplayMember = "title";
                titleComboBox.ValueMember = "submissionId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading titles: " + ex.Message);
            }
        }


        private void LoadThemes()
        {
            string query = "SELECT themeId, name, deadline FROM Themes";

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                themeComboBox.DataSource = dt;
                themeComboBox.DisplayMember = "Name";
                themeComboBox.ValueMember = "ThemeId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading themes: " + ex.Message);
            }
        }

        private void LoadSubmissions()
        {
            string query = "SELECT submissionId,title, proposal, themeId, Status FROM Submissions WHERE UserId = @UserId";

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
                adapter.SelectCommand.Parameters.AddWithValue("@UserId", loggedInUserId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading submissions: " + ex.Message);
            }
        }



        private void titleComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (titleComboBox.SelectedValue != null)
            {
                int submissionId = titleComboBox.SelectedIndex;

                string query = "SELECT Proposal, ThemeId FROM Submissions WHERE SubmissionId = @SubmissionId";

                try
                {
                    SqlCommand cmd = new SqlCommand(query, Connection);
                    cmd.Parameters.AddWithValue("@SubmissionId", submissionId);

                    Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        proposalTextBox.Text = reader["Proposal"].ToString();
                        themeComboBox.SelectedValue = Convert.ToInt32(reader["ThemeId"]);
                        UpdateDeadlineFromTheme();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading submission details: " + ex.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        private void themeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDeadlineFromTheme();
        }

        private void UpdateDeadlineFromTheme()
        {
            if (themeComboBox.SelectedValue != null)
            {
                int themeId = themeComboBox.SelectedIndex;

                string query = "SELECT Deadline FROM Themes WHERE themeId = @ThemeId";

                try
                {
                    SqlCommand cmd = new SqlCommand(query, Connection);
                    cmd.Parameters.AddWithValue("@ThemeId", themeId);

                    Connection.Open();
                    object deadline = cmd.ExecuteScalar();

                    if (deadline != null)
                    {
                        deadlinePicker.Value = Convert.ToDateTime(deadline);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating deadline: " + ex.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int submissionId = Convert.ToInt32(titleComboBox.SelectedValue);
            int themeId = Convert.ToInt32(themeComboBox.SelectedValue);

            string query = "UPDATE Submissions SET proposal = @Proposal, themeId = @ThemeId WHERE submissionId = @SubmissionId";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, Connection))
                {
                    cmd.Parameters.AddWithValue("@SubmissionId", submissionId);
                    cmd.Parameters.AddWithValue("@Proposal", proposalTextBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@ThemeId", themeId);

                    Connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Submission updated successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating submission: " + ex.Message);
            }
            finally
            {
                Connection.Close();
                LoadUserTitles(loggedInUserId);
                LoadSubmissions();
            }
        }


    }
}

