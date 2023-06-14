using EmployeeMgmt.Model.User;
using EmployeeMgMt.Data.DBRepository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgmt.Services.User
{
    public class UserServices:IUserService
    {
        #region Fields
        private readonly IUserRepository UserObj;
        #endregion

        #region Constructor
        public UserServices(IUserRepository _UserObj)
        {
            UserObj = _UserObj;
        }

        #endregion

        #region Methods
        public async Task<LoginResponse> UserLogin(LoginModel LogData)
        {
            try
            {
                return await UserObj.UserLogin(LogData);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        #endregion
    }
}
