using System;
using System.Reflection.Emit;
using System.Reflection;
using static System.Console;
using System.Runtime.CompilerServices;

namespace MetaData
{
    class Profile
    {
        private string name;
        private string phone;

        public Profile()
        {
            name = "";
            phone = "";
        }
        public Profile(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }
        public void Print()
        {
            WriteLine($"{name}, {phone}");
        }
        public string Name { get; set; }
        public string Phone { get; set; }

    }
    class MyClassA
    {
        [Obsolete("OldMethod()는 폐기되었습니다. NewMethod()를 이용하세요.")]
        public void OldMethod()
        {
            WriteLine("I'm old");
        }
        public void NewMethod()
        {
            WriteLine("I'm new");
        }
    }
    public static class Trace
    {
        public static void WriteLine(string message, 
            [CallerFilePath] string file = "", [CallerLineNumber] int line = 0, [CallerMemberName] string member = "")
        {
            Console.WriteLine($"Path: {file}, Line: {line}, Method: {member}, Message: {message}");
        }
    }
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    class History : System.Attribute
    {
        private string programmer;
        public double version;
        public string changes;

        public History(string programmer)
        {
            this.programmer = programmer;
            version = 1.0;
            changes = "Frist release";
        }

        public string GetProgrammer(){
            return programmer;
        }
    }

    [History("Sean", version = 0.1, changes = "2017-11-01 Created class stub")]
    [History("Bob", version = 0.2, changes = "2017-12-03 Added Func() Method")]
    class MyClassB
    {
        public void Func()
        {
            WriteLine("Func()");
        }
    }

    class Program
    {
        static void Main()
        {
            _GetType();
            DynamicInstance();
            EmitTest();
            BasicAttribute();
            CallerInfo();
            HistoryAttribute();

            WriteLine();
        }

        static void _GetType()
        {
            WriteLine("_GetType()");

            void PrintConstructors(Type type)
            {
                WriteLine("------Constructors------");

                ConstructorInfo[] constructors = type.GetConstructors(
                    BindingFlags.NonPublic |
                    BindingFlags.Public |
                    BindingFlags.Static |
                    BindingFlags.Instance);
                
                foreach(ConstructorInfo constructor in constructors)
                {
                    string accessLevel = "protected";
                    if (constructor.IsPublic) accessLevel = "public";
                    else if (constructor.IsPrivate) accessLevel = "private";

                    WriteLine($"Access : {accessLevel}, Name : {constructor.Name}");
                }
                WriteLine();
            }
            void PrintInterfaces(Type type)
            {
                WriteLine("------Interfaces------");

                Type[] interfaces = type.GetInterfaces();

                foreach (Type i in interfaces)
                    WriteLine($"Name : {i}");
                WriteLine();
            }
            void PrintFields(Type type)
            {
                WriteLine("------Fields-----");

                FieldInfo[] fields = type.GetFields(
                    BindingFlags.NonPublic |
                    BindingFlags.Public    |
                    BindingFlags.Static    |
                    BindingFlags.Instance);

                foreach(FieldInfo field in fields)
                {
                    string accessLevel = "protected";
                    if (field.IsPublic) accessLevel = "public";
                    else if (field.IsPrivate) accessLevel = "private";

                    WriteLine($"Access : {accessLevel}, Type : {field.FieldType.Name}, Name : {field.Name}");
                }
                WriteLine();
            }
            void PrintMethods(Type type)
            {
                WriteLine("------Methods-----");

                MethodInfo[] methods = type.GetMethods();
                
                foreach(MethodInfo method in methods)
                {
                    Write($"Type : {method.ReturnType.Name}, Parameter : {method.Name}");

                    ParameterInfo[] args = method.GetParameters();

                    for (int i = 0; i < args.Length; i++)
                    {
                        Write($"{args[i].ParameterType.Name}");
                        if (i < args.Length - 1)
                            Write(", ");
                    }
                    WriteLine();
                }
                WriteLine();
            }
            void PrintProperties(Type type)
            {
                WriteLine("------Properties-----");

                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo property in properties)
                    WriteLine($"Type : {property.PropertyType.Name}, Name : {property.Name}");
                WriteLine();
            }
            void PrintNestedTypes(Type type)
            {
                WriteLine("------NestedTypes-----");

                Type[] Nesteds = type.GetNestedTypes(
                    BindingFlags.NonPublic |
                    BindingFlags.Public |
                    BindingFlags.Static |
                    BindingFlags.Instance);

                foreach (Type Nested in Nesteds)
                    WriteLine($"Name : {Nested.FullName}");
                WriteLine();
            }
            
            int a = 0;
            Type _type = a.GetType();
            
            PrintInterfaces(_type);
            PrintFields(_type);
            PrintProperties(_type);
            PrintMethods(_type);
            PrintConstructors(_type);
            PrintNestedTypes(_type);
        }
        static void DynamicInstance()
        {
            WriteLine("\nDyanmicInstance()");

            Type type = Type.GetType("MetaData.Profile");
            MethodInfo methodInfo = type.GetMethod("Print");
            PropertyInfo nameProperty = type.GetProperty("Name");
            PropertyInfo phoneProperty = type.GetProperty("Phone");

            object profile = Activator.CreateInstance(type, "박상현", "010-1234-5678");

            methodInfo.Invoke(profile, null);

            profile = Activator.CreateInstance(type);
            nameProperty.SetValue(profile, "박찬호", null);
            phoneProperty.SetValue(profile, "010-997-5511", null);

            WriteLine($"{nameProperty.GetValue(profile, null)}, {phoneProperty.GetValue(profile, null)}");

        }
        static void EmitTest()
        {
            WriteLine("\nEmitTest()");

            AssemblyBuilder newAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly
                (new AssemblyName("CalculatorAssembly"), AssemblyBuilderAccess.Run);
            ModuleBuilder newModule = newAssembly.DefineDynamicModule("Calculator");
            TypeBuilder newType = newModule.DefineType("Sum1To100");
            MethodBuilder newMethod = newType.DefineMethod(
                "Calculate",
                MethodAttributes.Public,
                typeof(int),
                new Type[0]);

            ILGenerator generator = newMethod.GetILGenerator();
            generator.Emit(OpCodes.Ldc_I4, 1);

            for (int i = 2; i <= 100; i++)
            {
                generator.Emit(OpCodes.Ldc_I4, i);
                generator.Emit(OpCodes.Add);
            }

            generator.Emit(OpCodes.Ret);
            newType.CreateType();

            object sum1To100 = Activator.CreateInstance(newType);
            MethodInfo Calculate = sum1To100.GetType().GetMethod("Calculate");
            WriteLine(Calculate.Invoke(sum1To100, null));
        }
        static void BasicAttribute()
        {
            WriteLine("\nBasicAttribute()");

            MyClassA obj = new MyClassA();

            obj.OldMethod();
            obj.NewMethod();
        }
        static void CallerInfo()
        {
            WriteLine("\nCallerInfo()");

            Trace.WriteLine("Fun");
        }
        static void HistoryAttribute()
        {
            WriteLine("\nHistoryAttribute()");

            Type type = typeof(MyClassB);
            Attribute[] attributes = Attribute.GetCustomAttributes(type);

            WriteLine("Myclass change history...");

            foreach(Attribute attribute in attributes)
            {
                History history = attribute as History;
                if(history != null)
                {
                    WriteLine($"Ver:{history.version}, Programmer:{history.GetProgrammer()}, Changes:{history.changes}");
                }
            }
        }
    }
} 
