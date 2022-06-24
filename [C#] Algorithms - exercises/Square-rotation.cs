/* Zad. Dany jest rysunek reprezentowany przez macierz o wymiarach NxN, w którym każdy piksel jest 
reprezentowany za pomocą czterech bajtów. Napisz metodę, która rotuje rysunek o 90 stopni. Czy potrafisz
wykonać tę operację w miejscu? */

using System;

namespace ConsoleApp
{
    class Program
    {
        static int[,] RotateSquare(int[,] square, int squareSize)
        {
            int bufor;
            int layer = squareSize / 2;
            if (layer % 2 != 0)
                layer++;
            int last = squareSize - 1;
            // I implemented the square rotation in such a way that I copied the top edge to the buffer, then the left edge to the top, 
            // bottom to left, etc. I start copying from the outermost layer and go to the inside.
            for (int first = 0; first < layer; first++)
            {
                for (int q = first; q < last - first; q++)
                {
                    bufor = square[first, last - q];
                    // up = left
                    square[first, last - q] = square[q, first];
                    // left = down
                    square[q, first] = square[last - first, q];
                    // down = right
                    square[last - first, q] = square[last - q, last - first];
                    // right = up
                    square[last - q, last - first] = bufor;
                }
            }
            return square;
        }

        static void Main(string[] args)
        {         
            int squereSize = 6; // figure size e.g .: 2 is 2x2 or 6 is 6x6
            int[,] square = new int[squereSize, squereSize];

            for (int i = 0; i < squereSize; i++)
            {
                for (int q = 0; q <squereSize; q++)
                {
                    square[i, q] = i;
                }          
            }

            while (true)
            {
                Console.Clear();
                square = RotateSquare(square, squereSize);
                for (int i = 0; i < squereSize; i++)
                {
                    for (int q = 0; q < squereSize; q++)
                    {
                        Console.Write(square[i, q]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\nPress the key to rotate the square 90 degrees.");
                Console.ReadKey();
            }
        }
    }
}
