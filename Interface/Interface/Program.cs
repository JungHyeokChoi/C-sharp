using System;
using System.IO;
using static System.Console;

namespace Interface
{
    interface ILogger
    {
        void WriteLog(string message);
    }
    interface IFormattableLogger : ILogger
    {
        void WriteLog(string format, params Object[] args);
    }
    interface IRunnable
    {
        void Run();
    }
    interface IFlyable
    {
        void Fly();
    }

    abstract class AbstractBase
    {
        protected void PrivateMethodA()
        {
            WriteLine("AbstractBase.PrivateMethodA()");
        }

        public void PublicMethodA()
        {
            WriteLine("AbstractBase.PubliMethodA()");
        }

        public abstract void AbstracMethodA();
    }

    class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            WriteLine($"{DateTime.Now.ToLocalTime()}, {message}");
        }
    }
    class ConsoleLogger2 : IFormattableLogger
    {
        public void WriteLog(string message)
        {
            WriteLine($"{DateTime.Now.ToLocalTime()}, {message}");
        }

        public void WriteLog(string format, params Object[] args)
        {
            string message = String.Format(format, args);
            WriteLine($"{DateTime.Now.ToLocalTime()}, {message}");
        } 
    }
    class FileLogger : ILogger
    {
        private StreamWriter writer;

        public FileLogger(string path)
        {
            writer = File.CreateText(path);
            writer.AutoFlush = true;
        }

        public void WriteLog(string message)
        {
            writer.WriteLine($"{DateTime.Now.ToShortTimeString()}, {message}");
        }
    }
    class ClimateMonitor
    {
        private ILogger logger;

        public ClimateMonitor(ILogger logger)
        {
            this.logger = logger;
        }

        public void start()
        {
            while (true)
            {
                Write("온도를 입력해주세요 : ");
                string temperature = ReadLine();
                if (temperature == "")
                    break;

                logger.WriteLog("현재 온도 : " + temperature);
                
            }
        }
    }
    class FlyingCar : IRunnable, IFlyable
    {
        public void Run()
        {
            WriteLine("Run! Run");
        }

        public void Fly()
        {
            WriteLine("Fly! Fly!");
        }
    }
    class Derived : AbstractBase
    {
        public override void AbstracMethodA()
        {
            WriteLine("Derived.AbstracMethodA()");
            PrivateMethodA();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Interface();
            DerivedInterface();
            MultiInterfaceInheritance();
            AbstractClass();

            WriteLine();
        }
        static void Interface()
        {
            WriteLine("Interface()");

            ClimateMonitor monitor_file = new ClimateMonitor(new FileLogger("MyLog.txt"));
            monitor_file.start();

            //ClimateMonitor monitor_console = new ClimateMonitor(new ConsoleLogger());
            //monitor_console.start();
        }
        static void DerivedInterface()
        {
            WriteLine("\nDerivedInterface()");

            IFormattableLogger logger = new ConsoleLogger2();
            logger.WriteLog("The world is not flat");
            logger.WriteLog("{0} + {1} = {2}", 1, 1, 2);
        }
        static void MultiInterfaceInheritance()
        {
            WriteLine("\nMultiInterfaceInheritance()");

            FlyingCar car = new FlyingCar();
            car.Run();
            car.Fly();

            IRunnable runnable = car as IRunnable;
            runnable.Run();

            IFlyable flyable = car as IFlyable;
            flyable.Fly();
        }
        static void AbstractClass()
        {
            WriteLine("\nAbstractClass()");

            AbstractBase obj = new Derived();
            obj.AbstracMethodA();
            obj.PublicMethodA();
        }
    }
}
