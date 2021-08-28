using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        private static List<Person> people = new List<Person>();
        private static List<Organization> organization = new List<Organization>();
        private static string path = "C:\\Users\\tn_kz\\source\\repos\\ConsoleApp1\\textFile.txt";
        private static BinaryFormatter formatter = new BinaryFormatter();
        static void Main(string[] args)
        {

            Console.WriteLine("1 - Зарегистрироваться как физическое лицо");
            Console.WriteLine("2 - Зарегистрироваться как юридическое лицо");
            Console.WriteLine("3 - Сделать вывод записей из списка юр. лиц");
            Console.WriteLine("4 - Сделать вывод списка физ лиц. Упорядочить список физ. лиц по Фамилии, Имени, Отчеству. ");

            byte pick = Convert.ToByte(Console.ReadLine());

            switch (pick)
            {
                case 1:
                    RegisterPerson();
                    break;

                case 2:
                    RegisterOrganization();
                    break;

                case 3:
                    PrintOrganizations();
                    break;

                case 4:
                    PrintPersons();
                    break;

                default:
                    Console.WriteLine("Такого пункта не существует");
                    break;
            }
            Console.ReadKey();
        }

            public static void RegisterPerson()
            {
                Console.WriteLine("Автор - ");
                string creator = Console.ReadLine();
                Console.WriteLine("Имя - ");
                string name = Console.ReadLine();
                Console.WriteLine("Фамилия - ");
                string lastName = Console.ReadLine();
                Console.WriteLine("ИИН - ");
                string iin = Console.ReadLine();
                FileStream fs = new FileStream(path, FileMode.Append);
                people.Add(new Person(creator, name, lastName, iin));
                formatter.Serialize(fs, people);
                fs.Close();
            }

            static void RegisterOrganization()
            {
                Console.WriteLine("ИИН - ");
                string iin = Console.ReadLine();
                Console.WriteLine("Автор - ");
                string creator = Console.ReadLine();
                Console.WriteLine("Имя организации - ");
                string orgname = Console.ReadLine();

                organization.Add(new Organization(orgname, creator, iin));

                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    foreach (var item in organization)
                    {
                        sw.Write($"{item.Creator}\t");
                        sw.Write($"{item.OrganizationName}\t");
                        sw.Write($"{item.Id}\t");
                        sw.Write($"{item.Iin}\t");
                        sw.Write($"{item.DateOfCreaction}\t");
                    }
                }
            }

            static void PrintOrganizations()
            {
                //десериализация файла
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    people = (List<Person>)formatter.Deserialize(fs);
                    foreach (Person item in people)
                    {
                        Console.WriteLine($"Имя - {item.Name} Фамилия - {item.LastName}");
                    }
                }

        
            }
        static void PrintPersons()
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\tИМЯ \t Фамилия");
                List<Person> list1 = (List<Person>)formatter.Deserialize(fs);
                foreach (var item in list1)
                {
                    Console.Write($"\t{item.Name}\t");
                    Console.Write($"{item.LastName}\t");
                    Console.WriteLine();
                }
                fs.Close();
            }
        }

            
        
    }
}

