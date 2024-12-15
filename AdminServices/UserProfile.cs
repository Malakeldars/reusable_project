using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminServices
{
    public class UserProfile
    {
        public bool IsSuccess { get; set; }
        public string Username { get; set; }
        public int Id { get; set; }
        public string Role { get; set; }

        public UserProfile() { }

        public UserProfile(bool isSuccess, string userName, int id, string role)
        {
            IsSuccess = isSuccess;
            Username = userName;
            Id = id;
            Role = role ?? throw new ArgumentNullException(nameof(role), "Role cannot be null.");
        }
    }
}
