﻿using System;
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
        public bool AssignRefereeToProject(int projectId, int refereeId)
        {
            if (projectId <= 0 || refereeId <= 0)
            {
                return false;
            }

            try
            {
                using (connection)
                {
                    connection.Open();

                    string query = "INSERT INTO ProjectReferees (ProjectID, RefereeID) VALUES (@ProjectID, @RefereeID)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProjectID", projectId);
                        cmd.Parameters.AddWithValue("@RefereeID", refereeId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}

