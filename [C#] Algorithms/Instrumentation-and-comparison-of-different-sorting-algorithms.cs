using System;
using System.Diagnostics;

namespace ConsoleApp
{
    class Program
    {
        private static ulong equalOperationCounter;

        static int[] InsertionSort(int[] array)
        {
            equalOperationCounter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    equalOperationCounter++;
                    if (array[j - 1] > array[j])
                    {
                        int buffor = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = buffor;
                    }
                    else break;
                }
            }
            return array;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("(1) Instrumentacja algorytmu sortujacego przez wstawianie (Insertion Sort):");

            // dane w postaci losowej
            Console.WriteLine("\n-> Tablica liczb generowanych w postaci LOSOWEJ");
            int[] array = new int[20];
            Random numberRnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = numberRnd.Next(1,21);
            }
            Console.WriteLine("\nTablica nieposortowana:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ", ");
            }
            int[] sortedArray = InsertionSort(array);
            Console.WriteLine("\nTablica posortowana:");
            for (int i = 0; i < sortedArray.Length; i++)
            {
                Console.Write(sortedArray[i] + ", ");
            }
            Console.WriteLine("\nLiczba operacji potrzebnych do posortowania tablicy: " + equalOperationCounter);

            // dane w postaci rosnącej
            Console.WriteLine("\n-> Tablica liczb generowanych w postaci ROSNĄCEJ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }
            Console.WriteLine("\nTablica nieposortowana:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ", ");
            }
            sortedArray = InsertionSort(array);
            Console.WriteLine("\nTablica posortowana:");
            for (int i = 0; i < sortedArray.Length; i++)
            {
                Console.Write(sortedArray[i] + ", ");
            }
            Console.WriteLine("\nLiczba operacji potrzebnych do posortowania tablicy: " + equalOperationCounter);

        }
    }
}
