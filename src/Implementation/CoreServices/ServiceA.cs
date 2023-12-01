using Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.CoreServices
{
    public class ServiceA:ICoreService
    {
        string Name = "ServiceA";
        public void Run()
        {
            Console.WriteLine(Name + " is running");
        }
    }
}
