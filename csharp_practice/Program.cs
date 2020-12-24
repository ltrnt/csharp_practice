using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace csharp_practice
{
    class MainClass
    {
        abstract public class Transport : IComparable<Transport>
        {
            protected string model;
            protected string num;
            protected string speed;
            protected double carry;
            public Transport(string model, string num, string speed, double carry)
            {
                this.model = model;
                this.num = num;
                this.speed = speed;
                this.carry = carry;
            }
            abstract public void Show();
            abstract public double GetCarry();

            public int CompareTo(Transport other)
            {
                long thisCarry = Convert.ToInt64(this.carry);
                long otherCarry = Convert.ToInt64(other.carry);
                if (thisCarry == otherCarry) return 0;
                else if (thisCarry > otherCarry)
                    return 1;
                else
                    return -1;
            }
        }

        public class Passenger_Car : Transport
        {
            public Passenger_Car(string model, string num, string speed, double carry) : base(model, num, speed, carry)
            { }
            public override void Show()
            {
                Console.WriteLine("Марка — {0}\tНомер — {1}\tСкорость — {2}\tГрузоподъёмность — {3}", model, num, speed, carry);
                Console.WriteLine();
            }
            public override double GetCarry()
            {
                return carry;
            }
        }

        public class Motorcycle : Transport
        {
            public bool sidecar;
            public Motorcycle(string model, string num, string speed, double carry, bool sidecar) : base(model, num, speed, carry)
            {
                this.sidecar = sidecar;
                if (sidecar == false)
                   this.carry = 0;
                else
                   this.carry = carry;
            }
            public override void Show()
            {
                Console.Write("Марка — {0}\tНомер — {1}\tСкорость — {2}\tГрузоподъёмность — {3}", model, num, speed, carry);
                Console.Write("\tКоляска - {0}", sidecar ? "1" : "0");
                Console.WriteLine();
            }
            public override double GetCarry()
            {
                return carry;
            }
        }

        public class Truck : Transport
        {
            public bool trailer;
            public Truck(string model, string num, string speed, double carry, bool trailer) : base(model, num, speed, carry)
            {
                this.trailer = trailer;
                if (trailer == true)
                    this.carry *= 2;
            }
            public override void Show()
            {
                Console.Write("Марка — {0}\tНомер — {1}\tСкорость — {2}\tГрузоподъёмность — {3}", model, num, speed, carry);
                Console.Write("\tПрицеп - {0}", trailer ? "1" : "0");
                Console.WriteLine();
            }
            public override double GetCarry()
            {
                return carry;
            }
        }


        public static void Main(string[] args)
        {
            List<Transport> list = new List<Transport>();


            using (StreamReader reader = new StreamReader("/Users/ltrnt/Projects/csharp_practice/csharp_practice/input.txt"))
            {
                string line;

                while((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(' ');

                    switch (values[0])
                    {
                        case "Truck":
                            list.Add(new Truck(values[1], values[2], values[3], Convert.ToDouble(values[4]), Convert.ToBoolean(values[5])));
                            break;

                        case "Motorcycle":
                            list.Add(new Motorcycle(values[1], values[2], values[3], Convert.ToDouble(values[4]), Convert.ToBoolean(values[5])));
                            break;

                        case "Passenger_Car":
                            list.Add(new Passenger_Car(values[1], values[2], values[3], Convert.ToDouble(values[4])));
                            break;

                        default:
                            Console.WriteLine("Ошибка при чтении данных");
                            break;
                    }
                }
            }


            foreach(var item in list)
            {
                item.Show();
            }
        }
    }
}
