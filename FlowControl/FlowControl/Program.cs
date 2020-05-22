using System;
using static System.Console;

namespace FlowControl
{
    class Program
    {
        static void Main()
        {
            
            IfElse();
            IfIf();
            Switch();
            Switch2();
            While();
            DoWhile();
            For();
            ForFor();
            ForEach();
            //InfiniteFor();
            //InfiniteWhile();
            Break();
            Continue();
            
            GoTo();

            WriteLine();
        }

        private static void IfElse()
        {
            WriteLine("IfElse()");

            Write("숫자를 입력하세요 : ");

            string input = ReadLine();
            int number = Int32.Parse(input);

            if (number < 0)
                WriteLine("음수");
            else if (number > 0)
                WriteLine("양수");
            else
                WriteLine("0");

            if(number % 2 == 0)
                WriteLine("짝수");
            else
                WriteLine("홀수");
        }   

        private static void IfIf()
        {
            WriteLine("\nIfIf()");

            Write("숫자를 입력하세요 : ");

            string input = ReadLine();
            int number = Int32.Parse(input);

            if (number > 0)
            {
                if (number % 2 == 0)
                    WriteLine("0보다 큰 짝수");
                else
                    WriteLine("0보다 큰 홀수");
            }
            else
                WriteLine("0보다 작거나 같은 수");
        }

        private static void Switch()
        {
            WriteLine("\nSwitch()");

            Write("요일을 입력하세요.(일,월,화,수,목,금,토) : ");
            string day = ReadLine();

            switch (day)
            {
                case "일":
                    WriteLine("Sunday");
                    break;
                case "월":
                    WriteLine("Monday");
                    break;
                case "화":
                    WriteLine("Tuesday");
                    break;
                case "수":
                    WriteLine("Wednesday");
                    break;
                case "목":
                    WriteLine("Thursday");
                    break;
                case "금":
                    WriteLine("Friday");
                    break;
                case "토":
                    WriteLine("Saturday");
                    break;
                default:
                    WriteLine($"{day}는(은) 요일이 아닙니다.");
                    break;
            }
        }

        private static void Switch2()
        {
            WriteLine("\nSwitch2()");

            object obj = null;

            string s = ReadLine();
            if (int.TryParse(s, out int out_i))
                obj = out_i;
            else if (float.TryParse(s, out float out_f))
                obj = out_f;
            else
                obj = s;

            switch (obj)
            {
                case int i:
                    WriteLine($"{i}는 int 형식입니다.");
                    break;
                case float f:
                    WriteLine($"{f}는 float 형식입니다.");
                    break;
                default:
                    WriteLine($"{obj}는 모르는 형식입니다.");
                    break;
            }
        }

        private static void While()
        {
            WriteLine("\nWhile()");

            int i = 10;
            while (i > 0)
            {
                WriteLine($"i = {i}");
                i--;
            }
        }

        private static void DoWhile()
        {
            WriteLine("\nDoWhile()");

            int i = 10;

            do
            {
                WriteLine($"a) i = {i}", i--);
                
            }while (i > 0);

            do
            {
                WriteLine($"b) i : {0}", i--);
            } while (i > 0);
        }

        private static void For()
        {
            WriteLine("\nFor()");

            for (int i = 0; i < 5; i++)
                WriteLine(i);
        }

        private static void ForFor()
        {
            WriteLine("\nForFor()");

            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j <= i; j++)
                {
                    Write("*");
                }
                WriteLine();
            }
        }

        private static void ForEach()
        {
            WriteLine("\nForEach()");

            int[] arr = new int[] { 1, 2, 3, 4 };

            foreach (int a in arr)
                WriteLine(a);
        }

        private static void InfiniteFor()
        {
            WriteLine("\nInfiniteFor()");

            int i = 0;
            for (; ; )
                WriteLine(i++);
        }

        private static void InfiniteWhile()
        {
            WriteLine("\nInfiniteWhile()");

            int i = 0;
            while(true)
                WriteLine(i++);
        }
      
        private static void Break()
        {
            WriteLine("\nBreak()");

            while (true)
            {
                Write("계속할까요?(예/아니오) : ");
                string answer = ReadLine();

                if (answer == "아니오")
                    break;
            }
        }

        private static void Continue()
        {
            WriteLine("\nContinue()");

            for(int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                    continue;

                WriteLine($"{i} = 홀수");
            }
        }

        private static void GoTo()
        {
            WriteLine("\nGoTo()");

            Write("종료 조건(숫자)을 입력하세요 : ");
            string input = ReadLine();

            int input_number = Convert.ToInt32(input);
            int exit_number = 0;

            for(int i= 0; i <2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    for(int k = 0;k<3; k++)
                    {
                        if (exit_number++ == input_number)
                            goto EXIT_FOR;

                        WriteLine(exit_number);
                    }
                }
            }

            goto EXIT_PROGRAM;

        EXIT_FOR:
            WriteLine("\nExit nested for...");
        EXIT_PROGRAM:
            WriteLine("Exit program...");

        }
    }
}
