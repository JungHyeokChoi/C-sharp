using System;

namespace ValueTypes
{
    class ValueTypes
    { 
        static void Main()
        {
            IntegralTypes();
            IntegralLiterals();
            SignedUnsigend();
            Overflow();
            FloatingPoint();
            Decimal();
            Char();
            String();
            Bool();
            Object();
            BoxingUnboxing();
            IntegralConversion();
            FloatConversion();
            SignedUnsignedConversion();
            FloatToIntegral();
            StringNumberConversion();
            Constant();
            Enum();
            Nullable();
            UsingVar();
            CTS();
            //RectArea();

            Console.WriteLine();
        }

        private static void IntegralTypes()
        {
            Console.WriteLine("IntegralTypes()");
            
            sbyte a = -10;
            byte  b = 40;

            Console.WriteLine($"a = {a}, b = {b}");

            short  c = -30000;
            ushort d = 60000;

            Console.WriteLine($"c = {c}, d = {d}");

            int  e = -1000_000;
            uint f = 3_0000_0000;

            Console.WriteLine($"e = {e}, f = {f}");

            long  g = -5000_0000_0000;
            ulong h = 200_0000_0000_0000_0000;

            Console.WriteLine($"g = {g}, h = {h}");
        }

        private static void IntegralLiterals()
        {
            Console.WriteLine("\nIntegralLiterals()");

            byte a = 240;
            Console.WriteLine($"a = {a}");

            byte b = 0b1111_0000;
            Console.WriteLine($"b = {b}");

            byte c = 0xF0;
            Console.WriteLine($"c = {c}");

            uint d = 0x1234_abcd;
            Console.WriteLine($"d = {d}");
        }

        private static void SignedUnsigend()
        {
            Console.WriteLine("\nSignedUnsigend()");

            byte a = 255;
            sbyte b = (sbyte)a;

            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
        }

        private static void Overflow()
        {
            Console.WriteLine("\nOverflow()");

            uint a = uint.MaxValue;

            Console.WriteLine($"a = {a}");

            a++;

            Console.WriteLine($"a = {a}");
        }

        private static void FloatingPoint()
        {
            Console.WriteLine("\nFloatingPoint()");

            float a = 3.1415_9265_3589_7932_3846f;
            Console.WriteLine($"a = {a}");

            double b = 3.1415_9265_3589_7932_3846;
            Console.WriteLine($"b = {b}");
        }

        private static void Decimal()
        {
            Console.WriteLine("\nDecimal()");

            float a = 3.1415_9265_3589_7932_3846f;
            double b = 3.1415_9265_3589_7932_3846;
            decimal c = 3.1415_9265_3589_7932_3846m;

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }

        private static void Char()
        {
            Console.WriteLine("\nChar()");

            char a = '안';
            char b = '녕';
            char c = '하';
            char d = '세';
            char e = '요';

            Console.Write(a);
            Console.Write(b);
            Console.Write(c);
            Console.Write(d);
            Console.WriteLine(e);

        }

        private static void String()
        {
            Console.WriteLine("\nString()");

            String a = "안녕하세요?";
            String b = "최정혁입니다.";

            Console.WriteLine(a);
            Console.WriteLine(b);
        }

        private static void Bool()
        {
            Console.WriteLine("\nBool()");

            bool a = true;
            bool b = false;

            Console.WriteLine(a);
            Console.WriteLine(b);
        }

        private static void Object()
        {
            Console.WriteLine("\nObject()");

            object a = 123;
            object b = 3.141592653589793238462643373279m;
            object c = true;
            object d = "안녕하세요";

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
        }

        private static void BoxingUnboxing()
        {
            Console.WriteLine("\nBoxingUnboxing()");

            int a = 123;
            object b = (object)a;
            int c = (int)b;

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);

            double x = 3.1414213;
            object y = x;
            double z = (double)y;

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
        }

        private static void IntegralConversion()
        {
            Console.WriteLine("\nIntegralConversion()");

            sbyte a = 127;
            Console.WriteLine(a);

            int b = (int)a;
            Console.WriteLine(b);

            int x = 128;
            Console.WriteLine(x);

            sbyte y = (sbyte)x;
            Console.WriteLine(y);
        }

        private static void FloatConversion()
        {
            Console.WriteLine("\nFloatConversion()");

            float a = 69.6875f;
            Console.WriteLine("a : {0}", a);

            double b = (double)a;
            Console.WriteLine("b : {0}", b);
            Console.WriteLine("69.6875 == b : {0}", 69.6875 == b);

            float x = 0.1f;
            Console.WriteLine("x : {0}", x);

            double y = (double)x;
            Console.WriteLine("y : {0}", y);

            Console.WriteLine("0.1 == y : {0}", 0.1 == y);
        }

