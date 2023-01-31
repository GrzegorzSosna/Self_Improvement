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
        static int[] QuickSortIteration(int[] array, string pivotType)
        {
            equalOperationCounter = 0;
            int leftElement, rightElement;
            int[] stackLeft = new int[array.Length];
            int[] stackRight = new int[array.Length];
            int pivot = 0;
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
					
                    if (pivotType == "middlePivot")
                        pivot = array[(leftElement + rightElement) / 2];
                    if (pivotType == "rightmostPivot")
                        pivot = array[rightElement];
                    Random rnd = new Random();
                    if (pivotType == "randomPivot")
                        pivot = array[rnd.Next(rightElement)];

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
        static int[] QuickSortRecursion(int[] array, int l, int p, string pivotType)
        {
            int i, j;
            int pivot = 0;
            i = l;
            j = p;

            if (pivotType == "middlePivot")
                pivot = array[(l + p) / 2];
            if (pivotType == "rightmostPivot")
                pivot = array[p];
            Random rnd = new Random();
            if (pivotType == "randomPivot")
                pivot = array[rnd.Next(p)];

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
                QuickSortRecursion(array, l, j, pivotType);
            if (i < p)
                QuickSortRecursion(array, i, p, pivotType);

            return array;
        }        

        // wybór algorytmu sortowania oraz pivota
        static int[] SelectedAlgorithm(int choice, int[] array)
        {
            if (choice == 1)
                return QuickSortIteration(array, "middlePivot");
            if (choice == 2)
            {
                equalOperationCounter = 0;
                return QuickSortRecursion(array, 0, array.Length - 1, "middlePivot");
            }
            if (choice == 3)
                return QuickSortIteration(array, "rightmostPivot");
            if (choice == 4)
            {
                equalOperationCounter = 0;
                return QuickSortRecursion(array, 0, array.Length - 1, "rightmostPivot");
            }
            if (choice == 5)
                return QuickSortIteration(array, "randomPivot");
            if (choice == 6)
            {
                equalOperationCounter = 0;
                return QuickSortRecursion(array, 0, array.Length - 1, "randomPivot");
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
            Console.WriteLine("(1) Instrumentacja algorytmu Quick Sort (implementacja: iteracyjna, pivot: środkowy)");
            RandomData(21, 1);
            VData(21, 1);

            Console.WriteLine("\n\n(2) Instrumentacja algorytmu Quick Sort (implementacja: rekurencyjna, pivot: środkowy)");
            RandomData(21, 2);
            VData(21, 2);

            Console.WriteLine("\n\n(3) Instrumentacja algorytmu Quick Sort (implementacja: iteracyjna, pivot: skrajnie prawy)");
            RandomData(21, 3);
            VData(21, 3);

            Console.WriteLine("\n\n(4) Instrumentacja algorytmu Quick Sort (implementacja: rekurencyjna, pivot: skrajnie prawy)");
            RandomData(21, 4);
            VData(21, 4);

            Console.WriteLine("\n\n(5) Instrumentacja algorytmu Quick Sort (implementacja: iteracyjna, pivot: losowy)");
            RandomData(21, 5);
            VData(21, 5);

            Console.WriteLine("\n\n(6) Instrumentacja algorytmu Quick Sort (implementacja: rekurencyjna, pivot: losowy)");
            RandomData(21, 6);
            VData(21, 6);

        }
    }
}
