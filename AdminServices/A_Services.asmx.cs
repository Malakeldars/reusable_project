﻿using System;
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


        SqlConnection connection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Reusable;Integrated Security=True;Encrypt=False");

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
            string query = "INSERT INTO SubmissionReferees (user_id, SubmissionId) VALUES (@refereeId, @submissionId)";
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2OD02U8\\SQLEXPRESS;Initial Catalog=Reuse_db;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@refereeId", refereeId);
                        cmd.Parameters.AddWithValue("@submissionId", submissionId);

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
            string query = "DELETE FROM SubmissionReferees WHERE user_id = @RefereeId AND SubmissionId = @SubmissionId";
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
        public Theme GetTheme(int themeId)
        {
            try
            {
                using (connection)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT themeId, name, duration, budget, deadline FROM THEMES WHERE themeId = @themeId", connection))
                    {
                        cmd.Parameters.AddWithValue("@themeId", themeId);

                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read()) // Read the first row
                            {
                                Theme theme = new Theme
                                {
                                    ThemeId = Convert.ToInt32(reader["themeId"]),
                                    Name = reader["name"].ToString(),
                                    Duration = reader["duration"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["duration"]),
                                    Budget = reader["budget"] == DBNull.Value ? (double?)null : Convert.ToDouble(reader["budget"]),
                                    Deadline = reader["deadline"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["deadline"])
                                };

                                return theme;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle exception as needed
                Console.WriteLine("Error fetching theme: " + ex.Message);
                return null;
            }
            finally
            {
                // Ensure the connection is closed
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return null; // Return null if no rows are found
        }


        [WebMethod]
        public DataTable Ref_id_name_table()
        {
            DataTable dt = new DataTable("UsersTable");

            try
            {
                string query = "SELECT user_id, username FROM UsersTable WHERE role = @role";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@role", "referee");
                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return dt;
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
        

    public class Theme
    {
        public int ThemeId { get; set; }
        public string Name { get; set; }
        public int? Duration { get; set; }  // Can be nullable or string type
        public double? Budget { get; set; }  // Nullable decimal
        public DateTime? Deadline { get; set; }  // Nullable DateTime
    }



