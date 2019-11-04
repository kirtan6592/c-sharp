using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public partial class Employee
    {
        public void add()
        {
            Console.WriteLine("add");
        }
        partial void t();
        partial void t2()
        {
            throw new NotImplementedException();
        }
    }

    partial interface IEmployee
    {
        void test1();
    }

    partial interface IEmployee
    {
        void test2();
    }
}
