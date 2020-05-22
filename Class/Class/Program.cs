using System;
using System.Collections.Generic;
using static System.Console;
using MyExtension;

namespace MyExtension
{
    public static class IntegerExtension
    {
        public static int Square(this int myInt)
        {
            return myInt * myInt;
        }

        public static int Power(this int myInt, int exponet)
        {
            int result = myInt;
            for (int i = 1; i < exponet; i++)
                result = result * myInt;

            return result;
        }
    }
}

namespace Class
{
    struct Point3D
    {
        public int X;
        public int Y;
        public int Z;

        public Point3D(int X, int Y, int Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public override string ToString()
        {
            return string.Format($"{X}, {Y}, {Z}");
        }
    }


    class CatA
    {
        public string Name;
        public string Color;

        public CatA()
        {
            Name = "";
            Color = "";
        }

        public CatA(string _Name, string _Color)
        {
            Name = _Name;
            Color = _Color;
        }
        /*
        ~CatA()
        {
            WriteLine($"{Name} : 잘가~");
        }
        */
        public void Meow()
        {
            WriteLine($"{Name} : 야옹~");           
        }
    }
    class Global
    {
        public static int Count = 0;
    }
    class ClassA
    {
        public ClassA()
        {
            Global.Count++;
        }
    }
    class ClassB
    {
        public ClassB()
        {
            Global.Count++;
        }
    }
    class MyClassA
    {
        public int MyField1;
        public int MyField2;

        public MyClassA DeepCopy()
        {
            MyClassA newCopy = new MyClassA();
            newCopy.MyField1 = this.MyField1;
            newCopy.MyField2 = this.MyField2;

            return newCopy;
        }
    }
    class Employee
    {
        private string Name;
        private string Position;

        public void SetName(string Name)
        {
            this.Name = Name;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetPosition(string Position)
        {
            this.Position = Position;
        }
        public string GetPosition()
        {
            return Position;
        }
    }
    class MyClassB
    {
        int a, b, c;

        public MyClassB()
        {
            this.a = 5425;
            WriteLine("MyClassB()");
        }
        public MyClassB(int b) : this()
        {
            this.b = b;
            WriteLine($"MyClassB {b}");
        }
        public MyClassB(int b, int c) : this(b)
        {
            this.c = c;
            WriteLine($"MyClassB {b},{c}");
        }
        public void PrintFields()
        {
            WriteLine($"a:{a}, b:{b}, c{c}");
        }
    }
    class WaterHeater
    {
        protected int temperature;

        public void SetTemperature(int temperature)
        {
            if(temperature < -5 || temperature > 42)
            {
                throw new Exception("Out of temperature range");
            }

            this.temperature = temperature;
        }

        internal void TurnOnWater()
        {
            WriteLine($"Turn on water : {temperature}");
        }
    }
    class BaseA
    {
        protected string Name;
        public BaseA(string Name){
            this.Name = Name;
            WriteLine($"{this.Name}.BaseA()");
        }
        /*
        ~BaseA()
        {
            WriteLine($"{this.Name}.~BaseA()");
        }
        */
        public void BaseAMethod()
        {
            WriteLine($"{Name}.BaseAMethod()");
        }
    }
    class DerivedA : BaseA
    {
        public DerivedA(string Name) : base(Name)
        {
            WriteLine($"{this.Name}.DerivedA()");
        }
        /*
        ~DerivedA()
        {
            WriteLine($"{this.Name}.~DerivedA()");
        }
        */
        public void DerivedAMethod()
        {
            WriteLine($"{Name}.DerivedAMethod()");
        }
    } 
    class Mammal
    {
        public void Nurse()
        {
            WriteLine("Nurse()");
        }
    }
    class Dog : Mammal
    {
        public void Bark()
        {
            WriteLine("Bark()");
        }
    }
    class Cat : Mammal
    {
        public void Meow()
        {
            WriteLine("Meow()");
        }
    }
    class ArmorSuite
    {
        public virtual void Initialize()
        {
            WriteLine("Armored");
        }
    }
    class IronMan : ArmorSuite
    {
        public override void Initialize()
        {
            base.Initialize();
            WriteLine("Repulsor Rays Armed");
        }
    }
    class WarMachine : ArmorSuite
    {
        public override void Initialize()
        {
            base.Initialize();
            WriteLine("Double-Barrel Cannons Aremd");
            WriteLine("Micro-Rocket Lancher Aremd");
        }
    }
    class BaseB
    {
        public void MyMethod()
        {
            WriteLine("BaseB.MyMethod()");
        }
    }
    class DerivedB : BaseB
    {
        public new void MyMethod()
        {
            WriteLine("DerivedB.MyMethod()");
        }
    }
    /*
    class BaseC
    {
        public virtual void SealMe()
        {

        }
    }
    class DerivedC : BaseC
    {
        public sealed override void SealMe()
        {
        }
    }
    
    class WantToOverride : DerivedC
    {
        //Error
        public override void SealMe()
        {

        }
    }
    */
    class Configuration
    {
        List<ItemValue> listConfig = new List<ItemValue>();

