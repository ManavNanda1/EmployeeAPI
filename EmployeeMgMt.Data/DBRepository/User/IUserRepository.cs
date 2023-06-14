using EmployeeMgmt.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgMt.Data.DBRepository.User
{
    public interface IUserRepository
    {
        public Task<LoginResponse> UserLogin(LoginModel LogData);
    }
}
