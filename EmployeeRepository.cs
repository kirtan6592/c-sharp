using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class EmployeeRepository
    {
        public List<Department> getDepartment()
        {
            var departmentList = new List<Department>();
            using (EmployeeDbContext context = new EmployeeDbContext())
            {
                departmentList = context.Departments.ToList();
            }
            return departmentList;
        }
    }
}
