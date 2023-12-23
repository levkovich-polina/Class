using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Class_Task1
{
    internal class Program
    {
        public static void Main()
        {
            Console.Write("Введите количество строк массива: ");
            int count = Convert.ToInt32(Console.ReadLine());

            int[][] array = new int[count][];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Строка {i + 1}: ");
                var elementsString = Console.ReadLine();
                var elements = elementsString.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                array[i] = new int[elements.Length];
                for (int j = 0; j < elements.Length; j++)
                {
                    if (int.TryParse(elements[j], out int value))
                    {
                        array[i][j] = value;
                    }
                    else
                    {
                        array[i][j] = 0;
                    }
                }
            }
            Console.WriteLine("Ваш массив:");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write($"{array[i][j]} ") ;
                }
                Console.WriteLine();
            }
            int max;
            int min;
            int sum;
            Console.WriteLine("Итог:");
            for (int i = 0; i < count; i++)
            {
                Min(in array[i], out min);
                Max(in array[i], out max);
                Sum(in array[i], out sum);

                Console.WriteLine($"Строка {i + 1}:  Минимальное значение - {min}, Максимальное значение - {max}, Сумма всех значений - {sum}");
            }
            Console.ReadLine();
        }
        static void Min(in int[] row, out int min)
        {
             min = 100000;
            for (int i = 0; i < row.Length; i++)
            {
                int value = row[i];
                if (value < min)
                {
                    min = value;
                }
            }
        }
        static  void Max(in int[] row, out int max)
        {
            max = -1000;
            for (int i = 0; i < row.Length; i++)
            {
                int value = row[i];

                if (value > max)
                {
                    max = value;
                }
            }
        }
         static void Sum(in int[] row, out int sum)
        {
             sum = 0;
            for (int i = 0; i < row.Length; i++)
            {
                int value = row[i];

                sum += value;
            }
        }
    }
}
