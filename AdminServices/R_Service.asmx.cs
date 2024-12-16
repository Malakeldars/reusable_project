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
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-77LHTH18\\SQLEXPRESS01;Initial Catalog=Reusable_project;Integrated Security=True;Encrypt=False");


        //[WebMethod]
        //public bool CreateAccount(string username, string password, string email)
        //{
        //    SqlCommand cmd = new SqlCommand("INSERT INTO Referees (Username,password,email) VALUES (@username,@password,@email)", connection);
        //    cmd.Parameters.AddWithValue("@username", username);
        //    cmd.Parameters.AddWithValue("@password", password);
        //    cmd.Parameters.AddWithValue("@email", email);
        //    connection.Open();
        //    int result = cmd.ExecuteNonQuery();
        //    bool success = result > 0;
        //    return success;

        //}


        //[WebMethod]
        //public UserProfile LogIn(string email, string password)
        //{
        //    try
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT fullname, refereesId FROM Referees WHERE password = @password AND email = @email", connection))
        //        {
        //            cmd.Parameters.AddWithValue("@password", password);
        //            cmd.Parameters.AddWithValue("@email", email);

        //            connection.Open();
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.HasRows && reader.Read()) // Read the first row
        //                {
        //                    string fullname = reader["fullname"].ToString();
        //                    int id = Convert.ToInt32(reader["userId"]);
        //                    return new UserProfile(true, fullname, id);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.ToString());
        //    }
        //    finally
        //    {
        //        if (connection.State == System.Data.ConnectionState.Open)
        //        {
        //            connection.Close();
        //        }
        //    }

        //    return new UserProfile(false, string.Empty, 0, string.Empty);
        //}

        [WebMethod]
        public List<Proposals> viewAllproposals()
        {
            List<Proposals> proposalList = new List<Proposals>(); // Initialize a list to hold multiple proposals

            try
            {
                using (connection)
                {
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
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) // Loop through all rows in the result set
                            {
                                Proposals proposal = new Proposals
                                {
                                    submissionId = Convert.ToInt32(reader["submissionId"]),
                                    title = reader["title"].ToString(),
                                    status = reader["status"].ToString(),
                                    themename = reader["name"].ToString()
                                    //    UserID = Convert.ToInt32(reader["userid"]),
                                    //    themeid = Convert.ToInt32(reader["themeid"]),
                                    //};
                                };

                                proposalList.Add(proposal); // Add the proposal to the list
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle exception as needed
                Console.WriteLine("Error fetching proposals: " + ex.Message);
                return null; // Return null if an error occurs
            }
            finally
            {
                // Ensure the connection is closed
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return proposalList; // Return the list of proposals
        }


        [WebMethod]
        public DataTable GetProposal(int subid)
        {
            try
            {
                DataTable dt = new DataTable("Submissions");
                SqlCommand cmd = new SqlCommand("SELECT * FROM Submissions WHERE submissionId = @subid", connection);
                cmd.Parameters.AddWithValue("@subid", subid);
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



        [WebMethod]
        public List<Reports> viewAllreports()
        {
            List<Reports> ReportslList = new List<Reports>(); // Initialize a list to hold multiple proposals

            try
            {
                using (connection)
                {
                    string query = @"
                SELECT 
                    ReportId, 
                    title
                     
                FROM 
                   Reports ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) // Loop through all rows in the result set
                            {
                               Reports report = new Reports
                                {
                                   ReportId = Convert.ToInt32(reader["ReportId"]),
                                    title = reader["title"].ToString(),
                                   // role = reader["role"].ToString(),
                                   // themename = reader["name"].ToString()
                                    //    UserID = Convert.ToInt32(reader["userid"]),
                                    //    themeid = Convert.ToInt32(reader["themeid"]),
                                    //};
                                };

                              ReportslList.Add(report); // Add the proposal to the list
                            }
                        }
                    }
                }
        }
            catch (Exception ex)
            {
                // Log or handle exception as needed
                Console.WriteLine("Error fetching proposals: " + ex.Message);
                return null; // Return null if an error occurs
            }
            finally
            {
                // Ensure the connection is closed
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return ReportslList; // Return the list of proposals
        }


        [WebMethod]

        public bool UpdateProposal(int submissionid, string status)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Submissions SET status = @status WHERE submissionId = @submissionid", connection);
                cmd.Parameters.AddWithValue("@submissionid", submissionid);
                cmd.Parameters.AddWithValue("@status", status);
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
    }
}

public class Proposals
{
    public int submissionId { get; set; }
    public int UserID { get; set; }
    public int themeid { get; set; }  // Can be nullable or string type
    public string themename { get; set; }
    public string status { get; set; }  // Nullable decimal
    public string title { get; set; }  // Nullable DateTime
}


public class Reports
{
    public int ReportId { get; set; }
   // public int UserID { get; set; }
   // public int Submissionid { get; set; }  // Can be nullable or string type
    //public string role { get; set; }

    public string title { get; set; }

    // public string username { get; set; }
    //public string status { get; set; }  // Nullable decimal
    //  // Nullable DateTime
}

    