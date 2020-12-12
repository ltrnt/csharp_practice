using System;
namespace csharp_practice.foxlyume.practice17
{
    public class Practice17
    {
        // Здесь начинается код

        public class Money
        {
            // Поля
            int first;
            int second;

            // Конструктор, позволяющий создать экземпляр класса с заданными значениям полей
            public Money(int first, int second)
            {
                this.first = first;
                this.second = second;
            }

            // Метод, позволяющий вывести номинал и количество купюр
            public void Show()
            {
                Console.WriteLine("Купюр с номиналом {0} {1} штук", first, second);
            }

            // Метод, позволяющий определить, хватит ли денежных средств на покупку товара на сумму N рублей
            public bool checkN(int n)
            {
                if(first * second >= n)
                {
                    Console.WriteLine("Для покупки на сумму в {0} достаточно денежных средств", n);
                    return true;
                }
                else
                {
                    Console.WriteLine("Для покупки на сумму в {0} НЕ достаточно денежных средств", n);
                    return false;
                }
            }

            // Метод, позволяющий определить, сколько штук товара стоимости n рублей можно купить на имеющиеся денежные средства
            public int buyN(int n)
            {
                int result = (first * second) / n;

                Console.WriteLine("Можно купить {0} единиц товара по цене в {1}", result, n);

                return result;
            }

            // Свойство, позволяющее получить-установить значение полей (доступное для чтения и записи)
            public int First { get => first; set => first = value; }
            public int Second { get => second; set => second = value; }

            // Свойство, позволяющее расчитатать сумму денег (доступное только для чтения)
            public int Sum { get => first * second; }

            // Индексатор, позволяющий по индексу 0 обращаться к полю first, по индексу 1 – к полю second,
            // при других значениях индекса выдается сообщение об ошибке.
            public int this[int i]
            {
                get
                {
                    if (i == 0)
                    {
                        return first;
                    }
                    else if(i == 1)
                    {
                        return second;
                    }
                    else
                    {
                        Console.WriteLine("Неверный индекс");
                        return 0;
                    }
                }
            }

            // Перегрузка операции ++ (--): одновременно увеличивает (уменьшает) значение полей first и second;
            public static Money operator ++(Money obj1)
            {
                obj1.first += 1;
                obj1.second += 1;
                return obj1;
            }
            public static Money operator --(Money obj1)
            {
                obj1.first -= 1;
                obj1.second -= 1;
                return obj1;
            }

            // Перегрузка операции !: возвращает значение true, если поле second не нулевое, иначе false;
            public static bool operator !(Money obj1)
            {
                if(obj1.second != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // Перегрузка операции бинарный +: добавляет к значению поля second значение скаляра.
            public static Money operator +(Money obj1, int obj2)
            {
                Money result = new Money(obj1.first, obj1.second + obj2);
                return result;
            }
        }

        // Демонстрация работы класса Money 
        public static void Test()
        {
            // 10 купюр наминалом в 100.
            Money money = new Money(100, 10);

            money.Show();

            // Определение, хватит ли денежных средств на покупку товара на сумму 750 и 1100 рублей.
            money.checkN(750);
            money.checkN(1100);

            // Определение, сколько штук товара стоимости 50 можно купить на имеющиеся денежные средства.
            money.buyN(50);

            // Свойство, позволяющее получить-установить значение полей.
            money.Second = 15;
            Console.WriteLine(money.Second);

            // Свойство, позволяющее расчитатать сумму денег
            Console.WriteLine(money.Sum);

            // Индексаторы
            Console.WriteLine(money[0]);
            Console.WriteLine(money[1]);
            Console.WriteLine(money[10]); // Неверный индекс

            // Перегрузки операций ++ и --
            money.Show();
            money++;

            money.Show();
            money--;

            money.Show();

            // Перегрузка операции !
            Console.WriteLine(!money);

            // Перегрузка операции +
            money.Show();
            money = money + 10;
            money.Show();
        }

        // Здесь заканчивается код
    }
}
