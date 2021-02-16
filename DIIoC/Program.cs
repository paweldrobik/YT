using Autofac;
using DIIoC.Example2;
using System;

namespace DIIoC
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileLogger>().As<ILogger>();
            builder.RegisterType<EventCreator>();

            do
            {
                Console.WriteLine("Please choose: I, F");
                var choise = Console.ReadLine();
                object _ = choise switch
                {
                    "I" => builder.RegisterType<InstagramPublisher>().As<IEventPublisher>(),
                    "F" => builder.RegisterType<FacebookPublisher>().As<IEventPublisher>(),
                    _ => throw new ArgumentException(),
                };

                var container = builder.Build();
                var eventCreator = container.Resolve<EventCreator>();
                eventCreator.CreateEvent();
            } while (true);

            //var c1 = new Client1(new Service2());
            //c1.ServeMethod();

            //var c2 = new Client2();
            //c2.Service = new Service2();
            //c2.ServeMethod();

            //var c3 = new Client3();
            //c3.ServeMethod(new Service1());

        }
    }
}
