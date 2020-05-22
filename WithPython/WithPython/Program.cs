using System;
using static System.Console;

using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;


namespace WithPython
{
    class Program
    {
        static void Main(string[] args)
        {
            WithPython();
        }

        static void WithPython()
        {
            ScriptEngine engin = Python.CreateEngine();
            ScriptScope scope = engin.CreateScope();
            scope.SetVariable("n", "박상현");
            scope.SetVariable("p", "010-123-4566");
        
            //Python 들여쓰기 유의!!
            ScriptSource source = engin.CreateScriptSourceFromString(
                @"
class NameCard :
    name = ''
    phone = ''

    def __init__(self,name,phone) :
        self.name = name
        self.phone = phone

    def printNameCard(self) :
        print self.name + ', ' + self.phone

NameCard(n,p)
");

            dynamic result = source.Execute(scope);

            result.printNameCard();

            WriteLine("{0}, {1}", result.name, result.phone);
        }
    }
}
