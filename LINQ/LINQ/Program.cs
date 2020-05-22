using System.Linq;
using static System.Console;

namespace LINQ
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }
    class Class
    {
        public string Name { get; set; }
        public int[] Score { get; set; }
    }
    class Product
    {
        public string Title;
        public string Star;
    }
    class Car
    {
        public int Cost { get; set; }
        public int MaxSpeed { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            From();
            SimpleLinqA();
            FromFrom();
            GroupBy();
            Join();
            SimpleLinqB();
            MinMaxAvg();
            LINQExample();

            WriteLine();
        }

        static void From()
        {
            WriteLine("From()");

            int[] Number = { 9, 2, 6, 4, 5, 3, 7, 8, 1, 10 };

            var result = from n in Number
                         where n % 2 == 0
                         orderby n
                         select n;

            foreach (int n in result)
                WriteLine($"{n} ");
        }
        static void SimpleLinqA()
        {
            WriteLine("\nSimpleLinqA()");

            Profile[] arrProfiles =
            {
                 new Profile(){Name = "정우성", Height = 186 }, 
                 new Profile(){Name = "김태희", Height = 158 },
                 new Profile(){Name = "고현정", Height = 172 }, 
                 new Profile(){Name = "이문세", Height = 178 }, 
                 new Profile(){Name = "하하", Height = 171 },
            };

            var profiles = from profile in arrProfiles
                           where profile.Height < 175
                           orderby profile.Height ascending
                           select new
                           {
                               Name = profile.Name,
                               InchHeight = profile.Height * 0.393
                           };
            foreach (var profile in profiles)
                WriteLine($"{profile.Name}, {profile.InchHeight}");

        }
        static void FromFrom()
        {
            WriteLine("\nFromFrom()");

            Class[] arrClass =
            {
                new Class{Name = "연두반", Score = new int[] {90,80,70,24}},
                new Class{Name = "분홍반", Score = new int[] {60,45,87,72}},
                new Class{Name = "파랑반", Score = new int[] {92,30,85,94}},
                new Class{Name = "노랑반", Score = new int[] {90,88,0,17}}
            };

            var Classes = from c in arrClass
                          from s in c.Score
                          where s < 60
                          orderby s ascending
                          select new { c.Name, Lowest = s };

            foreach (var c in Classes)
                WriteLine($"낙제 : {c.Name}, ({c.Lowest})");
        }
        static void GroupBy()
        {
            WriteLine("\nGroupBy()");

            Profile[] arrProfiles =
           {
                 new Profile(){Name = "정우성", Height = 186 },
                 new Profile(){Name = "김태희", Height = 158 },
                 new Profile(){Name = "고현정", Height = 172 },
                 new Profile(){Name = "이문세", Height = 178 },
                 new Profile(){Name = "하하", Height = 171 },
            };

            var listProfiles = from profile in arrProfiles
                               orderby profile.Height
                               group profile by profile.Height < 175 into g
                               select new { GroupKey = g.Key, Profile = g };

            foreach(var Group in listProfiles)
            {
                WriteLine($"- 175cm 미만 : {Group.GroupKey}");

                foreach (var profile in Group.Profile)
                    WriteLine($"     {profile.Name}, {profile.Height}");
            }
        }
        static void Join()
        {
            WriteLine("\nJoin()");

            Profile[] arrProfiles =
         {
                 new Profile(){Name = "정우성", Height = 186 },
                 new Profile(){Name = "김태희", Height = 158 },
                 new Profile(){Name = "고현정", Height = 172 },
                 new Profile(){Name = "이문세", Height = 178 },
                 new Profile(){Name = "하하", Height = 171 },
            };
            Product[] arrProduct =
            {
                new Product(){Title = "비트", Star = "정우성"},
                new Product(){Title = "CF 다수", Star = "김태희"},
                new Product(){Title = "아이리스", Star = "김태희"},
                new Product(){Title = "모래시계", Star = "고현정"},
                new Product(){Title = "Solo 예찬", Star = "이문세"}
            };

            var listProfile = from profiles in arrProfiles
                              join product in arrProduct on profiles.Name equals product.Star
                              select new
                              {
                                  Name = profiles.Name,
                                  Work = product.Title,
                                  Height = profiles.Height
                              };
            WriteLine("-----Inner Join-----");
            foreach (var profile in listProfile)
                WriteLine($"이름 : {profile.Name}, 작품 : {profile.Work}, 키 : {profile.Height}");

            listProfile = from profiles in arrProfiles
                          join product in arrProduct on profiles.Name equals product.Star into ps
                          from product in ps.DefaultIfEmpty(new Product() { Title = "없음" })
                          select new
                          {
                              Name = profiles.Name,
                              Work = product.Title,
                              Height = profiles.Height
                          };

            WriteLine("\n-----Outer Join-----");
            foreach (var profile in listProfile)
                WriteLine($"이름 : {profile.Name}, 작품 : {profile.Work}, 키 : {profile.Height}");
        }
        static void SimpleLinqB()
        {
            WriteLine("\nSimpleLinqB()");

            Profile[] arrProfiles =
            {
                 new Profile(){Name = "정우성", Height = 186 },
                 new Profile(){Name = "김태희", Height = 158 },
                 new Profile(){Name = "고현정", Height = 172 },
                 new Profile(){Name = "이문세", Height = 178 },
                 new Profile(){Name = "하하", Height = 171 },
            };

            var profiles = arrProfiles.
                Where(profile => profile.Height < 175).
                OrderBy(profile => profile.Height).
                Select(profile => new
                {
                    Name = profile.Name,
                    Height = profile.Height
                });

            foreach (var profile in profiles)
                WriteLine($"{profile.Name}, {profile.Height}");
        }
        static void MinMaxAvg()
        {
            WriteLine("\nMinMaxAvg()");

            Profile[] arrProfiles =
            {
                 new Profile(){Name = "정우성", Height = 186 },
                 new Profile(){Name = "김태희", Height = 158 },
                 new Profile(){Name = "고현정", Height = 172 },
                 new Profile(){Name = "이문세", Height = 178 },
                 new Profile(){Name = "하하", Height = 171 },
            };

            var heightStat = from profile in arrProfiles
                           group profile by profile.Height < 175 into g
                           select new
                           {
                               Group = g.Key == true ? "175미만" : "175이상",
                               Count = g.Count(),
                               Max = g.Max(profile => profile.Height),
                               Min = g.Min(profile => profile.Height),
                               Average = g.Average(profile => profile.Height)
                           };

            foreach(var stat in heightStat)
            {
                Write($"{stat.Group} - Count : {stat.Count}, Max : {stat.Max},");
                WriteLine($" Min : {stat.Min}, Average : {stat.Average}");
            }

            WriteLine();
        }
        static void LINQExample()
        {
            WriteLine("\nLINQExample()");

            //Ex15_1
            WriteLine("\nEx15_1");
            Car[] arrCars =
            {
                new Car {Cost = 56, MaxSpeed = 120},
                new Car {Cost = 70, MaxSpeed = 150},
                new Car {Cost = 45, MaxSpeed = 180},
                new Car {Cost = 32, MaxSpeed = 200},
                new Car {Cost = 82, MaxSpeed = 280}
            };

            var Cars = from Car in arrCars
                       where Car.Cost >= 50 && Car.MaxSpeed >= 150
                       select new
                       {
                           Cost = Car.Cost,
                           MaxSpeed = Car.MaxSpeed

                       };

            foreach (var selected in Cars)
                WriteLine($"Cost : {selected.Cost}, MaxSpeed : {selected.MaxSpeed}");
            WriteLine();

            //15_2
            WriteLine("Ex15_2");
            Cars = arrCars.
                   Where(Car => Car.Cost < 60).
                   OrderBy(Car => Car.Cost).
                   Select(Car => new
                   {
                       Cost = Car.Cost,
                       MaxSpeed = Car.MaxSpeed
                   });

            foreach (var selected in Cars)
                WriteLine($"Cost : {selected.Cost}, MaxSpeed : {selected.MaxSpeed}");
            WriteLine();


        }
    }
}
