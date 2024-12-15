using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AdminServices
{
    /// <summary>
    /// Summary description for A_Services
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class A_Services : System.Web.Services.WebService
    {


        SqlConnection connection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Reusable_project1;Integrated Security=True;Encrypt=False");

        [WebMethod]
        public bool Create_theme(String Name, String Duration, DateTime Deadline, float Budget)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Themes (name,duration,deadline,budget) VALUES (@Name,@Duration,@Deadline,@Budget)", connection);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Duration", Duration);
                cmd.Parameters.AddWithValue("@Deadline", Deadline);
                cmd.Parameters.AddWithValue("@Budget", Budget);
                connection.Open();
                int result = cmd.ExecuteNonQuery();

                bool success = result > 0;
                return success;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        [WebMethod]

        public bool UpdateTheme(int Theme_ID, string Name, String Duration, DateTime Deadline, float Budget)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Themes SET name = @Name , duration = @Duration , deadline = @Deadline , budget = @Budget WHERE themeId = @Theme_ID", connection);
                cmd.Parameters.AddWithValue("@Theme_ID", Theme_ID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Duration", Duration);
                cmd.Parameters.AddWithValue("@Deadline", Deadline);
                cmd.Parameters.AddWithValue("@Budget", Budget);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                bool success = result > 0;
                return success;
            }
            catch { return false; }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        [WebMethod]
        public bool DeleteTheme(int Theme_ID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE  FROM Themes WHERE themeId = @Theme_ID", connection);
                cmd.Parameters.AddWithValue("@Theme_ID", Theme_ID);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                bool success = result > 0;
                return success;
            }
            catch { return false; }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }


        }

        [WebMethod]
        public string AssignReferee(int refereeId, int submissionId)
        {
            string query = "INSERT INTO SubmissionReferees (RefereeId, SubmissionId) VALUES (@RefereeId, @SubmissionId)";
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2OD02U8\\SQLEXPRESS;Initial Catalog=Reuse_db;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@RefereeId", refereeId);
                        cmd.Parameters.AddWithValue("@SubmissionId", submissionId);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Referee assigned successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string UnassignReferee(int refereeId, int submissionId)
        {
            string query = "DELETE FROM SubmissionReferees WHERE RefereeId = @RefereeId AND SubmissionId = @SubmissionId";
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2OD02U8\\SQLEXPRESS;Initial Catalog=Reuse_db;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@RefereeId", refereeId);
                        cmd.Parameters.AddWithValue("@SubmissionId", submissionId);

                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0
                            ? "Referee unassigned successfully."
                            : "No matching record found to unassign.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public DataTable ViewProjectTheme()
        {

            try
            {
                DataTable dt = new DataTable("Themes");
                SqlCommand cmd = new SqlCommand("SELECT themeId,name FROM THEMES", connection);
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }


            }
        }

        [WebMethod]
        public DataTable Ref_id_name_table()
        {
            try
            {
                DataTable dt = new DataTable("Referees");
                SqlCommand cmd = new SqlCommand("SELECT refereesId,Username FROM Referees", connection);
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }


            }
        }

        [WebMethod]
        public DataTable GetThemeDetails(int themeID)
        {
            try
            {
                DataTable dt = new DataTable("Themes");
                SqlCommand cmd = new SqlCommand("SELECT name,duration,budget,deadline FROM THEMES where themeId = @themeID", connection);
                cmd.Parameters.AddWithValue("@ThemeID", themeID);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                connection.Open();
                dataAdapter.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }


            }
        }
    }
    

}


