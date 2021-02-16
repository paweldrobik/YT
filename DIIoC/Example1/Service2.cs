using System;
using System.Collections.Generic;
using System.Text;

namespace DIIoC
{
    class Service2 : IService
    {
        public void Serve()
        {
            Console.WriteLine("Called from service 2");
        }
    }
}
