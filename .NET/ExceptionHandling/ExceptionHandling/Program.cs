using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace ExceptionHandling
{
    class InvalidArgumentException : Exception
    {
        public InvalidArgumentException()
        {

        }

        public InvalidArgumentException(string message) : base(message){
            
        }

        public object Argument { get; set; }
        public string Range { get; set; }
    }
    class FilterableException : Exception
    {
        public int ErroNo { set; get; }
    }

    class Program
    {
        static void Main()
        {
            //KillingProgram();
            /*
            TryCatch();
            Throw();
            ThrowExpression();
            Finally();
            MyException();
            ExceptionFiltering();
            StackTrace();
            */
            ArrayIndexException();

            WriteLine();
        }

        static void KillingProgram()
        {
            WriteLine("KillingProgram()");

            int[] arr = { 1, 2, 3 };
         
            for (int i = 0; i < 5; i++)
                Write($"{arr[i]} ");
            WriteLine();
            WriteLine("종료");
        }
        static void TryCatch()
        {
            WriteLine("\nTryCatch()");

            int[] arr = { 1, 2, 3 };

            try
            {
                for (int i = 0; i < 5; i++)
                    Write($"{arr[i]} ");
            }
            catch(IndexOutOfRangeException e)
            {
                WriteLine($"\n예외가 발생했습니다 : {e.Message}");
            }

            WriteLine("종료");
        }
        static void Throw()
        {
            WriteLine("\nThrow()");

            void DoSomething(int arg)
            {
                if (arg < 10)
                    WriteLine($"arg : {arg} ");
                else
                    throw new Exception("arg가 10보다 큽니다.");
            }

            try
            {
                DoSomething(1);
                DoSomething(3);
                DoSomething(5);
                DoSomething(9);
                DoSomething(11);
                DoSomething(13);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        static void ThrowExpression()
        {
            WriteLine("\nThrowExpression()");

            try
            {
                int? a = null;
                int b = a ?? throw new ArgumentNullException();
            }
            catch(ArgumentNullException e)
            {
                WriteLine(e);
            }

            try
            {
                int[] array = new[] { 1, 2, 3, };
                int index = 4;
                int value = array[index >= 0 && index < 3 ? index : throw new IndexOutOfRangeException()];
            }
            catch(IndexOutOfRangeException e)
            {
                WriteLine(e);
            }
        }
        static void Finally()
        {
            WriteLine("\nFinally()");

            int Divide(int divisor, int dividend)
            {
                try
                {
                    WriteLine("Divide() 시작");
                    return divisor / dividend;
                }
                catch (DivideByZeroException e)
                {
                    WriteLine("Divide() 예외 발생");
                    throw e;
                }
                finally
                {
                    WriteLine("Divide() 끝");
                }
            }

            try
            {
                Write("계수를 입력하세요 : ");
                string temp = ReadLine();
                int divisorA = Convert.ToInt32(temp);

                Write("피계수를 입력하세요 : ");
                temp = ReadLine();
                int dividendA = Convert.ToInt32(temp);

                WriteLine($"{divisorA} / {dividendA} = {Divide(divisorA, dividendA)}");
            }
            catch(FormatException e)
            {
                WriteLine("에러 : " + e.Message);
            }
            catch(DivideByZeroException e)
            {
                WriteLine("에러 : " + e.Message);
            }
            finally
            {
                WriteLine("프로그램을 종료합니다.");
            }
        }
        static void MyException()
        {
            WriteLine("\nMyException()");

            uint MergeARGB(uint alpha, uint red, uint green, uint blue)
            {
                uint[] args = new uint[] { alpha, red, green, blue };
                foreach(uint arg in args)
                {
                    if (arg > 255)
                        throw new InvalidArgumentException()
                        {
                            Argument = arg,
                            Range = "0 ~ 255"
                        };
                }

                return (alpha << 24 & 0xFF000000) | 
                       (red   << 16 & 0x00FF0000) |
                       (green << 8  & 0x0000FF00) |
                       (blue        & 0x000000FF);
            }

            try
            {
                WriteLine("0x{0:X}", MergeARGB(255, 111, 111, 111));
                WriteLine("0x{0:X}", MergeARGB(1, 65, 192, 128));
                WriteLine("0x{0:X}", MergeARGB(0, 255, 255, 300));
            }
            catch(InvalidArgumentException e)
            {
                WriteLine(e.Message);
                WriteLine($"Argument : {e.Argument}, Range : {e.Range}");
            }
        }
        static void ExceptionFiltering()
        {
            WriteLine("\nExceptionFiltering()");

            Write("Enter Number Between 0-10 : ");
            string input = ReadLine();
            try
            {
                int num = Int32.Parse(input);

                if (num < 0 || num > 10)
                    throw new FilterableException() { ErroNo = num };
                else
                    WriteLine($"Output : {num}");
            }
            catch (FilterableException e) when (e.ErroNo < 0)
            {
                WriteLine("Negative input is not allowed");
            }
            catch (FilterableException e) when (e.ErroNo > 10)
            {
                WriteLine("Too big number is not allowed");
            }
        }
        static void StackTrace()
        {
            WriteLine("\nStackTrace()");

            try{
                int a = 1;
                WriteLine(3 / --a);
            }
            catch(DivideByZeroException e)
            {
                WriteLine(e.StackTrace);
            }
        }
        static void ArrayIndexException()
        {
            int[] arr = new int[10];

            try
            {
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = i;
                for (int i = 0; i < arr.Length + 10; i++)
                    arr[i] = i;
          
            }
            catch(IndexOutOfRangeException e)
            {
                WriteLine("배열의 인덱스를 초과하였습니다.");

                /*
                Write("Search Array Index Size : ");
                string index = ReadLine();

                Array.Resize<int>(ref arr, arr.Length + Int32.Parse(index));
                WriteLine($"Array Resized : {arr.Length}");

                for (int i = 0; i < arr.Length; i++)
                    arr[i] = i;

                foreach (int element in arr)
                    Write($"{element} ");
                WriteLine();
                */
            }
        }
    }
}
