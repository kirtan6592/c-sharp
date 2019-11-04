using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public sealed class Singletone
    {
        public static Singletone instance = null;
        public static Singletone GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singletone();
                }
                return instance;
            }
        }
        private Singletone()
        {

        }
    }
}
