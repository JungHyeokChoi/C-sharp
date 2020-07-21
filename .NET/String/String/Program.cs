using System;
using System.Globalization;
using static System.Console;


namespace String
{
    class Program
    {
        static void Main()
        {
            StringSearch();
            StringModify();
            StringSlice();
            StringFormatBasic();
            StringFormatNumber();
            StringFormatDatetime();
            StringInerpolation();

            WriteLine();
        }

        private static void StringSearch()
        {
            string greeting = "Good Morning!";

            WriteLine("StringSearch()");
            WriteLine(greeting);
            WriteLine();

            //IndexOf()
            WriteLine("indexOf 'Good' : {0}",greeting.IndexOf("Good"));
            WriteLine("IndexOf 'o' : {0}", greeting.IndexOf('o'));

            //LastIndexOf()
            WriteLine("LastIndex 'Good' : {0}", greeting.LastIndexOf("Good"));
            WriteLine("LastIndex 'o' : {0}", greeting.LastIndexOf('o'));

            //StartsWith()
            WriteLine("StartsWith 'Good' : {0}", greeting.StartsWith("Good"));
            WriteLine("StartsWith 'Morning' : {0}", greeting.StartsWith("Morning"));

            //EndsWith()
            WriteLine("StartsWith 'Good' : {0}", greeting.EndsWith("Good"));
            WriteLine("StartsWith 'Morning' : {0}", greeting.EndsWith("Morning"));

            //Contains()
            WriteLine("Contains 'Evening' : {0}", greeting.Contains("Evening"));
            WriteLine("Contains 'Morning' : {0}", greeting.Contains("Morning"));

            //Replace()
            WriteLine("Replaced 'Morning' with 'Evening' : {0}", greeting.Replace("Morning", "Evening"));
        }

        private static void StringModify()
        {
            WriteLine("\nStringModify()");

            WriteLine("ToLower() : {0}", "ABC".ToLower());
            WriteLine("ToUpper() : {0}", "abc".ToUpper());

            WriteLine("Insert() : {0}", "Happy Friday!".Insert(5, "Sunny"));

            WriteLine("Remove() : {0}", "I don't love you".Remove(2, 6));

            WriteLine("Trim() : {0}", " No Spaces ".Trim());
            WriteLine("TrimStart() : {0}", " No Spaces ".TrimStart());
            WriteLine("TrimEnd() : {0}", " No Spaces ".TrimEnd());
        }

        private static void StringSlice()
        {
            WriteLine("\nStringSlice()");

            string greeting = "Good Morning";

            WriteLine(greeting.Substring(0, 5));
            WriteLine(greeting.Substring(5));
            WriteLine();

            string[] arr = greeting.Split(new string[] { " " }, StringSplitOptions.None);
            WriteLine("Word Count : {0}", arr.Length);

            foreach (string element in arr)
                WriteLine("{0}", element);
        }

        private static void StringFormatBasic()
        {
            WriteLine("\nStringFormatBasic()");

            string fmt = "{0,-20}, {1,-15}, {2, 30}";

            WriteLine(fmt, "Publisher", "Author", "Title");
            WriteLine(fmt, "Marver", "Stan Lee", "Iron Man");
            WriteLine(fmt, "Hanbit", "Sanghyun Park", "C# 7.0 Progrmming");
            WriteLine(fmt, "Prentic Hall", "K&R", "The C Progrmming Language");
        }

        private static void StringFormatNumber()
        {
            WriteLine("\nStringFormatNumber()");

            //D :10진수
            WriteLine("10진수 : {0:D}", 123);
            WriteLine("10진수 : {0:D5}", 123);

            //X : 16진수
            WriteLine("16진수 : {0:X}", 0xFF1234);
            WriteLine("16진수 : {0:X8}", 0xFF1234);

            //N : 숫자
            WriteLine("숫자 : {0:N}", 123456789);
            WriteLine("숫자 : {0:N0}", 123456789);

            //F : 고정소수점
            WriteLine("고정소수점 : {0:F}", 123.45);
            WriteLine("고정소수점 : {0:F5}", 123.45);

            //E : 공학용
            WriteLine("공학 : {0:E}", 123.456789);
        }

        private static void StringFormatDatetime()
        {
            WriteLine("\nStringFormatDatetime()");

            DateTime dt = new DateTime(2018, 11, 3, 23, 18, 22);

            WriteLine("12시간 형식 : {0:yyyy-mm-dd tt hh:mm:ss (ddd)}", dt);
            WriteLine("24시간 형식 : {0:yyyy-mm-dd HH:mm:ss(ddd)}", dt);

            CultureInfo ciko = CultureInfo.CurrentCulture;
            WriteLine();
            WriteLine(dt.ToString("yyyy-mm-dd tt hh:mm:ss (dddd)",ciko));
            WriteLine(dt.ToString("yyyy-mm-dd HH:mm:ss (dddd)",ciko));
            WriteLine(dt.ToString(ciko));

            CultureInfo ciEn = new CultureInfo("en_US");
            WriteLine();
            WriteLine(dt.ToString("yyyy-mm-dd tt hh:mm:ss dddd",ciEn));
            WriteLine(dt.ToString("yyyy-mm-dd HH:mm:ss dddd",ciEn));
            WriteLine(dt.ToString(ciEn));
        }

        private static void StringInerpolation()
        {
            WriteLine("\nStringInterpolation()");

            string name = "김튼튼";
            int age = 23;
            WriteLine($"{name,-10},{age:D3}");

            name = "박날씬";
            age = 30;
            WriteLine($"{name},{age,-10:D3}");

            name = "이비실";
            age = 17;
            WriteLine($"{name},{(age > 20 ? "성인" : "미성연자"),-10:D3}");
        }
    }
}
