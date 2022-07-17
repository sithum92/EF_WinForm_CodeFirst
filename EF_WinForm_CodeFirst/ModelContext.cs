using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_WinForm_CodeFirst
{
   public class ModelContext: DbContext
    {

        public ModelContext() : base("name = con") { }
        public DbSet<Employee> EmpList { get; set; }

    }
}
