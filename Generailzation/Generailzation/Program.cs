using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace Generailzation
{
    interface IRun
    {
        void Run();
    }
    interface IFly
    {
        void Fly();
    }

    class MyListA<T>
    {
        private T[] array;

        public MyListA()
        {
            array = new T[3];
        }

        public T this[int index]
        {
            get
            { return array[index]; }

            set
            {
                if (index >= array.Length)
                {
                    Array.Resize<T>(ref array, array.Length + 1);
                    WriteLine($"Array Resize : {array.Length}");
                }

                array[index] = value;
            }
        }

        public int Length
        {
            get { return array.Length; }
        }
    }
    class MyListB<T> : IEnumerable<T>, IEnumerator<T>
    {
        private T[] array;
        int position = -1;

        public MyListB()
        {
            array = new T[3];
        }

        public T this[int index]
        {
            get
            { return array[index]; }

            set
            {
                if (index >= array.Length)
                {
                    Array.Resize<T>(ref array, array.Length + 1);
                    WriteLine($"Array Resize : {array.Length}");
                }

                array[index] = value;
            }
        }

        public int Length
        {
            get { return array.Length; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
                yield return (array[i]);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
                yield return (array[i]);
        }

        public T Current
        {
            get { return array[position]; }
        }

        object IEnumerator.Current
        {
            get { return array[position]; } 
        }

        public bool MoveNext()
        {
            if(position == array.Length - 1)
            {
                Reset();
                return false;
            }

            position++;
            return (position < array.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {

        }
    }
    class StructArray<T> where T : struct
    {
        public T[] Array { get; set; }
        public StructArray(int size)
        {
            Array = new T[size];
            WriteLine($"StructArray Created....");
            WriteLine($"Length : {Array.Length}\nDataType : {Array.GetType()}\n");
        }
    }
    class RefArray<T> where T : class
    {
        public T[] Array { get; set; }
        public RefArray(int size)
        {
            Array = new T[size];
        }
    }
    class Base
    {
        public Base()
        {
            WriteLine("Created Base()");
        }
        
    }
    class Derived : Base
    {
        public Derived()
        {
            WriteLine("Created Dervied()");
        }
    }
    class BaseArray<U> where U : Base
    {
        public U[] Array { get; set; }
        public BaseArray(int size)
        {
            Array = new U[size];
        }
        public void CopyArray<T>(T[] Source) where T : U
        {
            Source.CopyTo(Array, 0);
        }
    }
    class MyClass : IRun, IFly
    {
        public void Run()
        {
            WriteLine("Run..");
        }

        public void Fly()
        {
            WriteLine("Fly..");
        }

    }
    class InterfaceArray<T> where T : IRun, IFly
    {
        public T[] Array { get; set; }
        public InterfaceArray(int size)
        {
            Array = new T[size];
        }
    }


    class Program
    {
        static void Main()
        {
            CopyingArray();
            Generic();
            ConstraintsOnTypeParameters();
            UsingGenericList();
            UsingGenericQueue();
            UsingGenericStack();
            UsingGenericDictionary();
            EnumerableGeneric();

            WriteLine();
        }

        static void CopyingArray()
        {
            WriteLine("ConpyingArray()");

            void CopyArray<T>(T[] source, T[] target)
            {
                for (int i = 0; i < source.Length; i++)
                    target[i] = source[i];
            }

            int[] sourceA = { 1, 2, 3, 4, 5 };
            int[] targetA = new int[sourceA.Length];

            CopyArray<int>(sourceA, targetA);

            foreach (int element in targetA)
                WriteLine(element);

            string[] sourceB = { "하나", "둘", "셋", "넷", "다섯" };
            string[] targetB = new string[sourceB.Length];

            CopyArray<string>(sourceB, targetB);

            foreach (string element in targetB)
                WriteLine(element);
        }
        static void Generic()
        {
            WriteLine("\nGeneric()");

            MyListA<string> str_list = new MyListA<string>();
            str_list[0] = "abc";
            str_list[1] = "def";
            str_list[2] = "ghi";
            str_list[3] = "jkl";
            str_list[4] = "mno";

            for (int i = 0; i < str_list.Length; i++)
                Write($"{str_list[i]} ");
            WriteLine();

            MyListA<int> int_list = new MyListA<int>();
            int_list[0] = 0;
            int_list[1] = 1;
            int_list[2] = 2;
            int_list[3] = 3;
            int_list[4] = 4;

            for (int i = 0; i < int_list.Length; i++)
                Write($"{int_list[i]} ");
            WriteLine();
        }
        static void ConstraintsOnTypeParameters()
        {
            WriteLine("\nConstraintsOnTypeParameters()");

            T CreateInstance<T>() where T : new()
            {
                return new T();
            }

            StructArray<int> a = new StructArray<int>(3);
            a.Array[0] = 0;
            a.Array[1] = 1;
            a.Array[2] = 2;

            for (int i = 0; i < a.Array.Length; i++)
                Write(i );
            WriteLine();

            RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(3);
            b.Array[0] = new StructArray<double>(5);
            b.Array[1] = new StructArray<double>(10);
            b.Array[2] = new StructArray<double>(15);

            double ret = 1.0;
            for(int i = 0; i < b.Array.Length; i++)
            {
                for (int j = 0; j < b.Array[i].Array.Length; j++)
                {
                    b.Array[i].Array[j] = ret;
                    ret += 0.5;
                }
            }

            for (int i = 0; i < b.Array.Length; i++)
            {
                Write($"Array[{i}] : ");
                for (int j = 0; j < b.Array[i].Array.Length; j++)
                {
                    Write($"{b.Array[i].Array[j]} / ");
                }
                WriteLine();
            }

            WriteLine();

            BaseArray<Base> c = new BaseArray<Base>(3);
            c.Array[0] = new Base();
            c.Array[1] = new Derived();
            c.Array[2] = CreateInstance<Base>();

            WriteLine();

            BaseArray<Derived> d = new BaseArray<Derived>(3);
            d.Array[0] = new Derived();
            d.Array[1] = CreateInstance<Derived>();
            d.Array[2] = CreateInstance<Derived>();

            WriteLine();

            BaseArray<Base> e = new BaseArray<Base>(3);
            e.CopyArray<Base>(c.Array);

            WriteLine();

            InterfaceArray<MyClass> f = new InterfaceArray<MyClass>(3);
            f.Array[0] = new MyClass();
            f.Array[1] = new MyClass();
            f.Array[2] = new MyClass();

            f.Array[0].Fly();
            f.Array[1].Run();
            f.Array[2].Fly();

        }
        static void UsingGenericList()
        {
            WriteLine("\nUsingGenericList()");

            List<int> list = new List<int>();
            for (int i = 0; i < 5; i++)
                list.Add(i);

            foreach (int element in list)
                Write($"{element} ");
            WriteLine();

            list.RemoveAt(2);

            foreach (int element in list)
                Write($"{element} ");
            WriteLine();

            list.Insert(2, 2);

            foreach (int element in list)
                Write($"{element} ");
            WriteLine();
        }
        static void UsingGenericQueue()
        {
            WriteLine("\nUsingGenericQueue()");

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < 5; i++)
                queue.Enqueue(i);

            while (queue.Count > 0)
                Write($"{queue.Dequeue()} ");
            WriteLine();
        }
        static void UsingGenericStack()
        {
            WriteLine("\nUsingGenericStack()");

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < 5; i++)
                stack.Push(i);

            while (stack.Count > 0)
                Write($"{stack.Pop()} ");
            WriteLine();
        }
        static void UsingGenericDictionary()
        {
            WriteLine("\nUsingGenericDictionary()");

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["하나"] = "One";
            dic["둘"] = "Two";
            dic["셋"] = "Three";
            dic["넷"] = "Four";
            dic["다섯"] = "Five";

            Write($"{dic["하나"]} ");
            Write($"{dic["둘"]} ");
            Write($"{dic["셋"]} ");
            Write($"{dic["넷"]} ");
            WriteLine($"{dic["다섯"]}");
            
        }
        static void EnumerableGeneric()
        {
            WriteLine("\nEnumerableGeneric()");

            MyListB<string> str_list = new MyListB<string>();
            str_list[0] = "abc";
            str_list[1] = "def";
            str_list[2] = "ghi";
            str_list[3] = "jkl";
            str_list[4] = "mno";

            foreach (string str in str_list)
                Write($"{str} ");
            WriteLine();

            WriteLine();

            MyListB<int> int_list = new MyListB<int>();
            int_list[0] = 0;
            int_list[1] = 1;
            int_list[2] = 2;
            int_list[3] = 3;
            int_list[4] = 4;

            foreach (int element in int_list)
                Write($"{element} ");
            WriteLine();
        }
    }
}
