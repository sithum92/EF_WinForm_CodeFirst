using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_WinForm_CodeFirst
{
   public class Employee
    {

        [Key]
        public int EmpID { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string DOB { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(255)]
        public string ImageURL { get; set; }

    }
}
