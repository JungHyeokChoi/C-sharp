using System;
using System.Collections.Generic;
using static System.Console;

namespace Dynamic
{
    class Duck
    {
        public void Walk()
        {
            WriteLine(this.GetType() + "Walk");
        }

        public void Swim()
        {
            WriteLine(this.GetType() + "Swim");
        }
    
        public void Quack()
        {
            WriteLine(this.GetType() + "Quack");
        }
    }
    class Mallard : Duck { }
    class Robot
    {
        public void Walk()
        {
            WriteLine("Robot.Walk");
        }

        public void Swim()
        {
            WriteLine("Robot.Swim");
        }

        public void Quack()
        {
            WriteLine("Robot.Quack");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            DuckTyping();
        }

        static void DuckTyping()
        {
            WriteLine("DuckTyping()");

            dynamic[] arr = new dynamic[] { new Duck(), new Mallard(), new Robot()};

            foreach(dynamic duck in arr)
            {
                WriteLine(duck.GetType());
                WriteLine(duck is Duck);

                duck.Walk();
                duck.Swim();
                duck.Quack();

                WriteLine();
            }
        }
    }
}
