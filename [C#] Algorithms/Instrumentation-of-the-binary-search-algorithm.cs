/* Zadanie wykonane w ramach przedmiotu "Algorytmy i struktury danych". 
Proszę zweryfikować przedstawioną ocenę średniej i pesymistycznej złożoności wyszukiwania liniowego (10 pkt) 
lub binarnego (20pkt). W szczególności, proszę przeprowadzić analizę za pomocą instrumentacji i pomiarów czasu. 
W porównaniu proszę wykorzystać tablice liczb całkowitych o rozmiarze rzędu 2^30 bajtów (2^28 elementów typu 
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
            int lowerLimit = 0;
            int upperLimit = vector.Length - 1;
            int middleElement = 0;

            while (lowerLimit <= upperLimit)
            {
                equalOperationCounter++;
                middleElement = (lowerLimit + upperLimit) / 2;
                if (number < vector[middleElement])
                    upperLimit = middleElement - 1;
                if (number > vector[middleElement])
                    lowerLimit = middleElement + 1;
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
                Console.WriteLine($"Element {number} znajduje się w zbiorze liczb od 1 do {data.Length}.");
            }
            else
            {
                Console.WriteLine($"Element {number} nie znajduje się w zbiorze liczb od 1 do {data.Length}.");
            }
        }

        static void BinarySearchMin(int[] data)
        {
            equalOperationCounter = 0;
            int number = data[(data.Length - 1) / 2];
            if (BinarySearch(data, number))
            {
                Console.WriteLine($"Złożoność minimalna - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
                    $"Liczba operacji porównania: {equalOperationCounter}");
            }
            else
            {
                Console.WriteLine($"Złożoność minimalna - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
                    $"Liczba operacji porównania: {equalOperationCounter}");
            }
        }

        static void BinarySearchMax(int[] data)
        {
            equalOperationCounter = 0;
            int number = data[data.Length - 1];
            if (BinarySearch(data, number))
            {
                Console.WriteLine($"Złożoność maksymalna - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
                    $"Liczba operacji porównania: {equalOperationCounter}");
            }
            else
            {
                Console.WriteLine($"Złożoność maksymalna - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
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
                    Console.WriteLine($"Złożoność średnia - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
                        $"Liczba operacji porównania: {equalOperationCounter}");
                }
                else
                {
                    Console.WriteLine($"Złożoność średnia - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
                        $"Liczba operacji porównania: {equalOperationCounter}");
                }
                totalOperationsCounter += equalOperationCounter;
            }
            Console.WriteLine($"[Podsumowanie] Złożoność średnia - łączna liczba operacji porównania: {totalOperationsCounter}, " +
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
                    Console.WriteLine($"Złożoność minimalna - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
                        $"Czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")}");
                }
                else
                {
                    Console.WriteLine($"Złożoność minimalna - element {number} nie został odnaleziony w zbiorze {data.Length}-elementowym. " +
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
            Console.WriteLine($"[Podsumowanie] Złożoność minimalna - liczba powtórzeń: {iterationsNumber}, średni czas przebiegu operacji: {elapsedSeconds.ToString("F10")} [s], zakładając odrzucenie czasów skrajnych.");
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
                    Console.WriteLine($"Złożoność maksymalna - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. " +
                        $"Czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]");
                }
                else
                {
                    Console.WriteLine($"Złożoność maksymalna - element {number} nie został odnaleziony w zbiorze {data.Length}-elementowym. " +
                        $"Czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]");
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
            Console.WriteLine($"[Podsumowanie] Złożoność maksymalna - liczba powtórzeń: {iterationsNumber}, " +
                $"średni czas przebiegu operacji: {elapsedSeconds.ToString("F10")} [s] - zakładając odrzucenie czasów skrajnych.");
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
                        Console.WriteLine($"Złożoność średnia ({iterationsNumber} iteracji) - element {number} został odnaleziony w zbiorze: {data.Length}-elementowym, " +
                            $"średni czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]"); 
                    }
                    else
                    {
                        Console.WriteLine($"Złożoność średnia ({iterationsNumber} iteracji) - element {number} został odnaleziony w zbiorze: {data.Length}-elementowym, " +
                            $"średni czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]");
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
            Console.WriteLine($"[Podsumowanie] Złożoność średnia - liczba powtórzeń: {iterationsNumber}, " +
                $"średni czas przebiegu operacji: {(elapsedSeconds / data.Length).ToString("F10")} [s] - zakładając odrzucenie czasów skrajnych.");
        }

        static void Main(string[] args)
        {
            int[] data = new int[100];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i + 1;
            }
      
            int number = 1000;
            Console.WriteLine($"Implementacja algorytmu bez oceny złożoności dla przykładowej liczby {number}.");
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
