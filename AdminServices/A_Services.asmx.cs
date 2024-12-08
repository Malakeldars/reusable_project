using System;
using System.Collections.Generic;
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

        private SqlConnection connection = new SqlConnection("Data Source=LAPTOP-77LHTH18\\SQLEXPRESS01;Initial Catalog=Reusable_project;Integrated Security=True;");
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
        public bool AssignRefereeToProject(int projectId, int refereeId)
        {
            // Validate the inputs
            if (projectId <= 0 || refereeId <= 0)
            {
                return false;
            }

            try
            {
                using (connection)
                {
                    // Open the connection to the database
                    connection.Open();

                    // SQL query to insert a referee assignment
                    string query = "INSERT INTO ProjectReferees (ProjectID, RefereeID) VALUES (@ProjectID, @RefereeID)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SQL query
                        cmd.Parameters.AddWithValue("@ProjectID", projectId);
                        cmd.Parameters.AddWithValue("@RefereeID", refereeId);

                        // Execute the query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // If one row was inserted, the assignment was successful
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as necessary
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}

