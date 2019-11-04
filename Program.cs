using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;
using Unity;

namespace test
{
    
    public class M1
    {
        public delegate void BeforePrint();
        public event BeforePrint beforePrintEvent;
        public void PrintNumber(int number)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();
            Console.WriteLine("Number : {0,-12:N0}", number);
        }
        public int Id { get; set; }
        public string Name { get; set; }

    }
}

namespace ConsoleApplication1
{
    public class clsShallow
    {
        private M1 _m1;

        public static string CompanyName = "My Company";
        public int Age;
        public string EmployeeName;
        public clsRefSalary EmpSalary;

        public clsShallow CreateShallowCopy(clsShallow inputcls)
        {
            return (clsShallow)inputcls.MemberwiseClone();
        }
        public clsShallow()
        {
            
        }
        public clsShallow(int num)
        {
            _m1 = new M1();
            _m1.beforePrintEvent += _m1_beforePrintEvent;
        }

        private void _m1_beforePrintEvent()
        {
            Console.WriteLine("subscribe event");
        }
        public void printMony()
        {
            _m1.PrintNumber(20);
        }
    }
    public class clsRefSalary
    {
        public clsRefSalary(int _salary)
        {
            Salary = _salary;
        }
        public int Salary;
    }


    [Serializable]
    // serialize the classes in case of deep copy
    public class clsDeep
    {
        public static string CompanyName = "My Company";
        public int Age;
        public string EmployeeName;
        public clsRefSalary EmpSalary;
        public clsDeep CreateDeepCopy()
        {
            clsDeep c1 = new clsDeep() { Age = 22, EmployeeName = "tt" };
            return (clsDeep)c1.CreateDeepCopy();
        }
    }



    public abstract class Employee1
    {
        public virtual string GetProjectDetails(int employeeId)
        {
            return "Base Project";
        }
        public virtual string GetEmployeeDetails(int employeeId)
        {
            return "Base Employee";
        }
    }
    public class NewEmployee : Employee1
    {
        public override string GetEmployeeDetails(int employeeId)
        {
            return base.GetEmployeeDetails(employeeId);
        }
        //public override string GetProjectDetails(int employeeId)
        //{
        //    throw new Exception();
        //}
    }
    class Customer
    {
        public int MyProperty { get; set; }
        public virtual double getDiscount(double TotalSales)
        {
            return TotalSales * .2;
        }

        public Customer shallowCopy()
        {
            return (Customer)this.MemberwiseClone();
        }
        public Customer deepCopy()
        {
            Customer clone = (Customer)this.MemberwiseClone();
            clone.MyProperty = 1;
            return clone;
        }
    }

    class SilverCustomer : Customer
    {
        public override double getDiscount(double TotalSales)
        {
            return base.getDiscount(TotalSales) - 50;
        }
    }
    class a
    {
        void print()
        {
            Console.WriteLine('a');
        }
    }
    class b : a
    {
        public void print()
        {
            Console.WriteLine('b');
        }
    }

    class Program
    {
        //public static bool method123()
        //{
        //    Console.Write('a');
        //}

        public delegate string myDelegate(string s);
        public static string addOne(string s = "test")
        {
            return s;
        }

