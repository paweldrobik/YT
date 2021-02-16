using System;
using System.Collections.Generic;
using System.Text;

namespace DIIoC.Example2
{
    class FacebookPublisher : IEventPublisher
    {
        public void PublishEvent()
        {
            Console.WriteLine("Published on fb");
        }

        public void SendMessage()
        {
            Console.WriteLine("Message sent to email");
        }
    }
}
