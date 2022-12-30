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
                        int bufor = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = bufor;
                    }
                    else break;
                }
            }
            return array;
        }

        static int[] SelectionSort(int[] array)
        {
            equalOperationCounter = 0;
            int bufor;
            for (int i = 0; i <= array.Length - 1; i++)
            {
                int smallest = i;
                for (int j = i + 1; j <= array.Length - 1; j++)
                {
                    equalOperationCounter++;
                    if (array[j] < array[smallest])
                    {
                        smallest = j;
                    }
                }
                bufor = array[smallest];
                array[smallest] = array[i];
                array[i] = bufor;
            }
            return array;
        }

        static int[] HeapSort(int[] array)
        {
            equalOperationCounter = 0;
            for (int i = array.Length; i > 0; i--)
            {
                int bufor;
                int lastParent = i / 2 - 1;
                // kopcowanie
                for (int parent = lastParent; parent >= 0; parent--)
                {
                    equalOperationCounter++;
                    int heapSize = i;
                    int maxIndex = parent;
                    int leftChild = parent * 2 + 1;
                    int rightChild = parent * 2 + 2;

                    if (leftChild < heapSize && array[leftChild] > array[maxIndex])
                    {
                        maxIndex = leftChild;
                    }
                    if (rightChild < heapSize && array[rightChild] > array[maxIndex])
                    {
                        maxIndex = rightChild;
                    }
                    if (maxIndex != parent)
                    {
                        bufor = array[parent];
                        array[parent] = array[maxIndex];
                        array[maxIndex] = bufor;
                    }
                }
                // sortowanie
                bufor = array[i - 1];
                array[i - 1] = array[0];
                array[0] = bufor;
            }
            return array;
        }

        static int[] SelectedAlgorithm(int choice, int[] array)
        {
            if (choice == 1)
                return InsertionSort(array);
            if (choice == 2)
                return SelectionSort(array);
            if (choice == 3)
                return HeapSort(array);
            return array;
        }

        static void RandomData(int size, int selectedAlgorithm)
        {
            int[] array = new int[size];        
            Random numberRnd = new Random();          
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = numberRnd.Next(1, array.Length + 1);
            }
            long startingTime = Stopwatch.GetTimestamp();
            SelectedAlgorithm(selectedAlgorithm, array);
            long endingTime = Stopwatch.GetTimestamp();
            long iterationElapsedTime = endingTime - startingTime;
            Console.WriteLine($"Tablica generowana LOSOWO. Liczba operacji porównania: {equalOperationCounter}, czas wykonania: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]");
        }

        static void GrowingData(int size, int selectedAlgorithm)
        {
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }
            long startingTime = Stopwatch.GetTimestamp();
            SelectedAlgorithm(selectedAlgorithm, array);
            long endingTime = Stopwatch.GetTimestamp();
            long iterationElapsedTime = endingTime - startingTime;
            Console.WriteLine($"Tablica generowana ROSNĄCO. Liczba operacji porównania: {equalOperationCounter}, czas wykonania: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]");
        }

        static void DecreasingData(int size, int selectedAlgorithm)
        {
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array.Length - i;
            }
            long startingTime = Stopwatch.GetTimestamp();
            SelectedAlgorithm(selectedAlgorithm, array);
            long endingTime = Stopwatch.GetTimestamp();
            long iterationElapsedTime = endingTime - startingTime;
            Console.WriteLine($"Tablica generowana MALEJĄCO. Liczba operacji porównania: {equalOperationCounter}, czas wykonania: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]");
        }

        static void FixedData(int size, int selectedAlgorithm)
        {
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array.Length / 2;
            }
            long startingTime = Stopwatch.GetTimestamp();
            SelectedAlgorithm(selectedAlgorithm, array);
            long endingTime = Stopwatch.GetTimestamp();
            long iterationElapsedTime = endingTime - startingTime;
            Console.WriteLine($"Tablica w postaci STAŁEJ. Liczba operacji porównania: {equalOperationCounter}, czas wykonania: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]");
        }

        static void VData(int size, int selectedAlgorithm)
        {
            int[] array = new int[size];
            int numberRnd = array.Length / 2 + 1;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = numberRnd;
                if (i < array.Length / 2)
                    numberRnd--;
                else
                    numberRnd++;
            }
            long startingTime = Stopwatch.GetTimestamp();
            SelectedAlgorithm(selectedAlgorithm, array);
            long endingTime = Stopwatch.GetTimestamp();
            long iterationElapsedTime = endingTime - startingTime;
            Console.WriteLine($"Tablica w postaci V-KSZTAŁTNEJ. Liczba operacji porównania: {equalOperationCounter}, czas wykonania: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]");
        }

        static void Main(string[] args)
        {
            for (int arraysSizes = 100; arraysSizes <= 500; arraysSizes += 100)
            {
                Console.WriteLine($"\n----- TABLICA {arraysSizes}-ELEMENTOWA -----");
                // 1-> Insertion Sort, 2-> Selection Sort, 3-> Heap Sort
                Console.WriteLine("\n(1) INSERTION SORT -> instrumentacja algorytmu sortującego przez wstawianie");
                RandomData(arraysSizes, 1);
                GrowingData(arraysSizes, 1);
                DecreasingData(arraysSizes, 1);
                FixedData(arraysSizes, 1);
                VData(arraysSizes, 1);

                Console.WriteLine("\n(2) SELECTION SORT -> instrumentacja algorytmu sortującego przez wybieranie");
                RandomData(arraysSizes, 2);
                GrowingData(arraysSizes, 2);
                DecreasingData(arraysSizes, 2);
                FixedData(arraysSizes, 2);
                VData(arraysSizes, 2);

                Console.WriteLine("\n(3) HEAP SORT -> instrumentacja algorytmu sortującego przez kopcowanie");
                RandomData(arraysSizes, 3);
                GrowingData(arraysSizes, 3);
                DecreasingData(arraysSizes, 3);
                FixedData(arraysSizes, 3);
                VData(arraysSizes, 3);
            }
        }
    }
}
