using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using static System.Console;

namespace Lambda
{
    delegate int Calculate(int a, int b);
    delegate string Concatenate(string[] args);

    class FriendList
    {
        private List<string> list = new List<string>();

        public void Add(string name) => list.Add(name);
        public void Remove(string name) => list.Remove(name);
        public void PrintAll()
        {
            foreach (var s in list)
                WriteLine(s);
        }

        public FriendList() => WriteLine("FriendList()");
        ~FriendList() => WriteLine("~FriendList()");

        //public int Capacity => list.Capacity;
        public int Capacity
        {
            get => list.Capacity;
            set => list.Capacity = value;
        }

        //public string this[int index] => list[index];
        public string this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }
    }

    class Program
    {
        static void Main()
        {
            SampleLambda();
            StatemenetLambda();
            FuncTest();
            ActionTest();
            UsingExpressionTree();
            ExpressionBodiedMemner();

            WriteLine();
        }

        static void SampleLambda()
        {
            WriteLine("SampleLambda()");

            Calculate calc = (a, b) => a + b;
            WriteLine($"{3} + {4} = {calc(3, 4)}");
        }
        static void StatemenetLambda()
        {
            WriteLine("\nStatemenetLambda()");

            string input = ReadLine();
            string[] str_arr = input.Split();

            Concatenate concat = (arr) =>
            {
                string result = "";
                foreach (string s in arr)
                    result += s;

                return result;
            };

            WriteLine(concat(str_arr));    
        }
        static void FuncTest()
        {
            WriteLine("\nFuncTest()");

            Func<int> funcA = () => 10;
            WriteLine($"funcA : {funcA()}");

            Func<int, int> funcB = (x) => x * 2;
            WriteLine($"funcB : {funcB(4)}");

            Func<double, double, double> funcC = (x, y) => x / y;
            WriteLine($"funcC : {funcC(22, 7)}");
        }
        static void ActionTest()
        {
            WriteLine("\nActionTest()");

            Action actA = () => WriteLine("Action()");
            actA();

            int result = 0;
            Action<int> actB = (x) => result = x * x;
            actB(3);
            WriteLine($"result : {result}");

            Action<double, double> actC = (x, y) =>
            {
                double pi = x / y;
                WriteLine($"Action<T1,T2>{x},{y} : {pi}");
            };
            actC(22.0, 7.0);
        }
        static void UsingExpressionTree()
        {
            WriteLine("\nUsingExpressionTree()");

            Expression constA = Expression.Constant(1);
            Expression constB = Expression.Constant(2);

            Expression leftExp = Expression.Multiply(constA, constB);

            Expression paramA = Expression.Parameter(typeof(int));
            Expression paramB = Expression.Parameter(typeof(int));

            Expression rightExp = Expression.Subtract(paramA, paramB);

            Expression exp = Expression.Add(leftExp, rightExp);

            Expression<Func<int, int, int>> expression = Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>(
                exp, new ParameterExpression[]
                {
                    (ParameterExpression)paramA,
                    (ParameterExpression)paramB
                });

            Func<int, int, int> func = expression.Compile();

            WriteLine($"1*2+({7}-{8}) = {func(7, 8)}");
        }
        static void ExpressionBodiedMemner()
        {
            WriteLine("\nExpressionBodiedMemner()");

            FriendList obj = new FriendList();
            obj.Add("Eeny");
            obj.Add("Meeny");
            obj.Add("Miny");
            obj.Remove("Eeny");
            obj.PrintAll();

            WriteLine($"{obj.Capacity}");
            obj.Capacity = 10;
            WriteLine($"{obj.Capacity}");

            WriteLine($"{obj[0]}");
            obj[0] = "Moe";
            obj.PrintAll();
        }
    }
}
