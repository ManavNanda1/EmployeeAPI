using EmployeeMgmt.Services.Employee;
using EmployeeMgmt.Services.User;
using EmployeeMgMt.Data.DBRepository.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgmt.Services
{
    public class RegisterServicesss
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var type = new Dictionary<Type, Type>()
            {
                { typeof(IUserService), typeof(UserServices) },
                {typeof(IEmployeeService), typeof(EmployeeService) }
          

            };
            return type;
        }
    }
}
