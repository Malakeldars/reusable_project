
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
         SqlConnection connection = new SqlConnection("Data Source=LAPTOP-77LHTH18\\SQLEXPRESS01;Initial Catalog=Reusable_project;Integrated Security=True;Encrypt=False");


        [WebMethod]
        public bool CreateAccount( string password,string fullname,string email) {

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (password,email,fullname) VALUES (@password,@email,@fullname)", connection);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@fullname", fullname);
                cmd.Parameters.AddWithValue("@email", email);
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
                if(connection.State == System.Data.ConnectionState.Open)
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
                using (SqlCommand cmd = new SqlCommand("SELECT fullname, userId FROM Users WHERE password = @password AND email = @email", connection))
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
                SqlCommand cmd = new SqlCommand("DELETE FROM Submissions WHERE submissionId = @submissionid ",connection);
                cmd.Parameters.AddWithValue("@submissionid", submissionid);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                bool success = result > 0;
                return success;
            }
            catch {  return false; }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open) { connection.Close(); }
          }
        }
        [WebMethod]

        public bool UpdateProposal(int submissionid, string proposal)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Submissions SET proposal = @proposal WHERE submissionId = @submissionid", connection);
                cmd.Parameters.AddWithValue("@submissionid", submissionid);
                cmd.Parameters.AddWithValue("@proposal", proposal);
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
        public bool SubmitReport(int submissionid,string title,string report)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Reports (SubmissionID,title,reportcontent) VALUES (@submissionid, @title, @report) ", connection);
                cmd.Parameters.AddWithValue("@submissionid", submissionid);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@report", report);
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

