using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Class_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Что хотите сделать?");
            Console.WriteLine("1) задать данные массива самостоятельно");
            Console.WriteLine("2) заполнить массив с помощью датчика случайных чисел");
            Console.WriteLine("3) вывести на экран содержимое массива из указанного диапазона индексов");
            Console.WriteLine("4) вернуть список индексов для введённого элемента");
            Console.WriteLine("5) удалить из массива (искомый элемент в массиве может встречаться несколько раз) искомый элемент");
            Console.WriteLine("6) вернуть максимальное значение из массива.");
            Console.WriteLine("7) выполнить сложение двух массивов одинаковой длины поэлементно");
            Console.WriteLine("8) выполнить сортировку элементов массива по возрастанию.");
            Console.WriteLine("9) если хотите выйти.");
            int number;
            int[] array = { };
            int[] array1 = { };
            while ((number = Convert.ToInt32(Console.ReadLine())) != 9)
            {
                if (number == 1)
                {
                    Console.Write("Введите размер массива: ");
                    int size = Convert.ToInt32(Console.ReadLine());
                    array = InputData(size);
                }
                else if (number == 2)
                {
                    Console.Write("Введите размер массива: ");
                    int size = Convert.ToInt32(Console.ReadLine());
                    array1 = InputDataRandom(size);
                }
                else if (number == 3)
                {
                    int size = array.Length;
                    int size1 = array1.Length;
                    Console.WriteLine("Начальный элемент:");
                    int first = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Конечный элемент:");
                    int last = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Массив, вводимый с консоли: ");
                    PrintElement(last, in array, first);
                    Console.WriteLine();                                                                             
                    Console.Write("Массив рандомных чисел: ");
                    PrintElement(last, in array1, first);
                    Console.WriteLine();          
                }
                else if (number == 4)
                {
                    int size = array.Length;
                    int size1 = array1.Length;
                    Console.WriteLine("Какой элемент хотите найти:");
                    int searchValue = int.Parse(Console.ReadLine());
                    Console.WriteLine("В каком массиве хотите найти:");
                    int arr = Convert.ToInt32(Console.ReadLine());
                    List<int> element = new List<int>();
                    if (arr == 1)
                    {
                        element = FindValue(size, array, searchValue);
                    }
                    else if(arr == 2)
                    {
                        element = FindValue(size1, array1, searchValue);
                    }
                    Console.WriteLine("Индексы найденных элементов:");
                    for (int i = 0; i < element.Count; i++)
                    {
                        Console.WriteLine(element[i]);
                    }
                }
                else if (number == 5)
                {
                    Console.WriteLine("Введите элемент для удаления:");
                    int delete = int.Parse(Console.ReadLine());
                    Console.WriteLine("В каком массиве хотите найти:");
                    int arr = int.Parse(Console.ReadLine());
                    if (arr == 1)
                    {
                        DelValue(ref array, delete);
                    }
                    else if (arr == 2)
                    {
                        DelValue(ref array1, delete);
                    }

                }
                else if(number==6)
                {
                    Console.WriteLine("В каком массиве хотите найти:");
                    int arr = int.Parse(Console.ReadLine());
                    if (arr == 1)
                    {
                        Max(in array, out int max);
                        Console.WriteLine($"Максимальное значение: {max}");    
                    }
                    else if (arr == 2)
                    {
                        Max(in array1, out int max);
                        Console.WriteLine($"Максимальное значение: {max}");
                    }

                }
                else if(number == 7)
                {
                    if(array.Length == array1.Length)
                    {
                        int[] array2 = Sum(in array,in array1);
                        Console.Write("Массив после сложения ");
                        Print(array2.Length, array2);
                    }
                    else
                    {
                        Console.WriteLine("Нельзя выполнить сложение, так как длина массивов разная");
                    }
                }
                else if(number == 8)
                {
                    int size = array.Length;
                    int size1 = array1.Length;
                    Console.WriteLine("Какой массив хотите сортировать:");
                    int arr = int.Parse(Console.ReadLine());
                    if (arr == 1)
                    {
                        Sort(ref array);
                    }
                    else if (arr == 2)
                    {
                        Sort(ref array1);
                    }
                }
                Console.WriteLine("Что хотите сделать?");
                Console.WriteLine("1) задать данные массива самостоятельно");
                Console.WriteLine("2) заполнить массив с помощью датчика случайных чисел");
                Console.WriteLine("3) вывести на экран содержимое массива из указанного диапазона индексов");
                Console.WriteLine("4) вернуть список индексов для введённого элемента");
                Console.WriteLine("5) удалить из массива (искомый элемент в массиве может встречаться несколько раз) искомый элемент");
                Console.WriteLine("6) вернуть максимальное значение из массива.");
                Console.WriteLine("7) выполнить сложение двух массивов одинаковой длины поэлементно");
                Console.WriteLine("8) выполнить сортировку элементов массива по возрастанию.");
                Console.WriteLine("9) если хотите выйти.");
            }
            Console.WriteLine("Программа завершина!");
            Console.ReadLine();
        }
        static int[] InputData(int size)
        {
            int[] array = new int[size];
            Console.WriteLine("Введите элементы:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{i + 1}) ");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            return array;
        }
        static int[] InputDataRandom(int size)
        {
            int[] array = new int[size];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 100);
            }
            return array;
        }
        static void Print( int size, in int[] array)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
        static void PrintElement(int last, in int[] array, int first)
        {
            for (int i = first; i <= last; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
        static List<int> FindValue(in int size, in int[] array, in int value)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < size; i++)
            {
                if (array[i] == value)
                {
                    indexes.Add(i);
                }
            }
            return indexes;
        }

        static void DelValue(ref int[] array, in int value)
        {
            int count = array.Length;
            int found = 0;

            for (int i = 0; i < count; i++)
            {
                if (array[i] == value)
                {
                    found++;
                    array[i] = 0;
                }
            }

            int[] newArray = new int[count - found];
            int newIndex = 0;

            for (int i = 0; i < count; i++)
            {
                if (array[i] != 0)
                {
                    newArray[newIndex] = array[i];
                    newIndex++;
                }
            }

            array = newArray;
        }
    
        static  void Max(in int[] array, out int max)
        {
            max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
        }

        static int[] Sum(in int[] array, in int[] arr)
        {
            int[] array1 = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array1[i] += array[i] + arr[i];
            }
            return array1;
        }

        static void Sort(ref int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

    }
}

