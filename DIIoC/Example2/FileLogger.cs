using System;
using System.Collections.Generic;
using System.Text;

namespace DIIoC.Example2
{
    class FileLogger : ILogger
    {
        public void ClearLog()
        {
            throw new NotImplementedException();
        }

        public void Log(string message)
        {
            Console.WriteLine($"Message: {message} logged");
        }
    }
}
