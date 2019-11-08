using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApplication1
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("name=EmployeeDbContext")
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeList> Employees { get; set; }
    }
}
