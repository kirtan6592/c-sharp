using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public partial class Employee
    {
        public void clear()
        {
            Console.WriteLine("clear");
        }
        partial void t2();
        partial void t()
        {
            throw new NotImplementedException();
        }
    }
}
