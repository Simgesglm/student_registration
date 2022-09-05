using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Proje1
{
    class Program
    {
        static void Main(string[] args)
        {
            string escape = null;
            while (escape != "!")
            {
                Menu();
            }
            
            void InsertToXml()
            {
                XDocument x = XDocument.Load(@"C:\Users\miray\OneDrive\Masaüstü\Proje1\Proje1\bin\Debug\netcoreapp3.1\XMLFile1.xml");
                Student student = new Student();
                while (escape != "!")
                {
                    Console.Write("Ogrenci Adı:");
                    student.FirstName = Console.ReadLine();
                    if (student.FirstName != "!")
                    {
                        Console.Write("Ogrenci Soyadı:");
                        student.LastName = Console.ReadLine();
                        Console.Write("Ogrenci Numarası:");
                        student.StudentNumber = Console.ReadLine();
                        Console.Write("Ogrenci Doğum Tarihi:");
                        student.BirthDay = Console.ReadLine();


                        x.Element("Students").Add(
                            new XElement("Student",
                            new XElement("FirstName", student.FirstName),
                            new XElement("LastName", student.LastName),
                            new XElement("StudentNumber", student.StudentNumber),
                            new XElement("BirthDay", student.BirthDay)
                            ));
                        x.Save(@"C:\Users\miray\OneDrive\Masaüstü\Proje1\Proje1\bin\Debug\netcoreapp3.1\XMLFile1.xml");
                        Console.WriteLine("Çıkmak için Öğrenci adına '!' yazınız.");
                    }
                    else
                    {
                        escape = "!";
                    }
                    Menu();
                }
            }

            void SortByLastName()
            {
                List<Student> studentList = new List<Student>();
                XmlDocument doc = new XmlDocument();
                StreamReader sr = new StreamReader(@"C:\Users\miray\OneDrive\Masaüstü\Proje1\Proje1\bin\Debug\netcoreapp3.1\XMLFile1.xml");
                string okunan = sr.ReadToEnd();
                doc.LoadXml(okunan);
                XmlNodeList nodeList = doc.GetElementsByTagName("Student");
                int count = 0;
                foreach (XmlNode item in nodeList)
                {
                    Student student = new Student();
                    student.StudentNumber = item["StudentNumber"].InnerText;
                    student.FirstName = item["FirstName"].InnerText;
                    student.LastName = item["LastName"].InnerText;
                    student.BirthDay = item["BirthDay"].InnerText;
                    studentList.Add(student);

                }
                List<Student> SortedListByLastName = studentList.OrderBy(o => o.LastName).ToList();
                foreach (var item in SortedListByLastName)
                {
                    count++;
                    Console.WriteLine("\n" + count + ". veri \n");
                    Console.WriteLine("Student Number: " + item.StudentNumber);
                    Console.WriteLine("    First Name: " + item.FirstName);
                    Console.WriteLine("     Last Name: " + item.LastName);
                    Console.WriteLine("      Birthday: " + item.BirthDay);
                }

            }

            void SortByBirthDay()
            {
                List<Student> studentList = new List<Student>();
                XmlDocument doc = new XmlDocument();
                StreamReader sr = new StreamReader(@"C:\Users\miray\OneDrive\Masaüstü\Proje1\Proje1\bin\Debug\netcoreapp3.1\XMLFile1.xml");
                string okunan = sr.ReadToEnd();
                doc.LoadXml(okunan);
                XmlNodeList nodeList = doc.GetElementsByTagName("Student");
                int count = 0;
                foreach (XmlNode item in nodeList)
                {
                    Student student = new Student();
                    student.StudentNumber = item["StudentNumber"].InnerText;
                    student.FirstName = item["FirstName"].InnerText;
                    student.LastName = item["LastName"].InnerText;
                    student.BirthDay = item["BirthDay"].InnerText;
                    studentList.Add(student);

                }
                List<Student> SortedListByBirthDay = studentList.OrderBy(o => o.BirthDay).ToList();
                foreach (var item in SortedListByBirthDay)
                {
                    count++;
                    Console.WriteLine("\n" + count + ". veri \n");
                    Console.WriteLine("Student Number: " + item.StudentNumber);
                    Console.WriteLine("    First Name: " + item.FirstName);
                    Console.WriteLine("     Last Name: " + item.LastName);
                    Console.WriteLine("      Birthday: " + item.BirthDay);
                }

            }

            void ByValue(int param)
            {
                
                switch (param)
                {
                    //soyadına göre sırala
                    case 1:
                        SortByLastName();
                        break;
                        //doğum tarihine göre sırala
                    case 2:
                        SortByBirthDay();
                        break;
                    case 3:
                        Console.Write("Silinecek öğrencinin numarasını giriniz:");
                        string studentNumber = Console.ReadLine();
                        XDocument x = XDocument.Load(@"C:\Users\miray\OneDrive\Masaüstü\Proje1\Proje1\bin\Debug\netcoreapp3.1\XMLFile1.xml");
                        x.Root.Elements().Where(a => a.Element("StudentNumber").Value == studentNumber).Remove();
                        Console.WriteLine();
                        x.Save(@"C:\Users\miray\OneDrive\Masaüstü\Proje1\Proje1\bin\Debug\netcoreapp3.1\XMLFile1.xml");
                        Menu();
                        break;
                    default:
                        Menu();
                        break;
                }
                Menu();
            }

            void GetByFileName(string param)
            {
                List<Student> studentList = new List<Student>();
                XmlDocument doc = new XmlDocument();

                StreamReader sr = new StreamReader(param);
                string okunan = sr.ReadToEnd();
                doc.LoadXml(okunan);
                XmlNodeList nodeList = doc.GetElementsByTagName("Student");
                int count = 0;

                foreach (XmlNode item in nodeList)
                {
                    Student student = new Student();
                    student.StudentNumber = item["StudentNumber"].InnerText;
                    student.FirstName = item["FirstName"].InnerText;
                    student.LastName = item["LastName"].InnerText;
                    student.BirthDay = item["BirthDay"].InnerText;
                    studentList.Add(student);

                }
                foreach (var item in studentList)
                {
                    count++;
                    Console.WriteLine("\n" + count + ". veri \n");
                    Console.WriteLine("Student Number: " + item.StudentNumber);
                    Console.WriteLine("    First Name: " + item.FirstName);
                    Console.WriteLine("     Last Name: " + item.LastName);
                    Console.WriteLine("      Birthday: " + item.BirthDay);
                    Console.WriteLine("\n");
                }

                Menu();

            }

            void GetAll()
            {
                List<Student> studentList = new List<Student>();
                XmlDocument doc = new XmlDocument();
                StreamReader sr = new StreamReader(@"C:\Users\miray\OneDrive\Masaüstü\Proje1\Proje1\bin\Debug\netcoreapp3.1\XMLFile1.xml");
                string okunan = sr.ReadToEnd();
                doc.LoadXml(okunan);
                XmlNodeList nodeList = doc.GetElementsByTagName("Student");
                int count = 0;

                foreach (XmlNode item in nodeList)
                {
                    Student student = new Student();
                    student.StudentNumber = item["StudentNumber"].InnerText;
                    student.FirstName = item["FirstName"].InnerText;
                    student.LastName = item["LastName"].InnerText;
                    student.BirthDay = item["BirthDay"].InnerText;
                    studentList.Add(student);

                }
                foreach (var item in studentList)
                {
                    count++;
                    Console.WriteLine("\n" + count + ". veri \n");
                    Console.WriteLine("Student Number: " + item.StudentNumber);
                    Console.WriteLine("    First Name: " + item.FirstName);
                    Console.WriteLine("     Last Name: " + item.LastName);
                    Console.WriteLine("      Birthday: " + item.BirthDay);
                }

                Menu();

            }

            void Menu()
            {
                Console.WriteLine("\nAşağıdaki seçeneklerden birisini seçiniz.");
                Console.WriteLine("1-Dosya adına göre xml dan veri çekmek");
                Console.WriteLine("2-Yeni öğrenci gir");
                Console.WriteLine("3-Öğreni bilgilerine göre işlemler.");
                Console.WriteLine("4-Bütün kayıtları getir.");
                Console.WriteLine("5-Çıkış");
                int menu=Int32.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.Write("Xml dosyanızın adını giriniz:");
                        string fileName = Console.ReadLine();
                        GetByFileName(fileName);
                        break;
                    case 2:
                        InsertToXml();
                        break;
                    case 3:
                        Console.WriteLine("\n1-Soyadına göre sırala");
                        Console.WriteLine("2-Doğum tarihine göre sırala");
                        Console.WriteLine("3-Numaraya göre öğrenci sil \n");
                        int param = Int32.Parse(Console.ReadLine());
                        ByValue(param);
                        break;
                    case 4:
                        GetAll();
                        break;
                    case 5:
                        escape = "!";
                        break;

                    default:
                        Console.WriteLine("\nLutfen yukaridan yazan sayilardan birini yaziniz.");
                        Menu();
                        break;
                }
            }
        }

    }

    class Student
    {
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }




    }
}
