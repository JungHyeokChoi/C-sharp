using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using static System.Console;

namespace _Thread
{
    class SideTaskA
    {
        int count;

        public SideTaskA(int count)
        {
            this.count = count;
        }

        public void KeepAlive()
        {
            try
            {
                while(count > 0)
                {
                    WriteLine($"{count--} left");
                    Thread.Sleep(10);
                }
                WriteLine("Count : 0");
            }
            catch(ThreadAbortException e)
            {
                WriteLine(e);
                Thread.ResetAbort();
            }
            finally
            {
                WriteLine("Clearing resource...");
            }

        }
    }
    class SideTaskB
    {
        int count;

        public SideTaskB(int count)
        {
            this.count = count;
        }

        public void KeepAlive()
        {
            try
            {
                WriteLine("Running thread isn't gonna be interrupted");
                Thread.SpinWait(1000000000);

                while (count > 0)
                {
                    WriteLine($"{count--} left");
                    WriteLine($"Entering into WaitJoinSleep State");

                    Thread.Sleep(10);
                }
                WriteLine("Count : 0");
            }
            catch (ThreadInterruptedException e)
            {
                WriteLine(e);
            }
            finally
            {
                WriteLine("Clearing resource...");
            }
        }
    }
    class CounterLock
    {
        const int LOOP_COUNT = 1000;

        readonly object thisLock;

        private int count;
        public int Count
        {
            get { return count; }
        }
        
        public CounterLock()
        {
            thisLock = new object();
            count = 0;
        }

        public void Increase()
        {
            int loopCount = LOOP_COUNT;
            while(loopCount-- > 0)
            {
                lock (thisLock)
                {
                    count++;
                }
                Thread.Sleep(1);
            }
        }

        public void Decrease()
        {
            int loopCount = LOOP_COUNT;
            while(loopCount-- > 0)
            {
                count--;
            }
            Thread.Sleep(1);
        }
    }
    class CounterMonitorA
    {
        const int LOOP_COUNT = 1000;

        readonly object thisLock;

        private int count;

        public int Count
        {
            get { return count; }
        }

        public CounterMonitorA()
        {
            thisLock = new object();
            count = 0;
        }

        public void Increase()
        {
            int lookCount = LOOP_COUNT;

            while(lookCount-- > 0)
            {
                Monitor.Enter(thisLock);
                try
                {
                    count++;
                }
                finally
                {
                    Monitor.Exit(thisLock);
                }
                Thread.Sleep(1);
            }
        }
        public void Decrease()
        {
            int lookCount = LOOP_COUNT;

            while (lookCount-- > 0)
            {
                Monitor.Enter(thisLock);
                try
                {
                    count--;
                }
                finally
                {
                    Monitor.Exit(thisLock);
                }
                Thread.Sleep(1);
            }
        }
    }
    class CounterMonitorB
    {
        const int LOOP_COUNT = 1000;

        readonly object thisLock;
        bool lockedCount = false;

        private int count;

        public int Count
        {
            get { return count; }
        }

        public CounterMonitorB()
        {
            thisLock = new object();
            count = 0;
        }

        public void Increase()
        {
            int lookCount = LOOP_COUNT;

            while (lookCount-- > 0)
            {
                lock (thisLock)
                {
                    while (count < 0 || lockedCount == true)
                        Monitor.Wait(thisLock);

                    lockedCount = true;
                    count++;
                    lockedCount = false;

                    Monitor.Pulse(thisLock);
                }
            }
        }
        public void Decrease()
        {
            int lookCount = LOOP_COUNT;

            while (lookCount-- > 0)
            {
                lock (thisLock)
                {
                    while (count < 0 || lockedCount == true)
                        Monitor.Wait(thisLock);

                    lockedCount = true;
                    count--;
                    lockedCount = false;

                    Monitor.Pulse(thisLock);                }
            }
        }
    }