        public void SetConfig(string item, string value)
        {
            ItemValue iv = new ItemValue();
            iv.SetValue(this, item, value);
        }

        public string GetConfig(string item)
        {
            foreach(ItemValue iv in listConfig)
            {
                if (iv.GetItem() == item)
                    return iv.GetValue();
            }

            return "";
        }

        private class ItemValue
        {
            private string item;
            private string value;

            public void SetValue(Configuration config, string item, string value)
            {
                this.item = item;
                this.value = value;

                bool found = false;

                for (int i = 0; i < config.listConfig.Count; i++)
                {
                    if (config.listConfig[i].item == item)
                    {
                        config.listConfig[i] = this;
                        found = true;
                        break;
                    }
                }
                if (found == false)
                    config.listConfig.Add(this);

            }
            public string GetItem()
            { return item; }
            public string GetValue()
            { return value; }

        }

    }
    partial class MyClassC
    {
        public void Method1()
        {
            WriteLine("Method1");
        }
        public void Method2()
        {
            WriteLine("Method2");
        }
    }
    partial class MyClassC
    {
        public void Method3()
        {
            WriteLine("Method3");
        }
        public void Method4()
        {
            WriteLine("Method4");
        }
    }




    class Program
    {
        static void Main()
        {
            BasicClass();
            Constructor();
            GlobalClass();
            DeepCopyClass();
            This();
            ThisConstructor();
            AccessModifier();
            Inheritance();
            TypeCasting();
            Overriding();
            MethodHiding();
            NestedClass();
            PartialClass();
            MyExtension();
            Struct();
            Tuple();

            WriteLine();
        }

