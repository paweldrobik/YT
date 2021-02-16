using System;
using System.Collections.Generic;
using System.Text;

namespace DIIoC.Example2
{
    class InstagramPublisher : IEventPublisher
    {
        public void PublishEvent()
        {
            Console.WriteLine("Published on instagram");
        }

        public void SendMessage()
        {
            Console.WriteLine("Message send on chat");
        }
    }
}
