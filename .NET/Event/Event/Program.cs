using System;
using System.Collections;
using static System.Console;
using static System.Delegate;

namespace Event
{
    delegate int MyDelegate(int a, int b);
    delegate int Compare(int a, int b);
    delegate int Compare<T>(T a, T B);
    delegate void Notify(string message);
    delegate void EventHandler(string message);
    delegate void MarketDelegate(int a);
    delegate void SecurityDelegate(int a, string Action);

    class Calculator
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }

        public int Minus(int a, int b)
        {
            return a - b;
        }
    }
    class Notifier
    {
        public Notify EventOccured; 
    }
    class EventListener
    {
        private string name;
        public EventListener(string name)
        {
            this.name = name;
        }

        public void SomethingHappend(string message)
        {
            WriteLine($"{name}.SomethingHappend : {message}");
        }
    }
    class MyNotifier
    {
        public event EventHandler SomethingHappened;
        public void DoSomething(int number)
        {
            int temp = number % 10;

            if(temp != 0 && temp % 3 == 0)
            {
                SomethingHappened(String.Format("{0} : 짝",number));
            }
        }
    }
    class Market
    {
        public event MarketDelegate CustomerEvent;
        public event SecurityDelegate SecurityEvent;

        public void BuySomething(int CustomerNo)
        {
            if (CustomerNo == 30)
                CustomerEvent(CustomerNo);
        }

        public void BuySomething(int CustomerNo, string Action)
        {
            if (Action == "Stealing")
                SecurityEvent(CustomerNo, Action);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Delegate();
            UsingCallback();
            GenericDelegate();
            DelegateChains();
            AnonymousMethod();
            EventTest();

            WriteLine();
        }
        static void Delegate()
        {
            WriteLine("Delegate()");

            Calculator Calc = new Calculator();
            MyDelegate Callback;

            Callback = new MyDelegate(Calc.Plus);
            WriteLine(Callback(3, 4));

            Callback = new MyDelegate(Calc.Minus);
            WriteLine(Callback(7, 5));
        }
        static void UsingCallback()
        {
            int AscendCompare(int a, int b)
            {
                if (a < b)
                    return 1;
                else if (a == b)
                    return 0;
                else
                    return -1;
            }

            int DescendCompare(int a, int b)
            {
                if (a > b)
                    return 1;
                else if (a == b)
                    return 0;
                else
                    return -1;
            }

            void BubbleSort(int[] DataSet, Compare Comparer)
            {
                int i = 0;
                int j = 0;
                int temp = 0;

                for (i = 0; i < DataSet.Length - 1; i++)
                {
                    for (j = 0; j < DataSet.Length - (i + 1); j++)
                    {
                        if(Comparer(DataSet[j], DataSet[j + 1]) > 0)
                        {
                            temp = DataSet[j];
                            DataSet[j] = DataSet[j + 1];
                            DataSet[j + 1] = temp;
                        }
                    }
                }
            }

            int[] arrayA = { 3, 7, 4, 2, 10 };

            WriteLine("Sorting Ascending...");
            BubbleSort(arrayA, new Compare(AscendCompare));

            foreach (int element in arrayA)
                Write($"{element} ");
            WriteLine();

            int[] arrayB = { 7, 2, 8, 10, 11 };

            WriteLine("\nSorting Descending...");
            BubbleSort(arrayB, new Compare(DescendCompare));

            foreach (int element in arrayB)
                Write($"{element} ");
            WriteLine();
        }
        static void GenericDelegate()
        {
            WriteLine("\nGenericDelegate()");

            int AscendCompare<T>(T a, T b) where T : IComparable<T>
            {
                return a.CompareTo(b);
            }
            int DescendCompare<T>(T a, T b) where T : IComparable<T>
            {
                return a.CompareTo(b) * -1;
            }
            void BubbleSort<T>(T[] DataSet, Compare<T> Comparer)
            {
                int i = 0;
                int j = 0;
                T temp;

                for(i = 0;i<DataSet.Length - 1; i++)
                {
                    for(j = 0;j<DataSet.Length - (i + 1); j++)
                    {
                        if(Comparer(DataSet[j], DataSet[j+1]) > 0)
                        {
                            temp = DataSet[j];
                            DataSet[j] = DataSet[j + 1];
                            DataSet[j + 1] = temp;
                        }
                    }
                }
                
            }

            int[] arrayA = { 3, 7, 4, 2, 10 };

            WriteLine("Sorting AscendCompare...");
            BubbleSort<int>(arrayA, new Compare<int>(AscendCompare<int>));

            foreach (int element in arrayA)
                Write($"{element} ");
            WriteLine();

            string[] arrayB = { "abc", "def", "ghi", "jkl", "mno" };

            WriteLine("\nSorting DescendCompare...");
            BubbleSort<string>(arrayB, new Compare<string>(DescendCompare<string>));

            foreach (string str in arrayB)
                Write($"{str} ");
            WriteLine();
        }
        static void DelegateChains()
        {
            WriteLine("\nDelegateChains()");
            
            Notifier notifier = new Notifier();
            EventListener listenerA = new EventListener("ListenerA");
            EventListener listenerB = new EventListener("ListenerB");
            EventListener listenerC = new EventListener("ListenerC");

            notifier.EventOccured += listenerA.SomethingHappend;
            notifier.EventOccured += listenerB.SomethingHappend;
            notifier.EventOccured += listenerC.SomethingHappend;
            notifier.EventOccured("You've got mail");

            WriteLine();

            notifier.EventOccured -= listenerB.SomethingHappend;
            notifier.EventOccured("Download complete");

            WriteLine();

            notifier.EventOccured += new Notify(listenerB.SomethingHappend)
                                   + new Notify(listenerC.SomethingHappend);
            notifier.EventOccured("Nuclear launch detected");

            WriteLine();

            Notify notifyA = new Notify(listenerA.SomethingHappend);
            Notify notifyB = new Notify(listenerB.SomethingHappend);

            notifier.EventOccured = (Notify)Combine(notifyA, notifyB);
            notifier.EventOccured("Fire!");

            WriteLine();

            notifier.EventOccured = (Notify)Remove(notifier.EventOccured, notifyB);
            notifier.EventOccured("RPG!");
        }
        static void AnonymousMethod()
        {
            WriteLine("\nAnonymousMethod()");

            void BubbleSort(int[] DataSet, Compare Comparer)
            {
                int i = 0;
                int j = 0;
                int temp = 0;

                for (i = 0; i < DataSet.Length - 1; i++)
                {
                    for (j = 0; j < DataSet.Length - (i + 1); j++)
                    {
                        if (Comparer(DataSet[j], DataSet[j + 1]) > 0)
                        {
                            temp = DataSet[j];
                            DataSet[j] = DataSet[j + 1];
                            DataSet[j + 1] = temp;
                        }
                    }
                }
            }

            int[] arrayA = { 3, 7, 4, 2, 10 };

            WriteLine("Sort Ascending...");
            BubbleSort(arrayA, delegate(int a, int b)
            {
                if (a > b)
                    return 1;
                else if (a == b)
                    return 0;
                else
                    return -1;
            });

            foreach (int element in arrayA)
                Write($"{element} ");
            WriteLine();

            int[] arrayB = { 7, 2, 8, 10, 11 };

            WriteLine("Sort Descending...");
            BubbleSort(arrayA, delegate (int a, int b)
            {
                if (a < b)
                    return 1;
                else if (a == b)
                    return 0;
                else
                    return -1;
            });

            foreach (int element in arrayB)
                Write($"{element} ");
            WriteLine();

            //Ex13_1
            WriteLine("\nEx13_1");
            MyDelegate Callback;

            Callback = delegate (int a, int b)
            {
                return a + b;
            };

            WriteLine(Callback(3, 4));

            Callback = delegate (int a, int b)
            {
                return a - b;
            };

            WriteLine(Callback(7, 5));

        }
        static void EventTest()
        {
            WriteLine("\nEventTest()");

            void MyHandler(string message)
            {
                WriteLine(message);
            }

            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappened += new EventHandler(MyHandler);

            for (int i = 0; i < 30; i++)
                notifier.DoSomething(i);

            //Ex13_2
            WriteLine("\nEx13_2");

            void PrizeMessage(int CustomerNo)
            {
                WriteLine($"축하합니다! {CustomerNo}번째 고객 이벤트에 당첨되셨습니다.");
            }
            
            void SecurityMessage(int CustomerNo, string Action)
            {
                WriteLine($"No.{CustomerNo} : {Action}");
            }

            Market market = new Market();
            market.CustomerEvent += new MarketDelegate(PrizeMessage);
            market.SecurityEvent += new SecurityDelegate(SecurityMessage);

            for (int CustomerNo = 0; CustomerNo < 100; CustomerNo++)
                market.BuySomething(CustomerNo);
            WriteLine();

            string[] CustomerActionArray = { "Buy", "Buy", "Buy", "Stealing", "Buy", "Buy", "Stealing", "Buy" };
            
            for (int i = 0; i < CustomerActionArray.Length; i++)
                market.BuySomething(i,CustomerActionArray[i]);
        }
    }
}
