using Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.CoreServices
{
    public class ServiceB:ICoreService
    {
        string Name = "ServiceB";
        public void Run()
        {
            Console.WriteLine(Name + " is running");
        }
    }
}
