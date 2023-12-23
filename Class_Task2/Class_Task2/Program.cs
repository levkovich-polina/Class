using System;
using System.Collections.Generic;
using System.Threading;

namespace Class_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество пекарей:");
            int numBakers = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество курьеров:");
            int numCouriers = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество заказов:");
            int numOrders = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите размер склада:");
            int storageSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            PizzaWorkers workers = new PizzaWorkers(numBakers, numCouriers);
            PizzaShop pizzaShop = new PizzaShop(workers, storageSize);

            for (int i = 1; i <= numOrders; i++)
            {
                pizzaShop.TakeOrder(i);
                pizzaShop.ProcessOrders();
                pizzaShop.PrintOrdersState();

                Console.WriteLine();
            }

            pizzaShop.AnalyzeOrders();

            Console.ReadLine();
        }
    }

    class PizzaWorkers
    {
        public int numBakers { get; }
        public int numCouriers { get; }

        public PizzaWorkers(int numBakers, int numCouriers)
        {
            this.numBakers = numBakers;
            this.numCouriers = numCouriers;
        }
    }

    class PizzaShop
    {
        private PizzaWorkers workers;
        private int storageSize;
        private int currentStorage = 0;

        public PizzaShop(PizzaWorkers workers, int storageSize)
        {
            this.workers = workers;
            this.storageSize = storageSize;
        }
        //поступление заказа номер
        public void TakeOrder(int orderNumber)
        {
            Console.WriteLine($"Поступил заказ №{orderNumber}");
        }
        //работа пекарей и курьеров
        public void ProcessOrders()
        {
            for (int i = 1; i <= workers.numBakers; i++)
            {
                if (currentStorage == storageSize)
                {
                    Console.WriteLine($"Пекарь {i} ожидает свободного места на складе");
                    continue;
                }

                Console.WriteLine($"Пекарь {i} готовит пиццу");

                //временя на приготовление пиццы
                System.Threading.Thread.Sleep(1000);

                Console.WriteLine($"Пекарь {i} положил пиццу на склад");
                currentStorage++;
            }

            for (int i = 1; i <= workers.numCouriers; i++)
            {
                if (currentStorage == 0)
                {
                    Console.WriteLine($"Курьер {i} ожидает готовых пицц на складе");
                    continue;
                }

                Console.WriteLine($"Курьер {i} забрал пиццу со склада");

                //временя на доставку пиццы
                System.Threading.Thread.Sleep(1000);

                Console.WriteLine($"Курьер {i} доставил пиццу клиенту");
                currentStorage--;
            }
        }
        //состояние заказа
        public void PrintOrdersState()
        {
            Console.WriteLine($"Состояние заказов: {currentStorage} пицц на складе, {workers.numBakers} пекарей готовят, {workers.numCouriers} курьеров доставляют");
        }
        //выполнение заказа и рекомендации
        public void AnalyzeOrders()
        {
            if (currentStorage < storageSize)
            {
                Console.WriteLine("Рекомендуется увеличить количество заказов");
            }
            else if (currentStorage == storageSize)
            {
                Console.WriteLine("Рекомендуется расширить склад");
            }
            else if (currentStorage > storageSize)
            {
                int extraPizzas = currentStorage - storageSize;
                Console.WriteLine($"Рекомендуется продать {extraPizzas} пицц клиентам");
            }
        }
    }
}
