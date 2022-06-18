using System;

namespace ConsoleApp
{
    class Program
    {
        static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int buffor = array[j];
                        array[j] = array[i];
                        array[i] = buffor;
                    }
                }
            }
            return array;
        }

        static void Main(string[] args)
        {           
            int[] array = new int[10] { 3, 115, 74, 21, 45, 123, 2, 34, 85, 23 };
            int[] sortedArray = BubbleSort(array);

            Console.WriteLine("Tablica posortowana :");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(sortedArray[i]);
            }
        }
    }
}
