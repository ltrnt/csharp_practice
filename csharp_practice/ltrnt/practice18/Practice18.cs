using System;
using System.Collections.Generic;
using System.IO;

namespace csharp_practice.ltrnt.practice18
{
    public class Practice18
    {
        public static string pathToInput = "/Users/ltrnt/Projects/csharp_practice/csharp_practice/ltrnt/practice18/input.txt";


        public abstract class Phonebook: IComparable<Phonebook>
        {
            protected string phoneNumber;

            protected Phonebook(string phoneNumber)
            {
                this.phoneNumber = phoneNumber;
            }

            public abstract void Show();
            public virtual bool IsSearchBySurname(String surname)
            {
                return false;
            }

            public int CompareTo(Phonebook other)
            {
                long thisNumber = Convert.ToInt64(this.phoneNumber);
                long otherNumber = Convert.ToInt64(other.phoneNumber);

                if (thisNumber > otherNumber)
                    return 1;
                else if (thisNumber < otherNumber)
                    return -1;

                return 0;
            }
        }

        public class Person : Phonebook
        {
            string surname;
            string location;

            public Person(string surname, string location, string phoneNumber) : base(phoneNumber)
            {
                this.surname = surname;
                this.location = location;
            }

            public override bool IsSearchBySurname(string surname)
            {
                return this.surname.Equals(surname);
            }

            public override void Show()
            {
                Console.WriteLine("{0} {1} {2}", surname, location, phoneNumber);
            }
        }

        public class Organisation : Phonebook
        {
            string nameOfOrganisation;
            string location;
            string faxNumber;
            string contactName;

            public Organisation(string nameOfOrganisation, string location, string phoneNumber, string faxNumber, string contactName) : base(phoneNumber)
            {
                this.nameOfOrganisation = nameOfOrganisation;
                this.location = location;
                this.faxNumber = faxNumber;
                this.contactName = contactName;
            }

            public override void Show()
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", nameOfOrganisation, location, phoneNumber, faxNumber, contactName);
            }
        }

        public class Friend : Phonebook
        {
            string surname;
            string location;
            string dateOfBirth;

            public Friend(string surname, string location, string phoneNumber, string dateOfBirth) : base(phoneNumber)
            {
                this.surname = surname;
                this.location = location;
                this.dateOfBirth = dateOfBirth;
            }

            public override bool IsSearchBySurname(string surname)
            {
                return this.surname.Equals(surname);
            }

            public override void Show()
            {
                Console.WriteLine("{0} {1} {2} {3}", surname, location, phoneNumber, dateOfBirth);
            }

        }

        public static void Task8()
        {
            List<Phonebook> list = Input();

            list.Sort();

            foreach (var item in list)
            {
                //if(item.IsSearchBySurname("Сидоров"))
                    item.Show();
            }
        }

        private static List<Phonebook> Input()
        {
            List<Phonebook> list = new List<Phonebook>();

            using(StreamReader reader = new StreamReader(pathToInput))
            {
                string line = "";
                string[] values;
                char[] separators = {' ', '\t', '\r', '\n'};

                while((line = reader.ReadLine()) != null)
                {
                    values = line.Split(separators);

                    switch (values.Length)
                    {
                        case 3:
                            list.Add(new Person(values[0], values[1], values[2]));
                            break;
                        case 5:
                            list.Add(new Organisation(values[0], values[1], values[2], values[3], values[4]));
                            break;
                        case 4:
                            list.Add(new Friend(values[0], values[1], values[2], values[3]));
                            break;
                        default:
                            Console.WriteLine("Error while readind data");
                            break;
                    }
                }
            }

            return list;
        }
    }
}