        static void Test(out int x, out int y)
        {
            x = 42;
            y = 123;
            Console.WriteLine(x == y);
        }
        static void Main(string[] args)
        {
            var clsShallow1 = new clsShallow(20);
            clsShallow1.printMony();
            var abcd = new List<M1>();
            abcd.Add(new test.M1() { Id = 1, Name = "test 1" });
            //abcd.Add(new test.M1() { Id = 2, Name = "test 2" });
            var x112 = abcd.First();
            var x222 = abcd.Single();
            int n, sum = 0, m;
            Console.Write("Enter a number: ");
            n = int.Parse(Console.ReadLine());
            while (n > 0)
            {
                m = n % 10;
                sum = sum + m;
                n = n / 10;
            }
            Console.Write("Sum is= " + sum);




            // ############################ Deep Copy ############################
            // Creates an instance of clsDeep and assign values to its fields.
            clsDeep objdeep = new clsDeep();
            objdeep.Age = 25;
            objdeep.EmployeeName = "Ahmed Eid";

            // add the ref value
            clsRefSalary clsref = new clsRefSalary(1000);
            objdeep.EmpSalary = clsref;

            // Performs a shallow copy of m1 and assign it to m2.
            clsDeep m2 = objdeep.CreateDeepCopy();

            // then modify the clsref salary value to be 2000 
            clsref.Salary = 2000;

            // so the m1 object salary value become 2000
            int EmpSalary = objdeep.EmpSalary.Salary;


            // ############################ Shallow Copy ############################
            clsShallow objshallow = new clsShallow();
            objshallow.Age = 25;
            objshallow.EmployeeName = "Ahmed Eid";

            // add the ref value to the objshallow 
            clsRefSalary clsref1 = new clsRefSalary(1000);
            objshallow.EmpSalary = clsref1;

            // Performs a shallow copy of m1 and assign it to m2.
            clsShallow m21 = objshallow.CreateShallowCopy(objshallow);

            // then modify the clsref salary value to be 2000
            clsref.Salary = 2000;

            // so the m1 object salary value become 2000
            int EmpSalary1 = objshallow.EmpSalary.Salary;




            var c1 = new Customer();
            c1.MyProperty = 2;
            var customer2 = c1.shallowCopy();
            var customer3 = c1.deepCopy();
            c1.MyProperty = 5;



            List<Employee1> employeeList = new List<Employee1>();
            employeeList.Add(new NewEmployee());
            foreach (Employee1 e in employeeList)
            {
                e.GetProjectDetails(1245);
            }



            var silverCustomer = new SilverCustomer();
            Console.WriteLine(silverCustomer.getDiscount(10.10));
            var var2 = 5;
            var var3 = 6;
            var var1 = var2 = var3;
            IList<int> strList = new List<int>() { 6, 2, 9, 1 };
            //var tt = strList.OrderBy().Skip(1).Take(1);
            b b1 = new b();
            b1.print();
            int x1 = 10;
            int y = 20;
            Test(out x1, out y);
            object name = "sandeep";
            char[] values = { 's', 'a', 'n', 'd', 'e', 'e', 'p' };
            object myName = new string(values);
            Console.WriteLine("== operator result is {0}", name == myName);
            Console.WriteLine("Equals method result is {0}", myName.Equals(name));
            Console.ReadKey();

            myDelegate obj5 = new myDelegate(addOne);
            Console.WriteLine(obj5("test 2"));


            myDelegate obj6 = delegate (string b) { return b; };
            Console.WriteLine(obj6("t"));

            myDelegate obj7 = (x) => { return x; };
            Console.WriteLine(obj7("t2"));



























            while (true)
            {
                try
                {
                    continue;
                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {

                }
            }
            ExtractProcess eETL = new ExtractProcess();
            TransferProcess tETL = new TransferProcess();
            LoadProcess lETL = new LoadProcess();

            eETL.SetNextProcess(tETL);
            tETL.SetNextProcess(lETL);

            eETL.Process();

            ETL etl = new StructuredDataETL();
            etl.Execute();


            Singletone obj3 = Singletone.GetInstance;
            Singletone obj4 = Singletone.GetInstance;

            Employee emp = new Employee();

            var container = new UnityContainer();
            container.RegisterType<IDI, DI>();

            MyClass obj = new MyClass(1, "test");
            MyClass obj1 = new MyClass(obj);
            Console.WriteLine("{0} , {1} ", obj1.id, obj1.name);
            Console.ReadLine();
        }
    }

    public class MyClass
    {
        public int id;
        public string name;
        public MyClass(MyClass obj)
        {
            id = obj.id;
            name = obj.name;
        }
        public MyClass(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }


    abstract class ETL
    {
        public abstract void Extract();
        public abstract void Transfer();
        public abstract void Load();

        public void Execute()
        {
            Extract();
            Transfer();
            Load();
        }
    }

    class StructuredDataETL : ETL
    {
        public override void Extract()
        {
            Console.WriteLine("Structured ETL - Extract");
        }

        public override void Transfer()
        {
            Console.WriteLine("Structured ETL - Transfer");
        }

        public override void Load()
        {
            Console.WriteLine("Structured ETL - Load");
        }
    }


    abstract class AbstractProcess
    {
        protected AbstractProcess _next;
        public abstract void Process();
        public void SetNextProcess(AbstractProcess process)
        {
            _next = process;
        }
    }

    class ExtractProcess : AbstractProcess
    {
        public override void Process()
        {
            Console.WriteLine("-----------Extract Process-------------");

            if (_next != null)
            {
                _next.Process();
            }
        }
    }

    class LoadProcess : AbstractProcess
    {
        public override void Process()
        {
            Console.WriteLine("-----------Load Process-------------");

            if (_next != null)
            {
                _next.Process();
            }
        }
    }

    class TransferProcess : AbstractProcess
    {
        public override void Process()
        {
            Console.WriteLine("-----------Transfer Process-------------");

            if (_next != null)
            {
                _next.Process();
            }
        }
    }

    //public void t1(string a, int b)
    //{

    //}

    //public void t1(int b, string a)
    //{

    //}
}
