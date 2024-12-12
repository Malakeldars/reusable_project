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
    public partial class SubmitProposal : Form
    {
        int _userId;
        public SubmitProposal(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }
        public class Theme
        {
            public int ThemeId { get; set; }
            public string Name { get; set; }
        }

        private void SubmitProposal_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2OD02U8\\SQLEXPRESS;Initial Catalog=Reuse_db;Persist Security Info=True;User ID=sa;Password=DC@122180"))
                {
                    string query = "SELECT themeId, name FROM Themes;";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ThemesCombobox.Items.Add(new Theme
                        {
                            ThemeId = Convert.ToInt32(reader["themeId"]),
                            Name = reader["name"].ToString()
                        });
                    }
                    ThemesCombobox.ValueMember = "ThemeId";
                    ThemesCombobox.DisplayMember = "Name";
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }

        }
        private void ThemesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ThemesCombobox.SelectedItem is Theme selectedTheme)
                {
                    string proposalText = ProposalTextbox.Text;
                    string titleText = TitleTextbox.Text;
                    int themeId = selectedTheme.ThemeId;
                    UserServiceReference.U_ServicesSoapClient s = new UserServiceReference.U_ServicesSoapClient();
                    bool submissionSuccess = s.SubmitProposal(1, themeId,titleText, proposalText);

                    if (submissionSuccess)
                    {
                        using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2OD02U8\\SQLEXPRESS;Initial Catalog=Reuse_db;Persist Security Info=True;User ID=sa;Password=DC@122180"))
                        {
                            string query = "SELECT MAX(submissionId) AS submissionId FROM Submissions WHERE themeId = @themeId;";
                            SqlCommand cmd = new SqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@themeId", themeId);
                            connection.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                int submissionId = (int)reader["submissionId"];
                                MessageBox.Show("Your submission ID is: " + submissionId.ToString());
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
                    MessageBox.Show("Please select a theme");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MainUserMenu mainUserMenu = new MainUserMenu(_userId);
            mainUserMenu.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
