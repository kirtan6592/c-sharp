using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<EmployeeList> Employees { get; set; }
    }

    public class EmployeeList
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string mobile { get; set; }
        public Department Department { get; set; }
    }
}
