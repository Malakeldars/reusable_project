using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;

namespace AdminServices
{
    /// <summary>
    /// Summary description for R_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class R_Service : System.Web.Services.WebService
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2OD02U8\\SQLEXPRESS;Initial Catalog=Reuse_db;Integrated Security=True");


        [WebMethod]
        public bool CreateAccount(string username, string password, string email)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Referees (Username,password,email) VALUES (@username,@password,@email)", connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@email", email);
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            bool success = result > 0;
            return success;

        }


        [WebMethod]
        public UserProfile LogIn(string email, string password)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT fullname, refereesId FROM Referees WHERE password = @password AND email = @email", connection))
                {
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@email", email);

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read()) // Read the first row
                        {
                            string fullname = reader["fullname"].ToString();
                            int id = Convert.ToInt32(reader["userId"]);
                            return new UserProfile(true, fullname, id);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return new UserProfile(false); // Return failure result
        }


        [WebMethod]
        public DataTable GetProposal(int subid)
        {
            try
            {
               DataTable dt = new DataTable("Submissions");
               SqlCommand cmd = new SqlCommand("SELECT * FROM Submissions WHERE submissionId = @subid", connection);
               cmd.Parameters.AddWithValue("@submissionId", subid);
               connection.Open();
               SqlDataAdapter adapter = new SqlDataAdapter(cmd);
               adapter.Fill(dt);
               return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        [WebMethod]

        public DataTable GetReport(int reportid)
        {
            try
            {
                DataTable dt = new DataTable("Reports");
                SqlCommand cmd = new SqlCommand("SELECT * FROM Reports WHERE ReportId = @reportid", connection);
                cmd.Parameters.AddWithValue("@reportid", reportid);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

        }

        [WebMethod]

        public bool CreateProposalReviewEmail(int submissionid, string comment, string status)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Notifications (ProjectID, ModificationComments, NotificationStatus) VALUES (@submissionid, @comment, @status)", connection);
                SqlCommand cmd1 = new SqlCommand("INSERT INTO Submissions (status) VALUES (@status) WHERE submissionId = @submissionid", connection);
                cmd.Parameters.AddWithValue("@submissionid", submissionid);
                cmd.Parameters.AddWithValue("@comment", comment);
                cmd.Parameters.AddWithValue("@status", status);
                cmd1.Parameters.AddWithValue("@status", status);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                int result1 = cmd1.ExecuteNonQuery();
                bool isSuccess = (result > 0 && result1 > 0);
                return isSuccess;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
