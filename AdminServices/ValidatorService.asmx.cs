using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AdminServices
{
    /// <summary>
    /// Summary description for ValidatorService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ValidatorService : System.Web.Services.WebService
    {
        private readonly string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=Reusable_project1;Integrated Security=True;Encrypt=False";

        [WebMethod]
        public UserValidationResponse ValidateUser(string email, string password)
        {
            UserValidationResponse response = new UserValidationResponse
            {
                UserId = -1,
                FullName = null,
                Email = email,
                Role = null,
                Message = "Invalid credentials."
            };

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check for Admin
                    SqlCommand adminCmd = new SqlCommand("SELECT adminId, username FROM Admin WHERE Email = @Email AND Password = @Password", connection);
                    adminCmd.Parameters.AddWithValue("@Email", email);
                    adminCmd.Parameters.AddWithValue("@Password", password);

                    using (var adminReader = adminCmd.ExecuteReader())
                    {
                        if (adminReader.Read()) // Check if any row was returned
                        {
                            response.UserId = Convert.ToInt32(adminReader["adminId"]);
                            response.FullName = adminReader["username"].ToString();
                            response.Role = "Admin";
                            response.Message = "Authentication successful.";
                            return response;
                        }
                    }

                    // Check for User
                    SqlCommand userCmd = new SqlCommand("SELECT userId, fullname FROM Users WHERE Email = @Email AND Password = @Password", connection);
                    userCmd.Parameters.AddWithValue("@Email", email);
                    userCmd.Parameters.AddWithValue("@Password", password);

                    using (var userReader = userCmd.ExecuteReader())
                    {
                        if (userReader.Read()) // Check if any row was returned
                        {
                            response.UserId = Convert.ToInt32(userReader["userId"]);
                            response.FullName = userReader["fullname"].ToString();
                            response.Role = "User";
                            response.Message = "Authentication successful.";
                            return response;
                        }
                    }

                    // Check for Referee
                    SqlCommand refCmd = new SqlCommand("SELECT refereesId, Fullname FROM Referees WHERE Email = @Email AND Password = @Password", connection);
                    refCmd.Parameters.AddWithValue("@Email", email);
                    refCmd.Parameters.AddWithValue("@Password", password);

                    using (var refReader = refCmd.ExecuteReader())
                    {
                        if (refReader.Read()) // Check if any row was returned
                        {
                            response.UserId = Convert.ToInt32(refReader["refereesId"]);
                            response.FullName = refReader["Fullname"].ToString();
                            response.Role = "Referee";
                            response.Message = "Authentication successful.";
                            return response;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = "An error occurred: " + ex.Message;
            }

            return response;
        }


        public class UserValidationResponse
        {
            public int UserId { get; set; }

            public string FullName { get; set; }

            public string Email { get; set; }
            public string Role { get; set; }
            public string Message { get; set; }
        }
    }
}
