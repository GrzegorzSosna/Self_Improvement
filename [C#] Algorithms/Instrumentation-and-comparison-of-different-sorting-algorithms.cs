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

        static void RandomData(int size, int selectedAlgorithm)
        {
            int[] array = new int[size];
            int[] sortedArray = new int[size];
            Console.WriteLine("\n-> Tablica liczb generowanych w postaci LOSOWEJ");
            Random numberRnd = new Random();
            Console.WriteLine("\nTablica nieposortowana:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = numberRnd.Next(1, array.Length + 1);
                Console.Write(array[i]);
                if (i < array.Length - 1)
                    Console.Write(", ");
            }
            if (selectedAlgorithm == 1)
                sortedArray = InsertionSort(array);

            Console.WriteLine("\nTablica posortowana:");
            for (int i = 0; i < sortedArray.Length; i++)
            {
                Console.Write(sortedArray[i]);
                if (i < array.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("\nLiczba operacji potrzebnych do posortowania tablicy: " + equalOperationCounter);
        }

        static void GrowingData(int size, int selectedAlgorithm)
        {
            int[] array = new int[size];
            int[] sortedArray = new int[size];
            Console.WriteLine("\n-> Tablica liczb generowanych w postaci ROSNĄCEJ");
            Console.WriteLine("\nTablica nieposortowana:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
                Console.Write(array[i]);
                if (i < array.Length - 1)
                    Console.Write(", ");
            }
            if (selectedAlgorithm == 1)
                sortedArray = InsertionSort(array);

            Console.WriteLine("\nTablica posortowana:");
            for (int i = 0; i < sortedArray.Length; i++)
            {
                Console.Write(sortedArray[i]);
                if (i < array.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("\nLiczba operacji potrzebnych do posortowania tablicy: " + equalOperationCounter);
        }

        static void DecreasingData(int size, int selectedAlgorithm)
        {
            int[] array = new int[size];
            int[] sortedArray = new int[size];
            Console.WriteLine("\n-> Tablica liczb generowanych w postaci MALEJĄCEJ");
            Console.WriteLine("\nTablica nieposortowana:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array.Length - i;
                Console.Write(array[i]);
                if (i < array.Length - 1)
                    Console.Write(", ");
            }
            if (selectedAlgorithm == 1)
                sortedArray = InsertionSort(array);

            Console.WriteLine("\nTablica posortowana:");
            for (int i = 0; i < sortedArray.Length; i++)
            {
                Console.Write(sortedArray[i]);
                if (i < array.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("\nLiczba operacji potrzebnych do posortowania tablicy: " + equalOperationCounter);
        }

        static void FixedData(int size, int selectedAlgorithm)
        {
            int[] array = new int[size];
            int[] sortedArray = new int[size];
            Console.WriteLine("\n-> Tablica liczb generowanych w postaci STAŁEJ");
            Console.WriteLine("\nTablica nieposortowana:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array.Length / 2;
                Console.Write(array[i]);
                if (i < array.Length - 1)
                    Console.Write(", ");
            }
            if (selectedAlgorithm == 1)
                sortedArray = InsertionSort(array);

            Console.WriteLine("\nTablica posortowana:");
            for (int i = 0; i < sortedArray.Length; i++)
            {
                Console.Write(sortedArray[i]);
                if (i < array.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("\nLiczba operacji potrzebnych do posortowania tablicy: " + equalOperationCounter);
        }

        static void VData(int size, int selectedAlgorithm)
        {
            int[] array = new int[size];
            int[] sortedArray = new int[size];
            Console.WriteLine("\n-> Tablica liczb generowanych w postaci V-KSZTAŁTNEJ");
            Console.WriteLine("\nTablica nieposortowana:");
            int numberRnd = array.Length / 2 + 1;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = numberRnd;
                if (i < array.Length / 2)
                    numberRnd--;
                else
                    numberRnd++;               
                Console.Write(array[i]);
                if (i < array.Length - 1)
                    Console.Write(", ");
            }
            if (selectedAlgorithm == 1)
                sortedArray = InsertionSort(array);

            Console.WriteLine("\nTablica posortowana:");
            for (int i = 0; i < sortedArray.Length; i++)
            {
                Console.Write(sortedArray[i]);
                if (i < array.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("\nLiczba operacji potrzebnych do posortowania tablicy: " + equalOperationCounter);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("(1) Instrumentacja algorytmu sortujacego przez wstawianie (Insertion Sort):");
            RandomData(21,1);
            GrowingData(21, 1);
            DecreasingData(21, 1);
            FixedData(21, 1);
            VData(21, 1);

        }
    }
}
