
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace AdminServices
{



    /// <summary>
    /// Summary description for U_Services
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]


    public class U_Services : System.Web.Services.WebService
    {
        SqlConnection connection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Reusable;Integrated Security=True;Encrypt=False");


        [WebMethod]
        public bool CreateAccount(string username, string email, string password, string role)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO UsersTable (username, email, password, role) VALUES (@username, @email, @password, @role)", connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@role", role);

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
        public UserProfile LogIn(string email, string password)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT username, user_id, role FROM UsersTable WHERE password = @password AND email = @email", connection))
                {
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@email", email);

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read()) // Read the first row
                        {
                            string username = reader["username"].ToString();
                            int id = Convert.ToInt32(reader["user_id"]);
                            string role = reader["role"].ToString();

                            // Ensure 'role' is not null before creating the UserProfile
                            if (role == null) throw new Exception("Role is missing from the database record.");

                            return new UserProfile(true, username, id, role);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Log the exception message for debugging purposes
                Console.WriteLine("Error during login: " + e.Message);
                throw new Exception(e.ToString());
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return new UserProfile(false, string.Empty, 0, string.Empty);
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

        public bool DeleteProposal(int submissionid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Submissions WHERE submissionId = @submissionid ", connection);
                cmd.Parameters.AddWithValue("@submissionid", submissionid);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                bool success = result > 0;
                return success;
            }
            catch { return false; }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) { connection.Close(); }
            }
        }


        [WebMethod]
        public bool UpdateProposal(int submissionid, int userid, string proposal)
        {
            try
            {
                // Query to check if the submission belongs to the given user
                string checkQuery = "SELECT COUNT(1) FROM Submissions WHERE submissionId = @submissionid AND userid = @userid";

                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@submissionid", submissionid);
                checkCmd.Parameters.AddWithValue("@userid", userid);

                connection.Open();

                // Check if the record exists for the given submissionId and userId
                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    // If no matching record is found, return false
                    return false;
                }

                // Proceed to update the proposal if the user owns the submission
                string updateQuery = "UPDATE Submissions SET proposal = @proposal WHERE submissionId = @submissionid";
                SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                updateCmd.Parameters.AddWithValue("@submissionid", submissionid);
                updateCmd.Parameters.AddWithValue("@proposal", proposal);

                int result = updateCmd.ExecuteNonQuery();
                return result > 0; // Return true if at least one row is affected
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
        public bool SubmitProposal(int userid, int themeid, string title, string proposal)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Submissions (userid,themeid,title,proposal) VALUES (@userid, @themeid, @title, @proposal) ", connection);
                cmd.Parameters.AddWithValue("@proposal", proposal);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@themeid", themeid);
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
        public bool SubmitReport(int userID, int submissionid, string title, string report, DateTime uploaddate)
        {
            try
            {
           
                SqlCommand cmd = new SqlCommand("INSERT INTO Reports (userID, SubmissionID,title,reportcontent,uploaddate) VALUES (@userID,@submissionid, @title, @report, uploaddate) ", connection);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@submissionid", submissionid);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@report", report);
                cmd.Parameters.AddWithValue("@uploaddate", uploaddate);
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
        public DataTable GetAcceptedSubmissions(int user_id)
        {
            DataTable dt = new DataTable("Submissions");

            try
            {


                string query = "SELECT * FROM Submissions WHERE status = @Status and userid = @user_id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Status", "accepted");
                    cmd.Parameters.AddWithValue("@user_id", user_id);
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);

            }

            return dt;
        }


        [WebMethod]
        public DataTable GetProposals()
        {
            DataTable dt = new DataTable("Submissions");

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=reusable_proJectDB;Integrated Security=True;Encrypt=False"))
                {
                    connection.Open();


                    string query = @"
                SELECT 
                    s.submissionId, 
                    s.title, 
                    t.name, 
                    s.status 
                FROM 
                    Submissions s
                INNER JOIN 
                    Themes t 
                ON 
                    s.themeId = t.themeId";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                        {
                            dataAdapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        [WebMethod]
        public DataTable GetSubBeforeDeadline(int userId)
        {
            DataTable dt = new DataTable("Submissions");

            try
            {
                // Updated query to filter submissions by the provided userid
                string query = @"
        SELECT 
            s.submissionId, 
            s.userid, 
            s.proposal, 
            s.status, 
            s.title 
        FROM 
            submissions s
        INNER JOIN 
            themes t 
        ON 
            s.themeid = t.themeid
        WHERE 
            t.deadline > GETDATE() AND s.userid = @UserId"; // Added condition for userid

                SqlCommand cmd = new SqlCommand(query, connection);

                // Add the userid parameter to prevent SQL injection
                cmd.Parameters.AddWithValue("@UserId", userId);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return dt;
        }



    }

}


