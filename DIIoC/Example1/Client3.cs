using System;
using System.Collections.Generic;
using System.Text;

namespace DIIoC
{
    class Client3
    {
        public void ServeMethod(IService service)
        {
            service.Serve();
        }
    }
}
