/* Zadanie wykonane w ramach przedmiotu "Algorytmy i struktury danych". 
Proszę zweryfikować przedstawioną ocenę średniej i pesymistycznej złożoności wyszukiwania liniowego (10 pkt) 
lub binarnego (20pkt). W szczególności, proszę przeprowadzić analizę za pomocą instrumentacji i pomiarów czasu. 
W porównaniu proszę wykorzystać tablice liczb całkowitych o rozmiarze rzędu 230 bajtów (228 elementów typu 
uint/int). */

using System;
using System.Diagnostics;

namespace ConsoleApp
{
    class Program
    {
        private static ulong equalOperationCounter;

        static bool BinarySearch(int[] vector, int number)
        {
            int lowerLimitVector = 0;
            int upperLimitVector = vector.Length - 1;
            int middleElement = 0;

            while (lowerLimitVector <= upperLimitVector)
            {
                equalOperationCounter++;
                middleElement = (lowerLimitVector + upperLimitVector) / 2;
                if (number < vector[middleElement])
                    upperLimitVector = middleElement - 1;
                if (number > vector[middleElement])
                    lowerLimitVector = middleElement + 1;
                if (number == vector[middleElement])
                {
                    return true;
                }
            }
            return false;
        }
        
        static void BinarySearchImplementation(int[] data, int number)
        {
            if (BinarySearch(data, number))
            {
                Console.WriteLine($"Element {number} znajduje się w zbiorze.");
            }
            else
            {
                Console.WriteLine($"Element {number} nie znajduje się w zbiorze.");
            }
        }

        static void BinarySearchMin(int[] data)
        {
            equalOperationCounter = 0;
            int number = data[(data.Length - 1) / 2];
            if (BinarySearch(data, number))
            {
                Console.WriteLine($"Złożoność minimalna: element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
                    $"Liczba operacji porównania: {equalOperationCounter}");
            }
            else
            {
                Console.WriteLine($"Złożoność minimalna: element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
                    $"Liczba operacji porównania: {equalOperationCounter}");
            }
        }

        static void BinarySearchMax(int[] data)
        {
            equalOperationCounter = 0;
            int number = data[data.Length - 1];
            if (BinarySearch(data, number))
            {
                Console.WriteLine($"Złożoność maksymalna: element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
                    $"Liczba operacji porównania: {equalOperationCounter}");
            }
            else
            {
                Console.WriteLine($"Złożoność maksymalna: element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
                    $"Liczba operacji porównania: {equalOperationCounter}");
            }
        }

        static void BinarySearchAvg(int[] data)
        {
            ulong totalOperationsCounter = 0;
            for (int i = 0; i < data.Length; i++)
            {
                equalOperationCounter = 0;
                int number = data[i];
                if (BinarySearch(data, number))
                {
                    Console.WriteLine($"Złożoność średnia - iteracja: element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
                        $"Liczba operacji porównania: {equalOperationCounter}");
                }
                else
                {
                    Console.WriteLine($"Złożoność średnia - iteracja: element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
                        $"Liczba operacji porównania: {equalOperationCounter}");
                }
                totalOperationsCounter += equalOperationCounter;
            }
            Console.WriteLine($"Złożoność średnia - iteracja: łączna liczba operacji porównania {totalOperationsCounter}, " +
                    $"liczba iteracji: {data.Length}, średnia operacji porównania: {totalOperationsCounter / (ulong)data.Length}");
        }

        static void BinarySearchTimeMin(int[] data)
        {
            uint iterationsNumber = 10;
            long elapsedTime = 0;
            long minTime = long.MaxValue;
            long maxTime = long.MinValue;
            for (int n = 0; n < (iterationsNumber + 1 + 1); ++n)
            {
                long startingTime = Stopwatch.GetTimestamp();
                long endingTime = Stopwatch.GetTimestamp();
                long iterationElapsedTime = endingTime - startingTime;
                int number = data[(data.Length - 1) / 2];

                if (BinarySearch(data, number))
                {
                    Console.WriteLine($"Złożoność minimalna: element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
                        $"Czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")}");
                }
                else
                {
                    Console.WriteLine($"Złożoność minimalna: element {number} nie został odnaleziony w zbiorze {data.Length}-elementowym. " +
                        $"Czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")}");
                }

                elapsedTime += iterationElapsedTime;
                if (iterationElapsedTime < minTime)
                {
                    minTime = iterationElapsedTime;
                }
                if (iterationElapsedTime > maxTime)
                {
                    maxTime = iterationElapsedTime;
                }
            }

