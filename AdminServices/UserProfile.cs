using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminServices
{
    public class UserProfile
    {
        public bool IsSuccess { get; set; }
        public string FullName { get; set; }
        public int Id { get; set; }

        public UserProfile() { }
        public UserProfile(bool isSuccess, string fullName = null, int id = 0)
        {
            IsSuccess = isSuccess;
            FullName = fullName;
            Id = id;
        }
    }
}