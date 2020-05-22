using System;
using System.Collections;
using static System.Console;

namespace LinearStructure
{
    class MyList : IEnumerable, IEnumerator
    {
        private int[] array;
        int position = -1;

        public MyList()
        {
            array = new int[3];
        }

        public int this[int index]
        {
            get
            { return array[index]; }

            set
            {
                if(index >= array.Length)
                {
                    Array.Resize<int>(ref array, index + 1);
                    WriteLine($"Array Resized : {array.Length}");
                }

                array[index] = value;
            }
        }

        //IEnumerator 멤버
        public object Current
        {
            get { return array[position]; }
        }

        //IEnumerator 멤버
        public bool MoveNext()
        {
            if(position == array.Length - 1)
            {
                Reset();
                return false;
            }

            position++;
            return true;
        }

        //IEnumerator 멤버
        public void Reset()
        {
            position = -1;
        }

        //IEnumerable 멤버
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
                yield return (array[i]);
        }

        public int Length
        {
            get { return array.Length; }
        }
    }
    class MyEunmerator
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        public IEnumerator GetEnumerator()
        {
            yield return numbers[0];
            yield return numbers[1];
            yield return numbers[2];
            yield break;
            yield return numbers[3];
            yield return numbers[4];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArraySample();
            InitializingArray();
            DerivedFromArray();
            MoreOnArray();
            _2DArray();
            _3DArray();
            JaggedArray();
            UsingList();
            UsingQueue();
            UsingStack();
            UsingHashtable();
            InitializingCollections();
            Indexer();
            Yield();
            Enumerable();

            WriteLine();
        }

        static void ArraySample()
        {
            WriteLine("ArraySample()");

            int[] scores = new int[5];
            scores[0] = 80;
            scores[1] = 74;
            scores[2] = 81;
            scores[3] = 90;
            scores[4] = 34;

            foreach (int score in scores)
                WriteLine(score);

            int sum = 0;
            foreach (int score in scores)
                sum += score;

            int average = sum / scores.Length;

            WriteLine($"Average Score : {average}");
        }
        static void InitializingArray()
        {
            WriteLine("\nInitializingArray()");

            string[] arrayA = new string[3] { "안녕", "hello", "halo" };

            WriteLine("ArrayA...");
            foreach (string greeting in arrayA)
                WriteLine($"{greeting}");

            string[] arrayB = new string[] { "안녕", "hello", "halo" };
            WriteLine("ArrayB...");
            foreach (string greeting in arrayB)
                WriteLine($"{greeting}");

            string[] arrayC = { "안녕", "hello", "halo" };
            WriteLine("ArrayC...");
            foreach (string greeting in arrayC)
                WriteLine($"{greeting}");
        }
        static void DerivedFromArray()
        {
            WriteLine("\nDerivedFromArray()");

            int[] array = new int[] { 10, 30, 20, 7, 1 };
            WriteLine($"Type Of array : {array.GetType()}");
            WriteLine($"Base type Of array : {array.GetType().BaseType}");
        }
        static void MoreOnArray()
        {
            WriteLine("\nMoreOnArray()");

            bool CheckPassed(int score)
            {
                if (score > 60)
                    return true;
                else
                    return false;
            }

            void Print(int value)
            {
                Write($"{value} ");
            }

            int[] scores = new int[] { 80, 74, 81, 90, 34 };

            foreach (int score in scores)
                Write($"{score} ");
            WriteLine();

            Array.Sort(scores);
            Array.ForEach<int>(scores, new Action<int>(Print));
            WriteLine();

            WriteLine($"Number of dimensions : {scores.Rank}");

            WriteLine($"Binary Search : 81 is at {Array.BinarySearch<int>(scores, 81)}");
            WriteLine($"Linear Search : 90 is at {Array.IndexOf(scores, 90)}");

            WriteLine($"Everyone passed ? : {Array.TrueForAll<int>(scores, CheckPassed)}");

            int index = Array.FindIndex<int>(scores, delegate (int score)
            {
                if (score < 60)
                    return true;
                else
                    return false;
            });

            scores[index] = 61;

            WriteLine($"Everyone passed ? : {Array.TrueForAll<int>(scores, CheckPassed)}");

            WriteLine($"Old length of scores : {scores.GetLength(0)}");

            Array.Resize<int>(ref scores, 10);
            WriteLine($"New length of scores : {scores.GetLength(0)}");

            Array.ForEach<int>(scores, new Action<int>(Print));
            WriteLine();

            Array.Clear(scores, 3, 7);

            Array.ForEach<int>(scores, new Action<int>(Print));
            WriteLine();


        }
        static void _2DArray()
        {
            WriteLine("\n_2DArray()");

            int[,] arrA = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            for (int i = 0; i < arrA.GetLength(0); i++)
            {
                for (int j = 0; j < arrA.GetLength(1); j++)
                {
                    Write($"[{i}, {j}] : {arrA[i, j]}");
                }
                WriteLine();
            }
            WriteLine();

            int[,] arrB = new int[,] { { 1, 2, 3, }, { 4, 5, 6 } };
            for (int i = 0; i < arrB.GetLength(0); i++)
            {
                for (int j = 0; j < arrB.GetLength(1); j++)
                {
                    Write($"[{i}, {j}] : {arrB[i, j]}");
                }
                WriteLine();
            }
            WriteLine();

            int[,] arrC = { { 1, 2, 3, }, { 4, 5, 6 } };
            for (int i = 0; i < arrC.GetLength(0); i++)
            {
                for (int j = 0; j < arrC.GetLength(1); j++)
                {
                    Write($"[{i}, {j}] : {arrC[i, j]}");
                }
                WriteLine();
            }
            WriteLine();
        }
        static void _3DArray()
        {
            WriteLine("\n_3DArray()");

            int[,,] array = new int[4, 3, 2]
            {{ {1, 2},{3, 4},{5, 6} },
             { {1, 4},{2, 5},{3, 6} },
             { {6, 5},{4, 3},{2, 1} },
             { {6, 3},{5, 2},{3 ,1} } };

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Write("{");
                    for (int k = 0; k < array.GetLength(2); k++)
                        Write($" {array[i, j, k]} ");
                    Write("}");
                }
                WriteLine();
            }

        }
        static void JaggedArray()
        {
            WriteLine("\nJaggedArray()");

            int[][] jaggedA = new int[3][];
            jaggedA[0] = new int[5] { 1, 2, 3, 4, 5 };
            jaggedA[1] = new int[] { 10, 20, 30 };
            jaggedA[2] = new int[] { 100, 200 };

            foreach (int[] arr in jaggedA)
            {
                Write($"Length : {arr.Length}, ");
                foreach (int e in arr)
                    Write($"{e} ");
                WriteLine();
            }
            WriteLine();

            int[][] jaggedB = new int[2][]{
                new int[] {1000,2000},
                new int[4] { 6, 7, 8, 9 }
            };

            foreach (int[] arr in jaggedB)
            {
                Write($"Length : {arr.Length}, ");
                foreach (int e in arr)
                    Write($"{e} ");
                WriteLine();
            }
        }
        static void UsingList()
        {
            WriteLine("\nUsingList()");

            ArrayList list = new ArrayList();
            for (int i = 0; i < 5; i++)
                list.Add(i);

            foreach (object obj in list)
                Write($"{obj} ");
            WriteLine();

            list.RemoveAt(2);

            foreach (object obj in list)
                Write($"{obj} ");
            WriteLine();

            list.Insert(2, 2);

            foreach (object obj in list)
                Write($"{obj} ");
            WriteLine();

            list.Add("abc");
            list.Add("def");

            for(int i = 0; i < list.Count; i++)
                Write($"{list[i]} ");
            WriteLine();
        }
        static void UsingQueue()
        {
            WriteLine("\nUsingQueue()");

            Queue que = new Queue();

            que.Enqueue(1);
            que.Enqueue(2);
            que.Enqueue(3);
            que.Enqueue(4);
            que.Enqueue(5);

            while(que.Count > 0)
                Write($"{que.Dequeue()} ");

            WriteLine();
        }
        static void UsingStack()
        {
            WriteLine("\nUsginStack()");

            Stack stack = new Stack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            while (stack.Count > 0)
                Write($"{stack.Pop()} ");

            WriteLine();
        }
        static void UsingHashtable()
        {
            WriteLine("\nUsingHashtable()");

            Hashtable ht = new Hashtable();

            ht["하나"] = "one";
            ht["둘"] = "two";
            ht["셋"] = "three";
            ht["넷"] = "four";
            ht["다섯"] = "five";

            WriteLine($"{ht["하나"]}");
            WriteLine($"{ht["둘"]}");
            WriteLine($"{ht["셋"]}");
            WriteLine($"{ht["넷"]}");
            WriteLine($"{ht["다섯"]}");
        }
        static void InitializingCollections()
        {
            WriteLine("\nInitializingCollections()");

            int[] arr = { 123, 456, 789 };

            ArrayList listA = new ArrayList(arr);
            foreach (object item in listA)
                WriteLine($"ArrayList : {item}");
            WriteLine();

            Stack stack = new Stack(arr);
            foreach(object item in stack)
                WriteLine($"Stack : {item}");
            WriteLine();

            Queue queue = new Queue(arr);
            foreach (object item in queue)
                WriteLine($"Queue : {item}");
            WriteLine();

            ArrayList listB = new ArrayList() { 11, 22, 33 };
            foreach (object item in listB)
                WriteLine($"ArrayList : {item}");
            WriteLine();
        }
        static void Indexer()
        {
            WriteLine("\nIndexer()");

            MyList list = new MyList();
            for (int i = 0; i < 5; i++)
                list[i] = i;

            for (int i = 0; i < list.Length; i++)
                WriteLine(list[i]);
        }
        static void Yield()
        {
            WriteLine("\nYield()");

            var obj = new MyEunmerator();
            foreach (int i in obj)
                WriteLine($"{i} ");
        }
        static void Enumerable()
        {
            WriteLine("\nEnumerable()");

            MyList list = new MyList();
            for (int i = 0; i < 5; i++)
                list[i] = i;

            foreach (int e in list)
                WriteLine(e);
        }
    }
}
