using Dapper;
using EmployeeMgmt.Common.CommonMethods.StoreProcedures;
using EmployeeMgmt.Model.DataConf;
using EmployeeMgmt.Model.Employee;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgMt.Data.DBRepository.Employee
{
    public class EmployeeRepo:BaseRepository ,IEmployeeRepo
    {
        #region Fields
        private IConfiguration _config;
        #endregion

        #region Constructor 
        public EmployeeRepo(IConfiguration config, IOptions<DataConfig> dataConfig) : base(config)
        {
            _config = config;
        }

        #endregion

        #region  Add Employee

        public async Task<int> AddEmployee(EmployeeModel EmpData)
        {
            try
            {
             
                var param = new DynamicParameters();
                param.Add("@Empname", EmpData.EmpName);
                param.Add("@EmpEmail", EmpData.EmpEmail);
                param.Add("@EmpGender", EmpData.EmpGender);
                param.Add("@EmpSalary", EmpData.EmpSalary);
                return await QueryFirstOrDefaultAsync<int>(StoredProcedures.AddEmployee, param , commandType: System.Data.CommandType.StoredProcedure);
                
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public async Task<EmployeeModel> UserEmailCheck(EmployeeModel EmpData)
        {
            try
            {
                var Param = new DynamicParameters();
                Param.Add("@Email", EmpData.EmpEmail);
                return await QueryFirstOrDefaultAsync<EmployeeModel>(StoredProcedures.EmailCheck, Param, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        #endregion

        #region GetAllEmployee
        public async Task<List<EmployeeModel>> GetEmployeeList()
        {
            try
            {
                var data = await QueryAsync<EmployeeModel>(StoredProcedures.GetAllEmployee, commandType: System.Data.CommandType.StoredProcedure);
                return data.ToList();

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        #endregion

        #region Delete Employee
        public async Task<int> DeleteEmployee(int Id)
        {
            try
            {
                var Param = new DynamicParameters();
                Param.Add("@Id", Id);
                return await QueryFirstOrDefaultAsync<int>(StoredProcedures.DeleteEmployee, Param, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        #endregion

        #region Get Employee By Id

        public async Task<EmployeeModel> GetEmployeeById(int Id)
        {
            try
            {
                var Param = new DynamicParameters();
                Param.Add("@Id", Id);
                return await QueryFirstOrDefaultAsync<EmployeeModel>(StoredProcedures.GetEmployeeById, Param, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        #endregion
    }
}
