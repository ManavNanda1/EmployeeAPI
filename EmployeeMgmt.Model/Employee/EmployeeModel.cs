using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgmt.Model.Employee
{
    public class EmployeeModel
    {
        [Key]
        public int EmpId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(150)]
        public string EmpName { get; set; }

        [Required]
        [EmailAddress]
        [MinLength(8)]
        [MaxLength(150)]

        public string EmpEmail { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(15)]
        [DataType(DataType.Password)]
        public string EmpPassword { get; set; }

        [Required]
        public string EmpGender { get; set; }

        [Required]
        public decimal EmpSalary { get; set; }
    }
}
