using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ConsoleApplication1
{
    public class DI : IDI
    {
        public void hello()
        {
        }
    }

    interface IDI
    {
        void hello();
    }

}
