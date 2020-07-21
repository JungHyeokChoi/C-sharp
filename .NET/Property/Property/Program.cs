using System;
using static System.Console;
namespace Property
{
    interface INamedValue
    {
        string Name
        {
            get;
            set;
        }

        string Value
        {
            get;
            set;
        }
    }

    abstract class Product
    {
        private static int serial = 0;
        public string SerialID
        {
            get { return String.Format("{0:d5}", serial++); }
        }

        abstract public DateTime ProductDate
        {
            get;
            set;
        }
    }

    class BirthdayInfo
    {
        private string name;
        private DateTime birthday;

        public string Name
        {
            get
            { return name;}
            set
            { name = value;}
        }

        public DateTime Birthday
        {
            get
            { return birthday;}
            set
            { birthday = value;}
        }

        public int Age
        {
            get
            { return new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year; }
        }
    }
    class BirthdayInfoAuto
    {
        public string Name { get; set; } = "Unknown";
        public DateTime Birthday { get; set; } = new DateTime(1, 1, 1);
        public int Age
        {
            get
            { return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year; }
        }
    }
    class NamedValue : INamedValue
    {
        public string Name
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }
    class MyProduct : Product
    {
        public override DateTime ProductDate
        {
            get;
            set;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Property();
            AutoImplementedProperty();
            ConstructorWithProperty();
            AnonymousType();
            PropertiesinInterface();
            PropertiesInAbstractClass();

            WriteLine();
        }

        static void Property()
        {
            WriteLine("Property()");

            BirthdayInfo birth = new BirthdayInfo();
            birth.Name = "서현";
            birth.Birthday = new DateTime(1991, 6, 28);

            WriteLine($"Name : {birth.Name}");
            WriteLine($"Birthday : {birth.Birthday}");
            WriteLine($"Age : {birth.Age}");

        }
        static void AutoImplementedProperty()
        {
            WriteLine("\nAutoImplementedProperty()");

            BirthdayInfoAuto birth = new BirthdayInfoAuto();
            WriteLine($"Name : {birth.Name}");
            WriteLine($"Birthday : {birth.Birthday}");
            WriteLine($"Age : {birth.Age}");

            birth.Name = "서현";
            birth.Birthday = new DateTime(1991, 6, 28);

            WriteLine($"Name : {birth.Name}");
            WriteLine($"Birthday : {birth.Birthday.ToShortDateString()}");
            WriteLine($"Age : {birth.Age}");
        }
        static void ConstructorWithProperty()
        {
            WriteLine("\nConstructorWithProperty()");

            BirthdayInfo birth = new BirthdayInfo()
            {
                Name = "서현",
                Birthday = new DateTime(1991, 6, 28)
            };

            WriteLine($"Name : {birth.Name}");
            WriteLine($"Birthday : {birth.Birthday}");
            WriteLine($"Age : {birth.Age}");
        }
        static void AnonymousType()
        {
            WriteLine("\nAnonymousType()");

            var a = new { Name = "박상현", Age = 123 };
            WriteLine($"Name : {a.Name}, Age : {a.Age}");

            var b = new { Subject = "수학", Scores = new int[] { 90, 80, 70, 60 } };
            Write($"Subject : {b.Subject}, Score : ");
            foreach (var score in b.Scores)
                Write($"{score} ");

            WriteLine();
        }
        static void PropertiesinInterface()
        {
            WriteLine("\nPropertiesinInterface()");

            NamedValue name = new NamedValue()
            { Name = "이름", Value = "박상현" };

            NamedValue height = new NamedValue()
            { Name = "키", Value = "177cm" };

            NamedValue weight = new NamedValue()
            { Name = "몸무게", Value = "90kg" };

            WriteLine($"{name.Name} : {name.Value}");
            WriteLine($"{height.Name} : {height.Value}");
            WriteLine($"{weight.Name} : {weight.Value}");
        }
        static void PropertiesInAbstractClass()
        {
            WriteLine("\nPropertiesInAbstractClass()");

            Product product1 = new MyProduct()
            { ProductDate = new DateTime(2018, 1, 10) };

            WriteLine($"Product : {product1.SerialID}, Product Date : {product1.ProductDate}");

            Product product2 = new MyProduct()
            { ProductDate = new DateTime(2018, 2, 3) };

            WriteLine($"Product : {product2.SerialID}, Product Date : {product2.ProductDate}");
        }
    }
}
