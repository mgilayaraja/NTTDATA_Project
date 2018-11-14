using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NTTDATA_Web.Models
{
    public partial class Employee
    {
        public int Employee_Code { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public decimal Salary { get; set; }
        public System.DateTime Created_Time_Stamp { get; set; }
        public System.DateTime Updated_Time_Stamp { get; set; }
    }
}