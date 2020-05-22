using System;
using static System.Console;

namespace Method
{
    class Product
    {
        private int price = 100;

        public ref int GetPrice()
        {
            return ref price;
        }

        public void PrintPrice()
        {
            WriteLine($"Price : {price}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator(3, 4);
            WriteLine($"10번째 피보나치 수 : {Fibonacci(10)}");
            PrintProfile();
            SwapByValue();
            SwapByRef();
            RefReturn();
            Overloading();
            UsingParams();
            NamedParameter();
            OptionalParameter();
            LocalFunction();

            WriteLine();
        }

        public static int Plus(int a, int b)
        {
            return a + b;
        }
        public static int Plus(int a, int b, int c)
        {
            return a + b;
        }
        public static double Plus(double a, double b)
        {
            return a + b;
        }
        public static double Plus(int a, double b)
        {
            return a + b;
        }
        public static int Minus(int a, int b)
        {
            return a - b;
        }
        private static void Calculator(int a, int b)
        {
            WriteLine("Calculator()");

            WriteLine("{0}", Plus(a, b));
            WriteLine("{0}", Minus(a, b));
        }
        private static int Fibonacci(int n)
        {
            if (n < 2)
                return n;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        private static void PrintProfile()
        {
            WriteLine("\nPrintProfile()");

            Write("이름 : ");
            string name = ReadLine();
            Write("전화번호 : ");
            string phone = ReadLine();


            if (name == "")
            {
                WriteLine("이름을 입력해주세요.");
                return;
            }

            WriteLine($"Name : {name}, Phone : {phone}");
        }
        private static void PrintProfile(string name, string phone)
        {
            if (name == "")
            {
                WriteLine("이름을 입력해주세요.");
                return;
            }

            WriteLine($"Name : {name}, Phone : {phone}");
        }
        private static void PrintProfileOption(string name, string phone = "")
        {
            WriteLine($"Name:{name}, Phone:{phone}");
        }
        private static void Swap(int a, int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }
        private static void Swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }
        private static void SwapByValue()
        {
            WriteLine("\nSwapByValue()");

            int x = 3, y = 4;

            WriteLine($"Swap before : x = {x}, y = {y}");

            Swap(x, y);

            WriteLine($"Swap after : x = {x}, y = {y}");
        }
        private static void SwapByRef()
        {
            WriteLine("\nSwapByRef()");

            int x = 3, y = 4;

            WriteLine($"Swap before : x = {x}, y = {y}");

            Swap(ref x, ref y);

            WriteLine($"Swap after : x = {x}, y = {y}");
        }
        private static void RefReturn()
        {
            WriteLine("\nRefReturn()");

            Product carrot = new Product();
            ref int ref_local_price = ref carrot.GetPrice();
            int normal_local_price = carrot.GetPrice();

            carrot.PrintPrice();
            WriteLine($"Ref Local Price : {ref_local_price}");
            WriteLine($"Normal Local Price : {normal_local_price}");

            ref_local_price = 200;
            normal_local_price = carrot.GetPrice();

            WriteLine();
            carrot.PrintPrice();
            WriteLine($"Ref Local Price : {ref_local_price}");
            WriteLine($"Normal Local Price : {normal_local_price}");

        }
        private static void Overloading()
        {
            WriteLine("\nOverloading()");

            WriteLine(Plus(1, 2));
            WriteLine(Plus(1, 2, 3));
            WriteLine(Plus(1.0, 2.4));
            WriteLine(Plus(1, 2.4));

        }
        private static int Sum(params int[] args)
        {
            int sum = 0;
            for (int i = 0; i < args.Length; i++)
            {
                if (i > 0)
                    Write(",");

                Write(args[i]);

                sum = sum + args[i];
            }
            WriteLine();

            return sum;
        } 
        private static void UsingParams()
        {
            WriteLine("\nUsingParmas()");

            int sum = Sum(3, 4, 5, 6, 7, 8, 9, 10);

            WriteLine($"Sum : {sum}");
        }
        private static void NamedParameter()
        {
            WriteLine("\nNamedParameter()");

            PrintProfile(name: "박찬호", phone: "010-123-1234");
            PrintProfile(phone: "010-987-9876", name: "박지성");
            PrintProfile("박세리", "010-222-222");
            PrintProfile("박상현", phone:"010-567-5678");
        }
        private static void OptionalParameter()
        {
            WriteLine("\nOptionalParameter()");

            PrintProfileOption("태연");
            PrintProfileOption("윤아", "010-123-1234");
            PrintProfileOption(name:"유리");
            PrintProfileOption(name:"서현", phone:"010-789-7890");
        }
        private static string ToLowerStirng(string input)
        {
            var arr = input.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = ToLowerChar(i);
            }

            char ToLowerChar(int i)
            {
                if (arr[i] < 65 || arr[i] > 95)
                    return arr[i];
                else
                    return (char)(arr[i] + 32);
            }

            return new string(arr);
        }
        private static void LocalFunction()
        {
            WriteLine("\nLocalFunction()");

            WriteLine(ToLowerStirng("Hello!"));
            WriteLine(ToLowerStirng("Good Morning"));
            WriteLine(ToLowerStirng("This is C#"));
        }

    }
}
