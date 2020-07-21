using System;
using System.Collections;
using static System.Console;

namespace Operators
{
    class Program
    {
        static void Main()
        {
            ArithmaticOperators();
            InDecOperator();
            StringConcatente();
            RelationalOperator();
            LogicalOperator();
            ConditionalOperator();
            //NullConditionalOperator();
            ShiftOperator();
            BitwiseOperator();
            AssignmentOperator();
            NullCoalescing();

            WriteLine();
        }

        private static void ArithmaticOperators()
        {
            WriteLine("ArithmaticOperators()");

            int a = 111 + 222;
            WriteLine($"a : {a}");

            int b = a - 100;
            WriteLine($"b : {b}");

            int c = b * 10;
            WriteLine($"c : {c}");

            double d = c / 6.3;
            WriteLine($"d : {d}");

            WriteLine($"22 / 7 = {22 / 7}{22 % 7}");
        }

        private static void InDecOperator()
        {
            WriteLine("\nInDecOperator()");

            int a = 10;
            WriteLine(a++);
            WriteLine(++a);

            WriteLine(a--);
            WriteLine(--a);
        }

        private static void StringConcatente()
        {
            WriteLine("\nStinrgConcatente()");

            string result = "123" + "456";
            WriteLine(result);

            result = "Hello" + " " + "World";
            WriteLine(result);
        }

        private static void RelationalOperator()
        {
            WriteLine("\nRelationalOperator()");

            WriteLine($"3 > 4   : {3 > 4}");
            WriteLine($"3 >= 4  : {3 >= 4}");
            WriteLine($"3 < 4   : {3 < 4}");
            WriteLine($"3 <= 4  : {3 <= 4}");
            WriteLine($"3 == 4  : {3 == 4}");
            WriteLine($"3 != 4  : {3 != 4}");
        }

        private static void LogicalOperator()
        {
            WriteLine("\nLogicalOperator()");

            WriteLine("Testing && .... ");
            WriteLine($"1 > 0 && 4 < 5 : {1 > 0 && 4 < 5}");
            WriteLine($"1 > 0 && 4 > 5 : {1 > 0 && 4 > 5}");
            WriteLine($"1 == 0 && 4 > 5 : {1 == 0 && 4 > 5}");
            WriteLine($"1 == 0 && 4 < 5 : {1 == 0 && 4 < 5}");

            WriteLine("\nTesting || ....");
            WriteLine($"1 > 0 || 4 < 5 : {1 > 0 || 4 < 5}");
            WriteLine($"1 > 0 || 4 > 5 : {1 > 0 || 4 > 5}");
            WriteLine($"1 == 0 || 4 > 5 : {1 == 0 || 4 > 5}");
            WriteLine($"1 == 0 || 4 < 5 : {1 == 0 || 4 < 5}");

            WriteLine("\nTesting ! ...");
            WriteLine($"!True {!true}");
            WriteLine($"!False {!false}");
        }

        private static void ConditionalOperator()
        {
            WriteLine("\nConditionalOperator()");

            string result = (10 % 2) == 0 ? "짝수" : "홀수";

            WriteLine(result);
        }

        private static void NullConditionalOperator()
        {
            WriteLine("\nNullConditionalOperator()");

            ArrayList arr = null;
            arr?.Add("야구");
            arr?.Add("축구");
            WriteLine($"Count : {arr?.Count}");
            WriteLine($"{arr[0]}");
            WriteLine($"{arr[1]}");

            arr = new ArrayList();
            arr?.Add("야구");
            arr?.Add("축구");
            WriteLine($"Count : {arr?.Count}");
            WriteLine($"{arr[0]}");
            WriteLine($"{arr[1]}");
        }

        private static void ShiftOperator()
        {
            WriteLine("\nShiftOperator()");

            WriteLine("Testing << ...");

            int a = 1;
            WriteLine("a      : {0:D5} (0x{0:X8})", a);
            WriteLine("a << 1 : {0:D5} (0x{0:X8})", a << 1);
            WriteLine("a << 2 : {0:D5} (0x{0:X8})", a << 2);
            WriteLine("a << 5 : {0:D5} (0x{0:X8})", a << 5);

            WriteLine("Testing >> ...");

            int b = 255;
            WriteLine("a      : {0:D5} (0x{0:X8})", b);
            WriteLine("b >> 1 : {0:D5} (0x{0:X8})", b >> 1);
            WriteLine("b >> 2 : {0:D5} (0x{0:X8})", b >> 2);
            WriteLine("b >> 5 : {0:D5} (0x{0:X8})", b >> 5);

            WriteLine("Testing >> 2...");

            int c = -255;
            WriteLine("c      : {0:D5} (0x{0:X8})", c);
            WriteLine("c >> 1 : {0:D5} (0x{0:X8})", c >> 1);
            WriteLine("c >> 2 : {0:D5} (0x{0:X8})", c >> 2);
            WriteLine("c >> 5 : {0:D5} (0x{0:X8})", c >> 5);
        }

        private static void BitwiseOperator()
        {
            WriteLine("\nBitwiseOperator()");

            int a = 9;
            int b = 10;

            WriteLine($"{a} & {b} : {a & b}");
            WriteLine($"{a} | {b} : {a | b}");
            WriteLine($"{a} ^ {b} : {a ^ b}");

            int c = 255;
            WriteLine("~{0}(0x{0:X8}) : {1}(0x{1:X8})", c, ~c);
        }

        private static void AssignmentOperator()
        {
            WriteLine("\nAssignmentOperator()");

            int a;
            a = 100;
            WriteLine($"a = 100 : {a}");
            a += 90;
            WriteLine($"a += 90 : {a}");
            a -= 80;
            WriteLine($"a -= 80 : {a}");
            a *= 70;
            WriteLine($"a *= 70 : {a}");
            a /= 60;
            WriteLine($"a /= 60 : {a}");
            a %= 50;
            WriteLine($"a %= 50 : {a}");
            a &= 40;
            WriteLine($"a &= 40 : {a}");
            a |= 30;
            WriteLine($"a != 30 : {a}");
            a ^= 20;
            WriteLine($"a ^= 20 : {a}");
            a <<= 10;
            WriteLine($"a <<= 10 : {a}");
            a >>= 1;
            WriteLine($"a >>= 1 : {a}");
        }

        private static void NullCoalescing()
        {
            WriteLine("\nNullCoalescing()");

            int? num = null;
            WriteLine($"{num ?? 0}");

            num = 99;
            WriteLine($"{num ?? 0}");

            string str = null;
            WriteLine($"{str ?? "Default"}");

            str = "Specific";
            WriteLine($"{str ?? "Default"}");
        }
    }
}