        private static void SignedUnsignedConversion()
        {
            Console.WriteLine("\nSignedUnsignedConversion()");

            int a = 500;
            Console.WriteLine(a);

            uint b = (uint)a;
            Console.WriteLine(b);

            int x = -30;
            Console.WriteLine(x);

            uint y = (uint)x;
            Console.WriteLine(y);
        }

        private static void FloatToIntegral()
        {
            Console.WriteLine("\nFloatToIntegral()");

            float a = 0.9f;
            int b = (int)a;
            Console.WriteLine(b);

            float c = 1.1f;
            int d = (int)c;
            Console.WriteLine(d);
        }

        private static void StringNumberConversion()
        {
            Console.WriteLine("\nStringNumberConversion()");

            int a = 123;
            string b = a.ToString();
            Console.WriteLine(b);

            float c = 3.14f;
            string d = c.ToString();
            Console.WriteLine(d);

            string e = "123456";
            int f = Convert.ToInt32(e);
            Console.WriteLine(f);

            string g = "1.2345";
            float h = float.Parse(g);
            Console.WriteLine(h);
        }

        private static void Constant()
        {
            Console.WriteLine("\nConstant()");

            const int MAX_INT = 2147483647;
            const int MIN_INT = -2147483648;

            Console.WriteLine(MAX_INT);
            Console.WriteLine(MIN_INT);
        }

        private enum DialogResult { YES, NO, CANCEL, CONFIRM, OK }
        private enum DialogResult_A { YES = 10, NO, CANCEL, CONFIRM = 50, OK }

        private static void Enum()
        {
            Console.WriteLine("\nEnum()");

            Console.WriteLine((int)DialogResult.YES);
            Console.WriteLine((int)DialogResult.NO);
            Console.WriteLine((int)DialogResult.CANCEL);
            Console.WriteLine((int)DialogResult.CONFIRM);
            Console.WriteLine((int)DialogResult.OK + "\n");

            DialogResult result = DialogResult.YES;

            Console.WriteLine(result == DialogResult.YES);
            Console.WriteLine(result == DialogResult.NO);
            Console.WriteLine(result == DialogResult.CANCEL);
            Console.WriteLine(result == DialogResult.CONFIRM);
            Console.WriteLine(result == DialogResult.OK);
            Console.WriteLine();

            Console.WriteLine((int)DialogResult_A.YES);
            Console.WriteLine((int)DialogResult_A.NO);
            Console.WriteLine((int)DialogResult_A.CANCEL);
            Console.WriteLine((int)DialogResult_A.CONFIRM);
            Console.WriteLine((int)DialogResult_A.OK);
        }

        private static void Nullable()
        {
            Console.WriteLine("\nNullable()");

            int? a = null;

            Console.WriteLine(a.HasValue);
            Console.WriteLine(a != null);

            a = 3;

            Console.WriteLine(a.HasValue);
            Console.WriteLine(a != null);
            Console.WriteLine(a.Value);
        }

        private static void UsingVar()
        {
            Console.WriteLine("\nUsingVar()");

            var a = 20;
            Console.WriteLine("Type : {0}, Value : {1}", a.GetType(), a);

            var b = 3.1414213;
            Console.WriteLine("Type : {0}, Value : {1}", b.GetType(), b);

            var c = "Hello World";
            Console.WriteLine("Type : {0}, Value : {1}", c.GetType(), c);

            var d = new int[] { 10, 20, 30 };
            Console.Write("Type : {0}, ", d.GetType());
            foreach (var e in d)
                Console.Write("{0} ", e);

            Console.WriteLine();
        }

        private static void CTS()
        {
            Console.WriteLine("\nCTS()");

            System.Int32 a = 123;
            int b = 456;

            Console.WriteLine("a type : {0}, value : {1}", a.GetType().ToString(), a);
            Console.WriteLine("b type : {0}, value : {1}", b.GetType().ToString(), b);

            System.String c = "abc";
            String d = "def";

            Console.WriteLine("c type : {0}, value : {1}", c.GetType().ToString(), c);
            Console.WriteLine("d type : {0}, value : {1}", d.GetType().ToString(), d);
        }

        private static void RectArea()
        {
            Console.WriteLine("\nRectArea()");

            Console.WriteLine("사각형의 너비를 입력하세요.");
            string width = Console.ReadLine();

            Console.WriteLine("사각형의 높이를 입력하세요.");
            string height = Console.ReadLine();

            Console.WriteLine("사각형의 넓이 : {0}", Convert.ToInt32(width) * Convert.ToInt32(height));
        }


    }
}