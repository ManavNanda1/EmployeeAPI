using EmployeeMgmt.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgmt.Services.User
{
    public interface IUserService
    {
        public Task<LoginResponse> UserLogin(LoginModel LogData);
    }
}
