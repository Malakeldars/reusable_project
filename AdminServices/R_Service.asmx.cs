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
        private SqlConnection connection = new SqlConnection("Data Source=LAPTOP-77LHTH18\\SQLEXPRESS01;Initial Catalog=Reusable_project;Integrated Security=True;Encrypt=False");

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

        public bool CreateProposalReviewEmail(int submissionid, string comment, string status, bool requestmod)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Notifications (ProjectID, ModificationComments, NotificationStatus, RequestModification) VALUES (@submissionid, @comment, @status, @requestmod)", connection);
                cmd.Parameters.AddWithValue("@submissionid", submissionid);
                cmd.Parameters.AddWithValue("@comment", comment);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@requestmod", requestmod);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                bool isSuccess = result > 0;
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
