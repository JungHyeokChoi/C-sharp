using System;
using static System.Console;

namespace BrainCSharp
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            WriteLine("Hello World!\n");
            Test_Write();
        }

        static void Test_Write()
        {
            Console.WriteLine("여러분, 안녕하세요?\n반갑습니다!\n");
        }
    }
}
