using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgmt.Model.User
{
    public class LoginModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string? UserEmail { get; set; }

        public string? UserPassword { get; set; }

        public string? JWTToken { get; set; }
    }
}
