using System;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;
using static System.Console;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace _FileSstream
{
    [Serializable]
    class NameCard
    {
        public NameCard() { }
        public NameCard(string Name, string Phone, int Age)
        {
            this.Name = Name;
            this.Phone = Phone;
            this.Age = Age;
        }
        public string Name;
        public string Phone;
        public int Age;
    }

    class Program
    {
        static void Main()
        {
            Dir();
            Touch();
            BasicIO();
            SeqNRand();
            BinaryFile();
            TextFile();
            Serialization();
            SerializationCollection();

            WriteLine();
        }

        static void ProcessCmd(string command)
        {
            ProcessStartInfo proInfo = new ProcessStartInfo();
            Process pro = new Process();

            proInfo.FileName = @"cmd"; // 실행 할 파일명 
            proInfo.CreateNoWindow = false; // 창 띄우기 여부(Bool)
            proInfo.UseShellExecute = false; // 프로세스 시작 시 운영체제 셀 사용 여부
            proInfo.RedirectStandardOutput = true; // App 텍스트 출력 스트림 사용 여부
            proInfo.RedirectStandardInput = true; // App 입력 스트림 사용 여부
            proInfo.RedirectStandardError = true; // App 오류 스트림 사용 여부

            pro.StartInfo = proInfo;
            pro.Start();

            pro.StandardInput.Write(@command + Environment.NewLine);
            pro.StandardInput.Close();

            string resultValue = pro.StandardOutput.ReadToEnd();
            pro.WaitForExit();
            pro.Close();

            WriteLine(resultValue + "\n");
        }
        static void Dir()
        {
            WriteLine("Dir()");

            string[] args = { "C:\\Users" };

            string directory;
            if (args.Length < 1)
                directory = ".";
            else
                directory = args[0];

            WriteLine($"{directory} directory Info");
            WriteLine("-Directories : ");
            var directories = (from dir in Directory.GetDirectories(directory)
                               let info = new DirectoryInfo(dir)
                               select new
                               {
                                   Name = info.Name,
                                   Attributes = info.Attributes
                               }).ToList();

            foreach (var d in directories)
                WriteLine($"{d.Name} : {d.Attributes}");

            WriteLine("-Files : ");
            var files = (from file in Directory.GetFiles(directory)
                         let info = new FileInfo(file)
                         select new
                         {
                             Name = info.Name,
                             FileSize = info.Length,
                             Attribute = info.Attributes
                         }).ToList();
            foreach (var f in files)
                WriteLine($"{f.Name} : {f.FileSize}, {f.Attribute}");
        }
        static void Touch()
        {
            WriteLine("\nTouch()");

            while (true)
            {
                Write("Quit [Q or q] : ");
                string temp = ReadLine();
                if (temp == "q" || temp == "Q")
                    break;
                string[] path = temp.Split();

                FileCreate(path);
            }

            void OnWrongPathType(string Type)
            {
                WriteLine($"{Type} is wrong type");
                return;
            }

            void FileCreate(string[] args)
            {
                if (args.Length == 0)
                {
                    WriteLine("Usage : Touch.exe <Path> [Type:File/Directory]");
                    return;
                }

                string path = args[0];
                string type = "File";
                if (args.Length > 1)
                    type = args[1];

                if (File.Exists(path) || Directory.Exists(path))
                {
                    if (type == "File")
                        File.SetLastAccessTime(path, DateTime.Now);
                    else if (type == "Directory")
                        Directory.SetLastAccessTime(path, DateTime.Now);
                    else
                    {
                        OnWrongPathType(path);
                        return;
                    }

                    WriteLine($"Updated {path} {type}\n");
                }

                else if (path == "dir")
                {
                    ProcessCmd("dir");
                }

                else
                {
                    if (type == "File")
                        File.Create(path).Close();
                    else if (type == "Directory")
                        Directory.CreateDirectory(path);
                    else
                    {
                        OnWrongPathType(path);
                        return;
                    }
                    WriteLine($"Created {path} {type}\n");
                }
            }
        }
        static void BasicIO()
        {
            WriteLine("\nBasicIO()");

            long someValue = 0x123456789ABCDEF0;
            WriteLine("{0:-1} : 0x{1:X16}", "Original Data", someValue);

            Stream outStream = new FileStream("a.bat", FileMode.Create);
            byte[] wBytes = BitConverter.GetBytes(someValue);

            WriteLine("{0,-13} : ", "Byte array");

            foreach (byte b in wBytes)
                Write("{0:X2} ", b);
            WriteLine();

            outStream.Write(wBytes, 0, wBytes.Length);
            outStream.Close();

            Stream inStream = new FileStream("a.bat", FileMode.Open);
            byte[] rbytes = new byte[8];

            int i = 0;
            while (inStream.Position < inStream.Length)
                rbytes[i++] = (byte)inStream.ReadByte();

            long readValue = BitConverter.ToInt64(rbytes, 0);

            WriteLine("{0,-13} : 0x{1:X16}", "Read Data", readValue);
            inStream.Close();
        }
        static void SeqNRand()
        {
            WriteLine("\nSeqNRand()");

            WriteLine("\nWrite");
            Stream outStream = new FileStream("a.bat", FileMode.Create);
            WriteLine($"Posion : {outStream.Position}");

            outStream.WriteByte(0x01);
            WriteLine($"Posion : {outStream.Position}");

            outStream.WriteByte(0x02);
            WriteLine($"Posion : {outStream.Position}");

            outStream.WriteByte(0x03);
            WriteLine($"Posion : {outStream.Position}");

            outStream.Seek(5, SeekOrigin.Current);
            WriteLine($"Posion : {outStream.Position}");

            outStream.WriteByte(0x04);
            WriteLine($"Posion : {outStream.Position}");

            outStream.Close();

            WriteLine("\nRead");
            Stream inStream = new FileStream("a.bat", FileMode.Open);
            
            for(int i = 0; i< inStream.Length; i++)
                WriteLine($"Posion : {inStream.Position}, Data : {inStream.ReadByte()}");

            inStream.Close();
        }
        static void BinaryFile()
        {
            WriteLine("\nBinaryFile()");

            BinaryWriter bw = new BinaryWriter(new FileStream("a.bat", FileMode.Create));

            bw.Write(int.MaxValue);
            bw.Write("Good morning");
            bw.Write(uint.MaxValue);
            bw.Write("안녕하세요!");
            bw.Write(double.MaxValue);

            bw.Close();

            BinaryReader br = new BinaryReader(new FileStream("a.bat", FileMode.Open));

            WriteLine($"File Size : {br.BaseStream.Length} Byte");
            WriteLine($"Int.MaxValue : {br.ReadInt32()}");
            WriteLine($"String : {br.ReadString()}");
            WriteLine($"uInt.MaxValue : {br.ReadUInt32()}");
            WriteLine($"String : {br.ReadString()}");
            WriteLine($"Double.MaxValue : {br.ReadDouble()}");

            br.Close();
        }
        static void TextFile()
        {
            WriteLine("\nTextFile()");

            StreamWriter sw = new StreamWriter(new FileStream("a.txt", FileMode.Create));

            sw.WriteLine("Int.MaxValue : " + int.MaxValue);
            sw.WriteLine("String : " + "Good morning");
            sw.WriteLine("uInt.MaxValue : " + uint.MaxValue);
            sw.WriteLine("String : " + "안녕하세요!");
            sw.WriteLine("Double.MaxValue" + double.MaxValue);

            sw.Close();

            StreamReader sr = new StreamReader(new FileStream("a.txt", FileMode.Open));

            WriteLine($"File Size : {sr.BaseStream.Length} Byte");

            while (sr.EndOfStream == false)
                WriteLine(sr.ReadLine());

            sr.Close();


        }
        static void Serialization()
        {
            WriteLine("\nSerialization()");

            Stream ws = new FileStream("a.bat", FileMode.Create);
            BinaryFormatter serialization = new BinaryFormatter();

            NameCard ncA = new NameCard();
            ncA.Name = "박상현";
            ncA.Phone = "010-123-4567";
            ncA.Age = 33;

            serialization.Serialize(ws, ncA);
            ws.Close();

            Stream rs = new FileStream("a.bat", FileMode.Open);
            BinaryFormatter deserialization = new BinaryFormatter();

            NameCard ncB;
            ncB = (NameCard)deserialization.Deserialize(rs);
            rs.Close();

            WriteLine($"Name : {ncB.Name}");
            WriteLine($"Phone : {ncB.Phone}");
            WriteLine($"Age : {ncB.Age}");
        }
        static void SerializationCollection()
        {
            WriteLine("\nSerializationCollection()");

            Stream ws = new FileStream("a.dat", FileMode.Create);
            BinaryFormatter serialization = new BinaryFormatter();

            List<NameCard> listA = new List<NameCard>();
            listA.Add(new NameCard("박상현", "010-123-4567", 33));
            listA.Add(new NameCard("김연아", "010-323-1111", 22));
            listA.Add(new NameCard("장미란", "010-555-5555", 26));

            serialization.Serialize(ws,listA);
            ws.Close();

            Stream rs = new FileStream("a.dat", FileMode.Open);
            BinaryFormatter deserialization = new BinaryFormatter();

            List<NameCard> listB;
            listB = (List<NameCard>)deserialization.Deserialize(rs);
            rs.Close();

            foreach (NameCard nc in listB)
                WriteLine($"Name : {nc.Name}, Phone : {nc.Phone}, Age : {nc.Age}");
        }
    }
}