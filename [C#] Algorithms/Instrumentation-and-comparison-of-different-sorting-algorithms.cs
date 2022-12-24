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

        static int[] HeapSort(int[] array)
        {
            equalOperationCounter = 0;                   
            for(int i = array.Length; i > 0; i--)
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
            if (choice == 3)
                return HeapSort(array);
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

        static void GrowingData(int size, int selectedAlgorithm)
        {
            int[] array = new int[size];
            int[] sortedArray = new int[size];
            Console.WriteLine("\n-> Tablica liczb generowanych w postaci ROSNĄCEJ");
            Console.Write("\nTablica nieposortowana: ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
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

        static void DecreasingData(int size, int selectedAlgorithm)
        {
            int[] array = new int[size];
            int[] sortedArray = new int[size];
            Console.WriteLine("\n-> Tablica liczb generowanych w postaci MALEJĄCEJ");
            Console.Write("\nTablica nieposortowana: ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array.Length - i;
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

        static void FixedData(int size, int selectedAlgorithm)
        {
            int[] array = new int[size];
            int[] sortedArray = new int[size];
            Console.WriteLine("\n-> Tablica liczb generowanych w postaci STAŁEJ");
            Console.Write("\nTablica nieposortowana: ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array.Length / 2;
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
            // funkcja(wielkość danych, rodzaj algorytmu)
            // 1-> Insertion Sort, 3-> Heap Sort
            Console.WriteLine("(1) Instrumentacja algorytmu sortującego przez wstawianie (Insertion Sort):");
            RandomData(21, 1);
            GrowingData(21, 1);
            DecreasingData(21, 1);
            FixedData(21, 1);
            VData(21, 1);

            Console.WriteLine("\n\n(3) Instrumentacja algorytmu sortującego przez kopcowanie (Heap Sort):");
            RandomData(21, 3);
            GrowingData(21, 3);
            DecreasingData(21, 3);
            FixedData(21, 3);
            VData(21, 3);
        }
    }
}
