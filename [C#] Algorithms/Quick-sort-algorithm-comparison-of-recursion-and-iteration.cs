/* Zadanie wykonane w ramach przedmiotu "Algorytmy i struktury danych". 
Celem projektu jest porównanie szybkości działania algorytmu quicksort w postaci iteracyjnej oraz rekurencyjnej dla dowolnego 
ciągu losowego oraz A-kształtnego (np. ciąg 2, 3, 5, 4, 3, 2) oraz dla pivota wybranego kolejno w następujący sposób: 
skrajnie prawy element, środkowy element, losowy element. */

using System;
using System.Diagnostics;

namespace ConsoleApp
{
    class Program
    {
        private static ulong equalOperationCounter;

        static int[] QuickSort(int[] array, int pivot)
        {
            equalOperationCounter = 0;
            int bufor;
            int border = 0;
            int leftElement = 0, rightElement = array.Length - 1;
         
            while (equalOperationCounter < 10) // testowanie
            {
                // wyznaczanie granicy -> dzielenie problemu na dwa podproblemy
                for (int i = leftElement; i < rightElement; i++)
                {
                    equalOperationCounter++;
                    if (array[i] < array[pivot])
                    {
                        bufor = array[i];
                        array[i] = array[border];
                        array[border] = bufor;
                        border++;
                    }
                }
                bufor = array[pivot];
                array[pivot] = array[border];
                array[border] = bufor;             
            }
            return array;
        }

        static int[] SelectedAlgorithm(int choice, int[] array)
        {
            // pivot -> ostatni element tablicy
            if (choice == 1)
                return QuickSort(array, array.Length - 1);
            return array;
        }

        static void RandomData(int size, int selectedAlgorithm)
        {
            int[] array = new int[size];
            int[] sortedArray = new int[size];
            Console.WriteLine("\n-> Tablica liczb generowanych w postaci LOSOWEJ");
            Random numberRnd = new Random();
            Console.Write("\nTablica nieposortowana: ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = numberRnd.Next(1, array.Length + 1);
                Console.Write(array[i]);
                if (i < array.Length - 1)
                    Console.Write(", ");
            }
            sortedArray = SelectedAlgorithm(selectedAlgorithm, array);

            Console.Write("\nTablica posortowana: ");
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
            Console.Write("\nTablica nieposortowana: ");
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
            sortedArray = SelectedAlgorithm(selectedAlgorithm, array);

            Console.Write("\nTablica posortowana: ");
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
            Console.WriteLine("(1) Instrumentacja algorytmu Quick Sort:");
            RandomData(21, 1);
            //VData(21, 1);
        }
    }
}
