/* Zadanie wykonane w ramach przedmiotu "Algorytmy i struktury danych". 
Celem projektu jest zaproponowanie algorytmu określającego czy dana liczba jest liczbą pierwszą. Proszę 
przeprowadzić analizę za pomocą instrumentacjii pomiarów czasu, przyjmując, że operacją dominującą jest 
dzielenie modulo (%).
Badanie proszę przeprowadzić dla następującego zbioru punktów pomiarowych (liczb pierwszych):{ 100913, 1009139, 
10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 } 
Zadanie dodatkowe - Proszę zweryfikować za pomocą założonego algorytmu, modyfikując go odpowiednio w razie 
konieczności, czy liczba 18870929470561300001893 jest liczba pierwszą. */

using System;
using System.Diagnostics;
using System.Numerics;

namespace ConsoleApp
{
    class Program
    {
        private static ulong equalOperationCounter;

        static bool?[] SitoEratostenesa(UInt64 size)
        {
            equalOperationCounter = 0;
            bool?[] sieve = new bool?[size + 1];
            sieve[0] = null;
            sieve[1] = null;
            for (UInt64 i = 2; i <= size; i++)
            {
                sieve[i] = true;
            }
            for (UInt64 i = 2; i <= Math.Sqrt(size); i++)
            {
                equalOperationCounter++;
                if (sieve[i] == true)
                {
                    UInt64 multiple = i + i;
                    while (multiple <= size)
                    {
                        equalOperationCounter++;
                        sieve[multiple] = false;
                        multiple += i;
                    }
                }
            }
            return sieve;
        }

        static void SitoEratostenesaCzyLiczbaPierwsza(UInt64 number)
        {
            bool?[] sieve = SitoEratostenesa(number);
            if (sieve[number] == true)
            {
                Console.WriteLine($"Liczba {number} jest liczbą pierwszą.");
            }
            else
            {
                Console.WriteLine($"Liczba {number} nie jest liczbą pierwszą.");
            }
        }

        static void SitoEratostenesaInstrumentacja()
        {
            UInt64[] data = { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };

            for (int i = 0; i < data.Length; i++)
            {
                bool?[] sito = SitoEratostenesa(data[i]);
                Console.WriteLine($"\nInstrumentacja dla liczby: {data[i]}");
                if (sito[data[i]] == true)
                {
                    Console.WriteLine($"Liczba {data[i]} jest liczbą pierwszą.");
                    Console.WriteLine($"Ilość porównań: {equalOperationCounter}");
                }
                else
                {
                    Console.WriteLine($"Liczba {data[i]} nie jest liczbą pierwszą.");
                    Console.WriteLine($"Ilość porównań: {equalOperationCounter}");
                }
            }
        }

        static void SitoEratostenesaCzasWykonania()
        {
            double allElapsedSeconds = 0;
            UInt64[] data = { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };

            for (uint i = 0; i < data.Length; i++)
            {
                uint iterationsNumber = 10;
                long elapsedTime = 0;
                long minTime = long.MaxValue;
                long maxTime = long.MinValue;

                for (uint n = 0; n < (iterationsNumber + 1 + 1); ++n)
                {
                    long startingTime = Stopwatch.GetTimestamp();
                    bool?[] sieve = SitoEratostenesa(data[i]);
                    long endingTime = Stopwatch.GetTimestamp();
                    long iterationElapsedTime = endingTime - startingTime;

                    if (sieve[data[i]] == true)
                    {
                        Console.WriteLine($"Złożoność średnia ({n + 1} iteracja) - liczba {data[i]} jest liczbą pierwszą, średni czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]");
                    }
                    else
                    {
                        Console.WriteLine($"Złożoność średnia ({n + 1} iteracja) - liczba {data[i]} nie jest liczbą pierwszą, średni czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]");
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
                Console.WriteLine($"[Podsumowanie dla liczby: {data[i]}] Złożoność średnia - liczba powtórzeń: {iterationsNumber}, średni czas przebiegu operacji: {elapsedSeconds.ToString("F10")} [s]\n");
                allElapsedSeconds += elapsedSeconds;
            }
            Console.WriteLine($"[Podsumowanie dla wszystkich liczb w tablicy {data.Length} elementowej] Złożoność średnia - łączny czas przebiegu operacji: {allElapsedSeconds.ToString("F10")} [s], średni czas przebiegu operacji: {(allElapsedSeconds / data.Length).ToString("F10")} [s]");
        }

        static bool BigInt(BigInteger number)
        {
            equalOperationCounter = 0;       
            if (number <= 1)
                return false;
            if (number <= 3)
                return true;
            if (number % 2 == 0)
                return false;

            for (UInt64 i = 3; i < Math.Sqrt((double)number); i += 2)
            {
                equalOperationCounter++;
                if (number % i == 0)
                {
                    return false;
                }                 
            }
            return true;
        }
        
        static void BigIntCzyLiczbaPierwsza(BigInteger number)
        {
            if (BigInt(number) == true)
            {
                Console.WriteLine($"Liczba {number} jest liczbą pierwszą.");
                Console.WriteLine($"Ilość porównań: {equalOperationCounter}");
            }
            else
            {
                Console.WriteLine($"Liczba {number} nie jest liczbą pierwszą.");
                Console.WriteLine($"Ilość porównań: {equalOperationCounter}");
            }
        }

       
        static void Main(string[] args)
        {
            Console.WriteLine($"(1) Sito Eratostenesa - algorytm sprawadzający czy liczba jest liczbą pierwszą np. 2467\n");
            SitoEratostenesaCzyLiczbaPierwsza(2467);

            Console.WriteLine($"\n\n(2) Instrumentacja:");
            SitoEratostenesaInstrumentacja();

            Console.WriteLine($"\n\n(3) Zliczanie czasu wykonania:\n");
            SitoEratostenesaCzasWykonania();

            // Zadanie dodatkowe -> BigInteger
            Console.WriteLine($"\n\n(4) Sprawdzanie czy liczba 18870929470561300001893 jest liczbą pierwszą:\n");
            BigInteger sizeBigInt = BigInteger.Parse("18870929470561300001893"); 
            BigIntCzyLiczbaPierwsza(sizeBigInt);
        }
    }
}
