using EmployeeMgmt.Model.Employee;
using EmployeeMgMt.Data.DBRepository.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgmt.Services.Employee
{
    public class EmployeeService:IEmployeeService
    {

        #region Fields
        IEmployeeRepo EmployeeObj;
        #endregion

        #region Constructor
        public EmployeeService(IEmployeeRepo _EmpObj) {
            EmployeeObj = _EmpObj;
        }

        #endregion

        #region Methods 

        public async Task<int> AddEmployee(EmployeeModel EmpData)
        {
            try
            {
                return await EmployeeObj.AddEmployee(EmpData);
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
                return await EmployeeObj.UserEmailCheck(EmpData);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<List<EmployeeModel>> GetAllEmployee()
        {
            try
            {
                return await EmployeeObj.GetEmployeeList();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public async Task<int> DeleteEmployee(int Id)
        {
            try
            {
                return await EmployeeObj.DeleteEmployee(Id);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public async Task<EmployeeModel> GetEmployeeById(int Id)
        {
            try
            {
                return await EmployeeObj.GetEmployeeById(Id);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        #endregion
    }
}