    class Program
    {
        static void Main() 
        {
    
            BasicThread();
            //AbortingThread();
            //UsingThreadState();
            //InterruptingThread();
            //Synchronize();
            //UsingMonitor();
            //WaitPulse();
            //UsingTask();
            //TaskResult();        
            //ParallelLoop();
            //Asyns();
            //AsyncFileIO();

            WriteLine();
        }
        static void BasicThread()
        {
            WriteLine("BasicThread()");

            void DoSomething()
            {
                for(int i = 0; i < 5; i++)
                {
                    WriteLine($"DoSomething() : {i}");
                    Thread.Sleep(1000);
                }
            }

            Thread t1 = new Thread(new ThreadStart(DoSomething));


            WriteLine("Starting thread...");
            t1.Start();

            for (int i = 0; i < 5; i++)
            {
                WriteLine($"Main : {i}");
                Thread.Sleep(1000);
            }

            WriteLine("Wating until thread stops...");
            t1.Join();

            WriteLine("Finished");
        }
        static void AbortingThread()
        {
            WriteLine("\nAbortingThread()");

            SideTaskA task = new SideTaskA(100);
            Thread t1 = new Thread(new ThreadStart(task.KeepAlive));

            WriteLine("Starting thread...");
            t1.Start();

            Thread.Sleep(100);

            WriteLine("Aborting thread...");
            t1.Abort();

            WriteLine("Wating until thread stops...");
            t1.Join();

            WriteLine("Finished");
        }
        static void UsingThreadState()
        {
            WriteLine("\nUsingTHreadState()");

            void PrintThreadState(ThreadState state)
            {
                WriteLine("{0,-16} : {1}", state, (int)state);
            }

            PrintThreadState(ThreadState.Running);
            PrintThreadState(ThreadState.StopRequested);
            PrintThreadState(ThreadState.SuspendRequested);
            PrintThreadState(ThreadState.Background);
            PrintThreadState(ThreadState.Unstarted);
            PrintThreadState(ThreadState.Stopped);
            PrintThreadState(ThreadState.WaitSleepJoin);
            PrintThreadState(ThreadState.Suspended);
            PrintThreadState(ThreadState.AbortRequested);
            PrintThreadState(ThreadState.Aborted);
            PrintThreadState(ThreadState.Aborted | ThreadState.Stopped);
        }
        static void InterruptingThread()
        {
            WriteLine("\nInterruptingThread()");

            SideTaskB task = new SideTaskB(100);
            Thread t1 = new Thread(new ThreadStart(task.KeepAlive));
            t1.IsBackground = true;

            WriteLine("Starting thread...");
            t1.Start();
            WriteLine($"Current Thread State : {t1.ThreadState}");

            Thread.Sleep(100);

            WriteLine("Interrupting thread...");
            t1.Interrupt();
            WriteLine($"Current Thread State : {t1.ThreadState}");

            WriteLine("Waing until thread stops...");
            t1.Join();
            WriteLine($"Current Thread State : {t1.ThreadState}");

            WriteLine("Finished");
            WriteLine($"Current Thread State : {t1.ThreadState}");
        }
        static void Synchronize()
        {
            WriteLine("\nSynchronize()");

            CounterLock counter = new CounterLock();

            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            WriteLine($"Count : {counter.Count}");

        }
        static void UsingMonitor()
        {
            WriteLine("\nUsingMonitor()");

            CounterMonitorA counter = new CounterMonitorA();

            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            WriteLine($"Count : {counter.Count}");
        }
        static void WaitPulse()
        {
            WriteLine("\nWaitPulse()");

            CounterMonitorB counter = new CounterMonitorB();

            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            WriteLine($"Count : {counter.Count}");
        }
        static void UsingTask()
        {
            WriteLine("\nUsingTask()");

            string srcFile = Directory.GetCurrentDirectory() + "\\a.txt";

            Action<object> FileCopyAction = (object state) =>
            {
                String[] paths = (String[])state;

                if (File.Exists(paths[1]))
                    File.Delete(paths[1]);

                File.Copy(paths[0], paths[1]);

                WriteLine($"TaskID : {Task.CurrentId}, ThreadID : {Thread.CurrentThread}, {paths[0]} was copied to {paths[1]}");
            };

            Task t1 = new Task(FileCopyAction, new string[]{ srcFile, srcFile + ".copy1" });
            Task t2 = Task.Run(() => 
            { 
                FileCopyAction(new string[] { srcFile, srcFile + ".copy2" });
            });

            t1.Start();

            Task t3 = new Task(FileCopyAction, new string[]{ srcFile, srcFile + ".copy3" });

            t3.RunSynchronously();

            t1.Wait();
            t2.Wait();
            t3.Wait();
;        }
        static void TaskResult()
        {
            WriteLine("\nTaskResult()");

            bool IsPrime(long number)
            {
                if (number < 2)
                    return false;
                
                if(number % 2 == 0 && number != 2)
                    return false;
                
                for(long i = 2; i < number; i++)
                {
                    if (number % i == 0)
                        return false;
                }

                return true;
            }

            string str = ReadLine();
            string[] args = str.Split();

            long from = Convert.ToInt64(args[0]);
            long to = Convert.ToInt64(args[1]);
            int taskCount = Convert.ToInt32(args[2]);

            Func<object, List<long>> FindPrimeFunc = 
                (objRange) =>
            {
                long[] range = (long[])objRange;
                List<long> found = new List<long>();

                for (long i = range[0]; i < range[1]; i++)
                {
                    if (IsPrime(i))
                        found.Add(i);
                }

                return found;
            };

            Task<List<long>>[] tasks = new Task<List<long>>[taskCount];
            long currentFrom = from;
            long currentTo = to / tasks.Length;
            for(int i = 0; i < tasks.Length; i++)
            {
                WriteLine($"Task[{i}] : {currentFrom} ~ {currentTo}");

                tasks[i] = new Task<List<long>>(FindPrimeFunc, new long[] { currentFrom, currentTo });
                currentFrom = currentTo + 1;

                if (i == tasks.Length - 2)
                    currentTo = to;
                else
                    currentTo = currentTo + (to / tasks.Length);
            }

            WriteLine("Please press enter to start...");
            ReadLine();
            WriteLine("Started...");

            DateTime startTime = DateTime.Now;

            foreach (Task<List<long>> task in tasks)
                task.Start();

            List<long> total = new List<long>();

            foreach(Task<List<long>> task in tasks)
            {
                task.Wait();
                total.AddRange(task.Result.ToArray());
            }

            DateTime endTime = DateTime.Now;

            TimeSpan ellapsed = endTime - startTime;

            WriteLine($"Prime Number count between {from} and {to} : {total.Count}");
            WriteLine($"Ellapsed time : {ellapsed}");
        }
        static void ParallelLoop()
        {
            WriteLine("\nParllelLoop()");

            bool IsPrime(long number)
            {
                if (number < 2)
                    return false;

                if (number % 2 == 0 && number != 2)
                    return false;

                for (long i = 2; i < number; i++)
                {
                    if (number % i == 0)
                        return false;
                }

                return true;
            }

            string str = ReadLine();
            string[] args = str.Split();

            long from = Convert.ToInt64(args[0]);
            long to = Convert.ToInt64(args[1]);

            WriteLine("Please press enter to start...");
            ReadLine();
            WriteLine("Started...");

            DateTime startTime = DateTime.Now;
            List<long> total = new List<long>();

            Parallel.For(from, to, (long i) =>
            {
                if (IsPrime(i))
                    total.Add(i);

            });

            DateTime endTime = DateTime.Now;

            TimeSpan ellapsed = endTime - startTime;

            WriteLine($"Prime Number count between {from} and {to} : {total.Count}");
            WriteLine($"Ellapsed time : {ellapsed}");
        }
        static void Asyns()
        {
            WriteLine("\nAsyns()");

            async void MyMethodAsync(int count)
            {
                WriteLine("C");
                WriteLine("D");

                await Task.Run(async () =>
                {
                    for (int i = 0; i <= count; i++)
                    {
                        WriteLine($"{i}/{count}...");
                        await Task.Delay(100);
                    }
                });

                WriteLine("G");
                WriteLine("H");
            }

            void Caller()
            {
                WriteLine("A");
                WriteLine("B");

                MyMethodAsync(3);

                WriteLine("E");
                WriteLine("F");
            }

            Caller();

            Read();
        }
        static void AsyncFileIO()
        {
            WriteLine("\nAsyncFileIO()");

            async Task<long> CopyAsync(string FromPath, string ToPath)
            {
                using (
                    var fromStream = new FileStream(FromPath, FileMode.Open))
                {
                    long totalCopied = 0;

                    using(
                        var toStream = new FileStream(ToPath, FileMode.Create))
                    {
                        byte[] buffer = new byte[1024];
                        int nRead = 0;
                        while((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                        {
                            await toStream.WriteAsync(buffer, 0, nRead);
                            totalCopied += nRead;
                        }
                    }

                    return totalCopied;
                }
            }

            async void DoCopy(string FromPath, string ToPath)
            {
                if (!File.Exists(FromPath))
                    File.Create(FromPath).Close();

                if (File.Exists(ToPath))
                    File.Delete(ToPath);

                long totalCopied = await CopyAsync(FromPath, ToPath);
                WriteLine($"Copied Total {totalCopied} Bytes");
            }

            string currentDircetory = Directory.GetCurrentDirectory() + "\\";

            string str = ReadLine();
            string[] fileName = str.Split();

            for (int i = 0; i < fileName.Length; i++)
                fileName[i] = string.Concat(currentDircetory,fileName[i]);

            if (fileName.Length < 2)
            {
                WriteLine("Usage : AsynFileIO <Source> <Destination>");
                return;
            }

            DoCopy(fileName[0], fileName[1]);

            Read();
        }
    }
}
