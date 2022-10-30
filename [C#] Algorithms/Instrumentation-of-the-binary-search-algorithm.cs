/* Zadanie wykonane w ramach przedmiotu "Algorytmy i struktury danych". 
Proszę zweryfikować przedstawioną ocenę średniej i pesymistycznej złożoności wyszukiwania liniowego 
lub binarnego. W szczególności, proszę przeprowadzić analizę za pomocą instrumentacji i pomiarów czasu. 
W porównaniu proszę wykorzystać tablice liczb całkowitych o rozmiarze rzędu 2^30 bajtów (2^28 elementów typu uint/int). */

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

        static void BinarySearchImplementation(int number)
        {
            int[] data = new int[250] {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
                , 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
                , 21, 22, 23, 24, 25, 26, 27, 28, 29, 30
                , 31, 32, 33, 34, 35, 36, 37, 38, 39, 40
                , 41, 42, 43, 44, 45, 46, 47, 48, 49, 50
                , 51, 52, 53, 54, 55, 56, 57, 58, 59, 60
                , 61, 62, 63, 64, 65, 66, 67, 68, 69, 70
                , 71, 72, 73, 74, 75, 76, 77, 78, 79, 80
                , 81, 82, 83, 84, 85, 86, 87, 88, 89, 90
                , 91, 92, 93, 94, 95, 96, 97, 98, 99, 100
                , 101, 102, 103, 104, 105, 106, 107, 108, 109, 110
                , 111, 112, 113, 114, 115, 116, 117, 118, 119, 120
                , 121, 122, 123, 124, 125, 126, 127, 128, 129, 130
                , 131, 132, 133, 134, 135, 136, 137, 138, 139, 140
                , 141, 142, 143, 144, 145, 146, 147, 148, 149, 150
                , 151, 152, 153, 154, 155, 156, 157, 158, 159, 160
                , 161, 162, 163, 164, 165, 166, 167, 168, 169, 170
                , 171, 172, 173, 174, 175, 176, 177, 178, 179, 180
                , 181, 182, 183, 184, 185, 186, 187, 188, 189, 190
                , 191, 192, 193, 194, 195, 196, 197, 198, 199, 200
                , 201, 202, 203, 204, 205, 206, 207, 208, 209, 210
                , 211, 212, 213, 214, 215, 216, 217, 218, 219, 220
                , 221, 222, 223, 224, 225, 226, 227, 228, 229, 230
                , 231, 232, 233, 234, 235, 236, 237, 238, 239, 240
                , 241, 242, 243, 244, 245, 246, 247, 248, 249, 250};

            if (BinarySearch(data, number))
            {
                Console.WriteLine($"Element {number} znajduje się w zbiorze liczb od 1 do {data.Length}.");
            }
            else
            {
                Console.WriteLine($"Element {number} nie znajduje się w zbiorze liczb od 1 do {data.Length}.");
            }
        }

        static void BinarySearchMin()
        {
            equalOperationCounter = 0;
            int[] data = new int[250] {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
                , 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
                , 21, 22, 23, 24, 25, 26, 27, 28, 29, 30
                , 31, 32, 33, 34, 35, 36, 37, 38, 39, 40
                , 41, 42, 43, 44, 45, 46, 47, 48, 49, 50
                , 51, 52, 53, 54, 55, 56, 57, 58, 59, 60
                , 61, 62, 63, 64, 65, 66, 67, 68, 69, 70
                , 71, 72, 73, 74, 75, 76, 77, 78, 79, 80
                , 81, 82, 83, 84, 85, 86, 87, 88, 89, 90
                , 91, 92, 93, 94, 95, 96, 97, 98, 99, 100
                , 101, 102, 103, 104, 105, 106, 107, 108, 109, 110
                , 111, 112, 113, 114, 115, 116, 117, 118, 119, 120
                , 121, 122, 123, 124, 125, 126, 127, 128, 129, 130
                , 131, 132, 133, 134, 135, 136, 137, 138, 139, 140
                , 141, 142, 143, 144, 145, 146, 147, 148, 149, 150
                , 151, 152, 153, 154, 155, 156, 157, 158, 159, 160
                , 161, 162, 163, 164, 165, 166, 167, 168, 169, 170
                , 171, 172, 173, 174, 175, 176, 177, 178, 179, 180
                , 181, 182, 183, 184, 185, 186, 187, 188, 189, 190
                , 191, 192, 193, 194, 195, 196, 197, 198, 199, 200
                , 201, 202, 203, 204, 205, 206, 207, 208, 209, 210
                , 211, 212, 213, 214, 215, 216, 217, 218, 219, 220
                , 221, 222, 223, 224, 225, 226, 227, 228, 229, 230
                , 231, 232, 233, 234, 235, 236, 237, 238, 239, 240
                , 241, 242, 243, 244, 245, 246, 247, 248, 249, 250};
            /*int[] data = new int[1048576];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i + 1;
            }*/
            int number = data[(data.Length - 1) / 2];

            if (BinarySearch(data, number))
            {
                Console.WriteLine($"Złożoność minimalna - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. Liczba operacji porównania: {equalOperationCounter}");
            }
            else
            {
                Console.WriteLine($"Złożoność minimalna - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. Liczba operacji porównania: {equalOperationCounter}");
            }
        }

        static void BinarySearchMax()
        {
            equalOperationCounter = 0;
            int[] data = new int[250] {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
                , 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
                , 21, 22, 23, 24, 25, 26, 27, 28, 29, 30
                , 31, 32, 33, 34, 35, 36, 37, 38, 39, 40
                , 41, 42, 43, 44, 45, 46, 47, 48, 49, 50
                , 51, 52, 53, 54, 55, 56, 57, 58, 59, 60
                , 61, 62, 63, 64, 65, 66, 67, 68, 69, 70
                , 71, 72, 73, 74, 75, 76, 77, 78, 79, 80
                , 81, 82, 83, 84, 85, 86, 87, 88, 89, 90
                , 91, 92, 93, 94, 95, 96, 97, 98, 99, 100
                , 101, 102, 103, 104, 105, 106, 107, 108, 109, 110
                , 111, 112, 113, 114, 115, 116, 117, 118, 119, 120
                , 121, 122, 123, 124, 125, 126, 127, 128, 129, 130
                , 131, 132, 133, 134, 135, 136, 137, 138, 139, 140
                , 141, 142, 143, 144, 145, 146, 147, 148, 149, 150
                , 151, 152, 153, 154, 155, 156, 157, 158, 159, 160
                , 161, 162, 163, 164, 165, 166, 167, 168, 169, 170
                , 171, 172, 173, 174, 175, 176, 177, 178, 179, 180
                , 181, 182, 183, 184, 185, 186, 187, 188, 189, 190
                , 191, 192, 193, 194, 195, 196, 197, 198, 199, 200
                , 201, 202, 203, 204, 205, 206, 207, 208, 209, 210
                , 211, 212, 213, 214, 215, 216, 217, 218, 219, 220
                , 221, 222, 223, 224, 225, 226, 227, 228, 229, 230
                , 231, 232, 233, 234, 235, 236, 237, 238, 239, 240
                , 241, 242, 243, 244, 245, 246, 247, 248, 249, 250};
            /*int[] data = new int[1048576];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i + 1;
            }*/
            int number = data[data.Length - 1];

            if (BinarySearch(data, number))
            {
                Console.WriteLine($"Złożoność maksymalna - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. Liczba operacji porównania: {equalOperationCounter}");
            }
            else
            {
                Console.WriteLine($"Złożoność maksymalna - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. Liczba operacji porównania: {equalOperationCounter}");
            }
        }

        static void BinarySearchAvg()
        {
            ulong totalOperationsCounter = 0;
            int[] data = new int[250] {
                 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
                 , 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
                 , 21, 22, 23, 24, 25, 26, 27, 28, 29, 30
                 , 31, 32, 33, 34, 35, 36, 37, 38, 39, 40
                 , 41, 42, 43, 44, 45, 46, 47, 48, 49, 50
                 , 51, 52, 53, 54, 55, 56, 57, 58, 59, 60
                 , 61, 62, 63, 64, 65, 66, 67, 68, 69, 70
                 , 71, 72, 73, 74, 75, 76, 77, 78, 79, 80
                 , 81, 82, 83, 84, 85, 86, 87, 88, 89, 90
                 , 91, 92, 93, 94, 95, 96, 97, 98, 99, 100
                 , 101, 102, 103, 104, 105, 106, 107, 108, 109, 110
                 , 111, 112, 113, 114, 115, 116, 117, 118, 119, 120
                 , 121, 122, 123, 124, 125, 126, 127, 128, 129, 130
                 , 131, 132, 133, 134, 135, 136, 137, 138, 139, 140
                 , 141, 142, 143, 144, 145, 146, 147, 148, 149, 150
                 , 151, 152, 153, 154, 155, 156, 157, 158, 159, 160
                 , 161, 162, 163, 164, 165, 166, 167, 168, 169, 170
                 , 171, 172, 173, 174, 175, 176, 177, 178, 179, 180
                 , 181, 182, 183, 184, 185, 186, 187, 188, 189, 190
                 , 191, 192, 193, 194, 195, 196, 197, 198, 199, 200
                 , 201, 202, 203, 204, 205, 206, 207, 208, 209, 210
                 , 211, 212, 213, 214, 215, 216, 217, 218, 219, 220
                 , 221, 222, 223, 224, 225, 226, 227, 228, 229, 230
                 , 231, 232, 233, 234, 235, 236, 237, 238, 239, 240
                 , 241, 242, 243, 244, 245, 246, 247, 248, 249, 250};
            /*int[] data = new int[1048576];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i + 1;
            }*/

            for (int i = 0; i < data.Length; i++)
            {
                equalOperationCounter = 0;
                int number = data[i];
                if (BinarySearch(data, number))
                {
                    Console.WriteLine($"Złożoność średnia - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. Liczba operacji porównania: {equalOperationCounter}");
                }
                else
                {
                    Console.WriteLine($"Złożoność średnia - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. Liczba operacji porównania: {equalOperationCounter}");
                }
                totalOperationsCounter += equalOperationCounter;
            }
            Console.WriteLine($"[Podsumowanie] Złożoność średnia - łączna liczba operacji porównania: {totalOperationsCounter}, liczba iteracji: {data.Length}, średnia operacji porównania: {totalOperationsCounter / (ulong)data.Length}");
        }

        static void BinarySearchTimeMin()
        {
            uint iterationsNumber = 10;
            long elapsedTime = 0;
            long minTime = long.MaxValue;
            long maxTime = long.MinValue;
            for (int n = 0; n < (iterationsNumber + 1 + 1); ++n)
            {
                long startingTime = Stopwatch.GetTimestamp();
                int[] data = new int[250] {
                 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
                 , 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
                 , 21, 22, 23, 24, 25, 26, 27, 28, 29, 30
                 , 31, 32, 33, 34, 35, 36, 37, 38, 39, 40
                 , 41, 42, 43, 44, 45, 46, 47, 48, 49, 50
                 , 51, 52, 53, 54, 55, 56, 57, 58, 59, 60
                 , 61, 62, 63, 64, 65, 66, 67, 68, 69, 70
                 , 71, 72, 73, 74, 75, 76, 77, 78, 79, 80
                 , 81, 82, 83, 84, 85, 86, 87, 88, 89, 90
                 , 91, 92, 93, 94, 95, 96, 97, 98, 99, 100
                 , 101, 102, 103, 104, 105, 106, 107, 108, 109, 110
                 , 111, 112, 113, 114, 115, 116, 117, 118, 119, 120
                 , 121, 122, 123, 124, 125, 126, 127, 128, 129, 130
                 , 131, 132, 133, 134, 135, 136, 137, 138, 139, 140
                 , 141, 142, 143, 144, 145, 146, 147, 148, 149, 150
                 , 151, 152, 153, 154, 155, 156, 157, 158, 159, 160
                 , 161, 162, 163, 164, 165, 166, 167, 168, 169, 170
                 , 171, 172, 173, 174, 175, 176, 177, 178, 179, 180
                 , 181, 182, 183, 184, 185, 186, 187, 188, 189, 190
                 , 191, 192, 193, 194, 195, 196, 197, 198, 199, 200
                 , 201, 202, 203, 204, 205, 206, 207, 208, 209, 210
                 , 211, 212, 213, 214, 215, 216, 217, 218, 219, 220
                 , 221, 222, 223, 224, 225, 226, 227, 228, 229, 230
                 , 231, 232, 233, 234, 235, 236, 237, 238, 239, 240
                 , 241, 242, 243, 244, 245, 246, 247, 248, 249, 250};
                int number = data[(data.Length - 1) / 2];
                bool BinarySearchResult = BinarySearch(data, number);
                long endingTime = Stopwatch.GetTimestamp();
                long iterationElapsedTime = endingTime - startingTime;

                if (BinarySearchResult)
                {
                    Console.WriteLine($"Złożoność minimalna - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. Czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")}");
                }
                else
                {
                    Console.WriteLine($"Złożoność minimalna - element {number} nie został odnaleziony w zbiorze {data.Length}-elementowym. Czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")}");
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

        static void BinarySearchTimeMax()
        {
            uint iterationsNumber = 10;
            long elapsedTime = 0;
            long minTime = long.MaxValue;
            long maxTime = long.MinValue;
            for (int n = 0; n < (iterationsNumber + 1 + 1); ++n)
            {
                long startingTime = Stopwatch.GetTimestamp();
                int[] data = new int[250] {
                 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
                 , 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
                 , 21, 22, 23, 24, 25, 26, 27, 28, 29, 30
                 , 31, 32, 33, 34, 35, 36, 37, 38, 39, 40
                 , 41, 42, 43, 44, 45, 46, 47, 48, 49, 50
                 , 51, 52, 53, 54, 55, 56, 57, 58, 59, 60
                 , 61, 62, 63, 64, 65, 66, 67, 68, 69, 70
                 , 71, 72, 73, 74, 75, 76, 77, 78, 79, 80
                 , 81, 82, 83, 84, 85, 86, 87, 88, 89, 90
                 , 91, 92, 93, 94, 95, 96, 97, 98, 99, 100
                 , 101, 102, 103, 104, 105, 106, 107, 108, 109, 110
                 , 111, 112, 113, 114, 115, 116, 117, 118, 119, 120
                 , 121, 122, 123, 124, 125, 126, 127, 128, 129, 130
                 , 131, 132, 133, 134, 135, 136, 137, 138, 139, 140
                 , 141, 142, 143, 144, 145, 146, 147, 148, 149, 150
                 , 151, 152, 153, 154, 155, 156, 157, 158, 159, 160
                 , 161, 162, 163, 164, 165, 166, 167, 168, 169, 170
                 , 171, 172, 173, 174, 175, 176, 177, 178, 179, 180
                 , 181, 182, 183, 184, 185, 186, 187, 188, 189, 190
                 , 191, 192, 193, 194, 195, 196, 197, 198, 199, 200
                 , 201, 202, 203, 204, 205, 206, 207, 208, 209, 210
                 , 211, 212, 213, 214, 215, 216, 217, 218, 219, 220
                 , 221, 222, 223, 224, 225, 226, 227, 228, 229, 230
                 , 231, 232, 233, 234, 235, 236, 237, 238, 239, 240
                 , 241, 242, 243, 244, 245, 246, 247, 248, 249, 250};
                /*int[] data = new int[1048576];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = i + 1;
                }*/
                int number = data[data.Length - 1];
                bool BinarySearchResult = BinarySearch(data, number);
                long endingTime = Stopwatch.GetTimestamp();
                long iterationElapsedTime = endingTime - startingTime;

                if (BinarySearchResult)
                {
                    Console.WriteLine($"Złożoność maksymalna - element {number} został odnaleziony w zbiorze {data.Length}-elementowym. Czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]");
                }
                else
                {
                    Console.WriteLine($"Złożoność maksymalna - element {number} nie został odnaleziony w zbiorze {data.Length}-elementowym. Czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]");
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
            Console.WriteLine($"[Podsumowanie] Złożoność maksymalna - liczba powtórzeń: {iterationsNumber}, średni czas przebiegu operacji: {elapsedSeconds.ToString("F10")} [s] - zakładając odrzucenie czasów skrajnych.");
        }

        static void BinarySearchTimeAvg()
        {
            double allElapsedSeconds = 0;
            int[] data = new int[250] {
                 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
                 , 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
                 , 21, 22, 23, 24, 25, 26, 27, 28, 29, 30
                 , 31, 32, 33, 34, 35, 36, 37, 38, 39, 40
                 , 41, 42, 43, 44, 45, 46, 47, 48, 49, 50
                 , 51, 52, 53, 54, 55, 56, 57, 58, 59, 60
                 , 61, 62, 63, 64, 65, 66, 67, 68, 69, 70
                 , 71, 72, 73, 74, 75, 76, 77, 78, 79, 80
                 , 81, 82, 83, 84, 85, 86, 87, 88, 89, 90
                 , 91, 92, 93, 94, 95, 96, 97, 98, 99, 100
                 , 101, 102, 103, 104, 105, 106, 107, 108, 109, 110
                 , 111, 112, 113, 114, 115, 116, 117, 118, 119, 120
                 , 121, 122, 123, 124, 125, 126, 127, 128, 129, 130
                 , 131, 132, 133, 134, 135, 136, 137, 138, 139, 140
                 , 141, 142, 143, 144, 145, 146, 147, 148, 149, 150
                 , 151, 152, 153, 154, 155, 156, 157, 158, 159, 160
                 , 161, 162, 163, 164, 165, 166, 167, 168, 169, 170
                 , 171, 172, 173, 174, 175, 176, 177, 178, 179, 180
                 , 181, 182, 183, 184, 185, 186, 187, 188, 189, 190
                 , 191, 192, 193, 194, 195, 196, 197, 198, 199, 200
                 , 201, 202, 203, 204, 205, 206, 207, 208, 209, 210
                 , 211, 212, 213, 214, 215, 216, 217, 218, 219, 220
                 , 221, 222, 223, 224, 225, 226, 227, 228, 229, 230
                 , 231, 232, 233, 234, 235, 236, 237, 238, 239, 240
                 , 241, 242, 243, 244, 245, 246, 247, 248, 249, 250};
            /*int[] data = new int[1048576];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i + 1;
            }*/

            for (int i = 0; i < data.Length; i++)
            {
                uint iterationsNumber = 10;
                long elapsedTime = 0;
                long minTime = long.MaxValue;
                long maxTime = long.MinValue;

                int number = data[i];
                for (int n = 0; n < (iterationsNumber + 1 + 1); ++n)
                {
                    long startingTime = Stopwatch.GetTimestamp();
                    bool BinarySearchResult = BinarySearch(data, number);
                    long endingTime = Stopwatch.GetTimestamp();
                    long iterationElapsedTime = endingTime - startingTime;

                    if (BinarySearchResult)
                    {
                        Console.WriteLine($"Złożoność średnia ({n + 1} iteracja) - element {number} został odnaleziony w zbiorze: {data.Length}-elementowym, średni czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]");
                    }
                    else
                    {
                        Console.WriteLine($"Złożoność średnia ({n + 1} iteracja) - element {number} został odnaleziony w zbiorze: {data.Length}-elementowym, średni czas operacji: {(iterationElapsedTime * (1.0 / Stopwatch.Frequency)).ToString("F10")} [s]");
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
                Console.WriteLine($"[Podsumowanie dla elementu: {number}] Złożoność średnia - liczba powtórzeń: {iterationsNumber}, średni czas przebiegu operacji: {elapsedSeconds.ToString("F10")} [s]");
                allElapsedSeconds += elapsedSeconds;
            }
            Console.WriteLine($"[Podsumowanie dla wszystkich elementów zbioru] Złożoność średnia - łączny czas przebiegu operacji: {allElapsedSeconds.ToString("F10")} [s], średni czas przebiegu operacji: {(allElapsedSeconds / data.Length).ToString("F10")} [s]");
        }

        static void Main(string[] args)
        {
            int number = 150;
            Console.WriteLine($"Implementacja algorytmu bez oceny złożoności dla przykładowej liczby {number}.");
            BinarySearchImplementation(number);

            //BinarySearchMin();

            Console.WriteLine("\nImplementacja szacowania złożoności pesymistycznej za pomocą instrumentacji.");
            BinarySearchMax();

            Console.WriteLine("\nImplementacja szacowania złożoności średniej za pomocą instrumentacji.");
            BinarySearchAvg();

            //BinarySearchTimeMin();

            Console.WriteLine("\nImplementacja szacowania złożoności pesymistycznej za pomocą zliczania czasu wykonania.");
            BinarySearchTimeMax();

            Console.WriteLine("\nImplementacja szacowania złożoności średniej za pomocą zliczania czasu wykonania (z iteracji odrzucamy czasy skrajne).");
            BinarySearchTimeAvg();
        }
    }
}
