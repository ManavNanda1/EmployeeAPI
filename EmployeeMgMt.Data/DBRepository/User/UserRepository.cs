using Dapper;
using EmployeeMgmt.Common.CommonMethods.StoreProcedures;
using EmployeeMgmt.Model.DataConf;
using EmployeeMgmt.Model.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgMt.Data.DBRepository.User
{
    public class UserRepository:BaseRepository , IUserRepository
    {
        #region Fields
        private IConfiguration _config;
        #endregion

        #region Constructor 
        public UserRepository(IConfiguration config, IOptions<DataConfig> dataConfig) : base(config)
        {
            _config = config;
        }

        #endregion

        #region Methods

        public async Task<LoginResponse> UserLogin(LoginModel LogData)
        {
            try
            {
                var Param = new DynamicParameters();
                Param.Add("@Email", LogData.Email);
                Param.Add("@Password" , LogData.Password);
                return await QueryFirstOrDefaultAsync<LoginResponse>(StoredProcedures.LoginCheck, Param, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        #endregion
    }
}