        static void BasicClass()
        {
            WriteLine("BasicCLass()");

            CatA kitty = new CatA();
            kitty.Color = "하얀색";
            kitty.Name = "키티";
            kitty.Meow();
            WriteLine($"{kitty.Name} : {kitty.Color}");

            CatA nero = new CatA();
            nero.Color = "검정색";
            nero.Name = "네로";
            nero.Meow();
            WriteLine($"{nero.Name} : {nero.Color}");
        }
        static void Constructor()
        {
            WriteLine("\nConstructor()");

            CatA kitty = new CatA("노루", "황색");
            kitty.Meow();
            WriteLine($"{kitty.Name} : {kitty.Color}");

            CatA nero = new CatA("미로", "흰검색");
            nero.Meow();
            WriteLine($"{nero.Name} : {nero.Color}");
        }
        static void GlobalClass()
        {
            WriteLine("\nGlobalClass()");

            WriteLine($"Global.Count : {Global.Count}");

            new ClassA();
            new ClassA();
            new ClassB();
            new ClassB();

            WriteLine($"Global.Count : {Global.Count}");
        }
        static void DeepCopyClass()
        {
            WriteLine("\nDeepCopyClass()");

            WriteLine("Shallow Copy");
            {
                MyClassA source = new MyClassA();
                source.MyField1 = 10;
                source.MyField2 = 20;

                MyClassA target = source;
                target.MyField2 = 30;

                WriteLine($"{source.MyField1} {source.MyField2}");
                WriteLine($"{target.MyField1} {target.MyField2}");
            }

            WriteLine("Deep Copy");
            {
                MyClassA source = new MyClassA();
                source.MyField1 = 10;
                source.MyField2 = 20;

                MyClassA target = source.DeepCopy();
                target.MyField2 = 30;

                WriteLine($"{source.MyField1} {source.MyField2}");
                WriteLine($"{target.MyField1} {target.MyField2}");
            }
        }
        static void This()
        {
            WriteLine("\nThis()");

            Employee pooh = new Employee();
            pooh.SetName("pooh");
            pooh.SetPosition("Waiter");
            WriteLine($"{pooh.GetName()} {pooh.GetPosition()}");

            Employee tigger = new Employee();
            tigger.SetName("tigger");
            tigger.SetPosition("Cleaner");
            WriteLine($"{tigger.GetName()} {tigger.GetPosition()}");
        }
        static void ThisConstructor()
        {
            WriteLine("\nThisConstructor()");
            
            MyClassB a = new MyClassB();
            a.PrintFields();
            WriteLine();

            MyClassB b = new MyClassB(1);
            b.PrintFields();
            WriteLine();

            MyClassB c = new MyClassB(10, 20);
            c.PrintFields();
            WriteLine();
        }
        static void AccessModifier()
        {
            WriteLine("\nAccessModifier()");

            try
            {
                WaterHeater heater = new WaterHeater();
                heater.SetTemperature(20);
                heater.TurnOnWater();

                heater.SetTemperature(-2);
                heater.TurnOnWater();

                heater.SetTemperature(50);
                heater.TurnOnWater();
            }
            catch(Exception e)
            {
                WriteLine(e.Message);
            }

            
        }
        static void Inheritance()
        {
            WriteLine("\nInheritance()");

            BaseA a = new BaseA("a");
            a.BaseAMethod();

            DerivedA b = new DerivedA("b");
            b.BaseAMethod();
            b.DerivedAMethod();
        }
        static void TypeCasting()
        {
            WriteLine("\nTypeCasting()");

            Mammal mammal = new Dog();
            Dog dog;

            if(mammal is Dog)
            {
                dog = (Dog)mammal;
                dog.Bark();
            }

            Mammal mammal2 = new Cat();
            Cat cat = mammal2 as Cat;
            if (cat != null)
                cat.Meow();

            Cat cat2 = mammal as Cat;
            if (cat2 != null)
                cat.Meow();
            else
                WriteLine("Cat2 is not a Cat");
        }
        static void Overriding()
        {
            WriteLine("\nOverriding()");

            WriteLine("Creating ArmorSuite...");
            ArmorSuite armorsuite = new ArmorSuite();
            armorsuite.Initialize();

            WriteLine("\nCreating IronMan...");
            IronMan ironman = new IronMan();
            ironman.Initialize();

            WriteLine("\nCreating WarMachine...");
            WarMachine warmachine = new WarMachine();
            warmachine.Initialize();
        }
        static void MethodHiding()
        {
            WriteLine("\nMethodHiding()");

            BaseB baseObj = new BaseB();
            baseObj.MyMethod();

            DerivedB derivedObj = new DerivedB();
            derivedObj.MyMethod();

            BaseB baseOrDerived = new DerivedB();
            baseOrDerived.MyMethod();
        }
        static void NestedClass()
        {
            WriteLine("\nNestedClass()");

            Configuration config = new Configuration();
            config.SetConfig("Version", "V 5.0");
            config.SetConfig("Size", "655,324 KB");

            WriteLine(config.GetConfig("Version"));
            WriteLine(config.GetConfig("Size"));

            config.SetConfig("Version", "V 5.0.1");
            WriteLine(config.GetConfig("Version"));
        }
        static void PartialClass()
        {
            WriteLine("\nPartialClass()");

            MyClassC obj = new MyClassC();
            obj.Method1();
            obj.Method2();
            obj.Method3();
            obj.Method4();

        }
        static void MyExtension()
        {
            WriteLine("\nMyExtension()");

            WriteLine($"3^2 : {3.Square()}");
            WriteLine($"3^4 : {3.Power(4)}");
            WriteLine($"2^10 : {2.Power(10)}");
        }
        static void Struct()
        {
            WriteLine("\nStruct()");

            Point3D p3d1;
            p3d1.X = 10;
            p3d1.Y = 20;
            p3d1.Z = 40;

            WriteLine(p3d1.ToString());

            Point3D p3d2 = new Point3D(100, 200, 300);
            Point3D p3d3 = p3d2;
            p3d3.Z = 400;

            WriteLine(p3d2.Z.ToString());
            WriteLine(p3d3.Z.ToString());
        }
        static void Tuple()
        {
            WriteLine("\nTuple()");

            var a = ("슈퍼맨", 9999);
            WriteLine($"{a.Item1}, {a.Item2}");

            var b = (Name: "박상현", Age: 17);
            WriteLine($"{b.Name}, {b.Age}");

            var (name, age) = b;
            WriteLine($"{name}, {age}");

            b = a;
            WriteLine($"{b.Name}, {b.Age}");

        }
    }
}
