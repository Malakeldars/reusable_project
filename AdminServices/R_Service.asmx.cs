using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
        private SqlConnection connection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Reusable_project;Integrated Security=True;");

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
    }
}