            elapsedTime -= (minTime + maxTime);
            double elapsedSeconds = elapsedTime * (1.0 / (iterationsNumber * Stopwatch.Frequency));
            Console.WriteLine($"Złożoność minimalna: liczba powtórzeń: {iterationsNumber}, średni czas przebiegu operacji: {elapsedSeconds.ToString("F10")} [s], zakładając odrzucenie czasów skrajnych.");
        }

        static void BinarySearchTimeMax(int[] data)
        {
            uint iterationsNumber = 10;
            long elapsedTime = 0;
            long minTime = long.MaxValue;
            long maxTime = long.MinValue;
            for (int n = 0; n < (iterationsNumber + 1 + 1); ++n)
            {
                long startingTime = Stopwatch.GetTimestamp();
                long endingTime = Stopwatch.GetTimestamp();
                long iterationElapsedTime = endingTime - startingTime;
                int number = data[data.Length - 1];

                if (BinarySearch(data, number))
                {
                    Console.WriteLine($"Złożoność maksymalna: element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
                        $"Czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")}");
                }
                else
                {
                    Console.WriteLine($"Złożoność maksymalna: element {number} nie został odnaleziony w zbiorze {data.Length}-elementowym. " +
                        $"Czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")}");
                }
                
                elapsedTime += iterationElapsedTime;
                if (iterationElapsedTime < minTime)
                {
                    minTime = iterationElapsedTime;
                }
                if (iterationElapsedTime > maxTime)
                {
                    maxTime = iterationElapsedTime;
                }
            }
            elapsedTime -= (minTime + maxTime);
            double elapsedSeconds = elapsedTime * (1.0 / (iterationsNumber * Stopwatch.Frequency));
            Console.WriteLine($"Złożoność maksymalna: liczba powtórzeń: {iterationsNumber}, średni czas przebiegu operacji: {elapsedSeconds.ToString("F10")} [s], zakładając odrzucenie czasów skrajnych.");
        }

        static void BinarySearchTimeAvg(int[] data)
        {
            uint iterationsNumber = 10;
            long elapsedTime = 0;
            long minTime = long.MaxValue;
            long maxTime = long.MinValue;

            for (int i = 0; i < data.Length; i++)
            {
                int number = data[i];
                for (int n = 0; n < (iterationsNumber + 1 + 1); ++n)
                {
                    long startingTime = Stopwatch.GetTimestamp();
                    long endingTime = Stopwatch.GetTimestamp();
                    long iterationElapsedTime = endingTime - startingTime;

                    if (BinarySearch(data, number))
                    {
                        Console.WriteLine($"Złożoność średnia (iteracja {iterationsNumber}): element {number} został odnaleziony w zbiorze: {data.Length}-elementowym, " +
                            $"średni czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]."); 
                    }
                    else
                    {
                        Console.WriteLine($"Złożoność średnia (iteracja {iterationsNumber}): element {number} został odnaleziony w zbiorze: {data.Length}-elementowym, " +
                            $"średni czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s].");
                    }
                    elapsedTime += iterationElapsedTime;
                    if (iterationElapsedTime < minTime)
                    {
                        minTime = iterationElapsedTime;
                    }
                    if (iterationElapsedTime > maxTime)
                    {
                        maxTime = iterationElapsedTime;
                    }
                }
            }
            elapsedTime -= (minTime + maxTime);
            double elapsedSeconds = elapsedTime * (1.0 / (iterationsNumber * Stopwatch.Frequency));
            Console.WriteLine($"Złożoność średnia: liczba powtórzeń: {iterationsNumber}, " +
                $"średni czas przebiegu operacji: {(elapsedSeconds / data.Length).ToString("F10")} [s], zakładając odrzucenie czasów skrajnych.");
        }

        static void Main(string[] args)
        {
            int[] data = new int[100] {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
                , 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
                , 21, 22, 23, 24, 25, 26, 27, 28, 29, 30
                , 31, 32, 33, 34, 35, 36, 37, 38, 39, 40
                , 41, 42, 43, 44, 45, 46, 47, 48, 49, 50
                , 51, 52, 53, 54, 55, 56, 57, 58, 59, 60
                , 61, 62, 63, 64, 65, 66, 67, 68, 69, 70
                , 71, 72, 73, 74, 75, 76, 77, 78, 79, 80
                , 81, 82, 83, 84, 85, 86, 87, 88, 89, 90
                , 91, 92, 93, 94 ,95, 96, 97, 98, 99, 100
            };

            Console.WriteLine("Implementacja algorytmu bez oceny złożoności dla przykładowej liczby 10.");
            int number = 10;
            BinarySearchImplementation(data, number);

            //BinarySearchMin(data);

            Console.WriteLine("\nImplementacja szacowania złożoności pesymistycznej za pomocą instrumentacji.");
            BinarySearchMax(data);

            Console.WriteLine("\nImplementacja szacowania złożoności średniej za pomocą instrumentacji.");
            BinarySearchAvg(data);

            //BinarySearchTimeMin(data);

            Console.WriteLine("\nImplementacja szacowania złożoności pesymistycznej za pomocą zliczania czasu wykonania.");
            BinarySearchTimeMax(data);

            Console.WriteLine("\nImplementacja szacowania złożoności średniej za pomocą zliczania czasu wykonania.");
            BinarySearchTimeAvg(data);
        }
    }
}
