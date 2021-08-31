using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp1
{
    class Program
    {
        private static List<Person> people = new List<Person>();
        private static List<Organization> organization = new List<Organization>();
        private static string personsPath = "C:\\Users\\tn_kz\\source\\repos\\ConsoleApp1\\personsFile.txt";
        private static string orgsPath = "C:\\Users\\tn_kz\\source\\repos\\ConsoleApp1\\orgsFile.txt";

        private static BinaryFormatter formatter = new BinaryFormatter();
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(personsPath, FileMode.Open);
            if (fs.Length > 0)
            {
                people = formatter.Deserialize(fs) as List<Person>;
                fs.Close();
            }
            FileStream fs2 = new FileStream(orgsPath,FileMode.Open);
            if (fs2.Length > 0)
            {
                organization = formatter.Deserialize(fs2) as List<Organization>;
                fs2.Close();
            }

            Console.WriteLine("1 - Зарегистрироваться как физическое лицо");
            Console.WriteLine("2 - Зарегистрироваться как юридическое лицо");
            Console.WriteLine("3 - Добавить контактные лица к юр лицу");
            Console.WriteLine("4 - Сделать вывод записей из списка юр. лиц");
            Console.WriteLine("5 - Сделать вывод списка физ лиц. Упорядочить список физ. лиц по Фамилии, Имени, Отчеству. ");

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
                    AddContacts();
                    break;
                case 4:
                    PrintOrganizations();
                    break;

                case 5:
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

            FileStream fs = new FileStream(personsPath, FileMode.Open);
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

            FileStream fs2 = new FileStream(orgsPath, FileMode.Open);
            organization.Add(new Organization(orgname, creator, iin));
            formatter.Serialize(fs2, organization);
            fs2.Close();
        }
        static void AddContacts()
        {
            Console.WriteLine("Введите имя организации");
            string org = Console.ReadLine();
            int index = organization.FindIndex(item => item.OrganizationName == org);
            Console.WriteLine("Автор - ");
            string creator = Console.ReadLine();
            Console.WriteLine("Имя - ");
            string name = Console.ReadLine();
            Console.WriteLine("Фамилия - ");
            string lastName = Console.ReadLine();
            Console.WriteLine("ИИН");
            string iin = Console.ReadLine();
            Console.WriteLine("Введите номер");
            string phone = Console.ReadLine();
            if (phone.Length == 11)
            {
                organization[index].ContactPhone = phone;
               //organization[index].contactsList = (new Person(creator, name, lastName, iin));
            }
            else throw new ArgumentException("Вы ввели не валидный номер телефона");
            if ((creator != null) && (name != null) && (lastName != null))
            {
                organization[index].contacts.Add(new Person(creator, name, lastName, iin));
            }
            FileStream fs2 = new FileStream(orgsPath, FileMode.Open);
            formatter.Serialize(fs2, organization);
            fs2.Close();
        }

        static void PrintOrganizations()
        {
            using (FileStream fs = new FileStream(orgsPath, FileMode.Open))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\tОрганизация\tГлава\tТелефон\t \tДата изменения");
                Console.WriteLine();
                foreach (var item in organization)
                {
                    Console.WriteLine($"\t{item.OrganizationName}\t \t{item.Creator}\t{item.ContactPhone}\t {item.DateOfChange}");
                    foreach (var item_ in item.contacts)
                    {
                        Console.WriteLine();
                        Console.WriteLine("\tКонтактные данные");
                        Console.WriteLine($"\t{item_.Name}\t \t{item_.LastName}");
                    }
                }
            }
        }
        static void PrintPersons()
        {
            using (FileStream fs = new FileStream(personsPath, FileMode.Open))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\tИМЯ \t Фамилия");
                foreach (var item in people)
                {
                    Console.WriteLine();
                    Console.Write($"\t{item.Name}\t");
                    Console.Write($"{item.LastName}\t");
                }
            }
        }
    }
}

