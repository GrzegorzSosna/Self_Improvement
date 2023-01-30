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

        // iteracyjna implementacja sortowania Quick Sort 
        static int[] QuickSortIteration(int[] array)
        {
            equalOperationCounter = 0;
            int leftElement, rightElement;
            int[] stackLeft = new int[array.Length];
            int[] stackRight = new int[array.Length];
            int border = 0;
            stackLeft[border] = 0;
            stackRight[border] = array.Length - 1;

            while (border >= 0)
            {
                leftElement = stackLeft[border];
                rightElement = stackRight[border];
                border--;

                while (leftElement < rightElement)
                {
                    int i = leftElement;
                    int j = rightElement;
                    int pivot = array[(leftElement + rightElement) / 2];

                    while (i <= j)
                    {
                        equalOperationCounter++;
                        while (array[i] < pivot)
                            i++;
                        while (pivot < array[j])
                            j--;

                        if (i <= j)
                        {                          
                            int bufor = array[i];
                            array[i] = array[j];
                            array[j] = bufor;
                            i++;
                            j--;
                        }
                    };

                    if (i < rightElement)
                    {
                        border++;
                        stackLeft[border] = i;
                        stackRight[border] = rightElement;
                    }
                    rightElement = j;
                };
            };
            return array;
        }

        // rekurencyjna implementacja sortowania Quick Sort 
        static int[] QuickSortRecursion(int[] array, int l, int p)
        {
            int i, j;
            i = l;
            j = p;
            int pivot = array[(l + p) / 2]; 

            do
            {
                equalOperationCounter++;
                while (array[i] < pivot)
                    i++;
                while (pivot < array[j])
                    j--;
                if (i <= j)
                {
                    int bufor = array[i];
                    array[i] = array[j];
                    array[j] = bufor;
                    i++;
                    j--;
                }
            }
            while (i <= j);

            if (l < j)
                QuickSortRecursion(array, l, j);
            if (i < p)
                QuickSortRecursion(array, i, p);

            return array;
        }

        // wybór algorytmu sortowania
        static int[] SelectedAlgorithm(int choice, int[] array)
        {
            // wybór pivota
            int leftElement = 0;
            int rightElement = array.Length - 1;
            int middlePivot = array[(leftElement + rightElement) / 2];
            int rightmostPivot = array[rightElement];
            Random rnd = new Random();
            int randomPivot = rnd.Next(array.Length);

            if (choice == 1)
                return QuickSortIteration(array);
            if (choice == 2)
            {
                equalOperationCounter = 0;
                return QuickSortRecursion(array, 0, array.Length - 1);
            }             
            return array;
        }

        // generowanie tablicy w postaci losowej
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

        // generowanie tablicy w postaci V-kształtnej
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
            Console.WriteLine("(1) Instrumentacja algorytmu Quick Sort - implementacja iteracyjna:");
            RandomData(21, 1);
            VData(21, 1);

            Console.WriteLine("\n\n(2) Instrumentacja algorytmu Quick Sort - implementacja rekurencyjna:");
            RandomData(21, 2);
            VData(21, 2);
        }
    }
}
