using EmployeeMgmt.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgmt.Services.Employee
{
    public interface IEmployeeService
    {
        public Task<int> AddEmployee(EmployeeModel EmpData);

        public Task<EmployeeModel> UserEmailCheck(EmployeeModel EmpData);

        public Task<List<EmployeeModel>> GetAllEmployee();

        public Task<int> DeleteEmployee(int Id);

        public Task<EmployeeModel> GetEmployeeById(int Id);
    }
}
