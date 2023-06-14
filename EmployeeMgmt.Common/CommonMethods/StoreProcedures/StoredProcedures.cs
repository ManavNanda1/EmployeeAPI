using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgmt.Common.CommonMethods.StoreProcedures
{
    public class StoredProcedures
    {
        #region User Store Procedures
        public const string LoginCheck = "Sp_LoginCheck";
        public const string EmailCheck = "Sp_EmailCheck";
        #endregion

        #region Employee Store Procedures
        public const string AddEmployee = "Sp_AddEmployee";
        public const string DeleteEmployee = "Sp_DeleteEmployee";
        public const string GetAllEmployee = "Sp_GetAllEmployees";
        public const string GetEmployeeById = "Sp_GetEmployeeById";
        #endregion
    }
}
