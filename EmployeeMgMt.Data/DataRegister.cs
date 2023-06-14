using EmployeeMgMt.Data.DBRepository.Employee;
using EmployeeMgMt.Data.DBRepository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgMt.Data
{
    public class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var type = new Dictionary<Type, Type>()
            {
                 { typeof(IUserRepository), typeof(UserRepository) },
                 { typeof(IEmployeeRepo), typeof(EmployeeRepo) }
              

            };
            return type;
        }
    }
}
