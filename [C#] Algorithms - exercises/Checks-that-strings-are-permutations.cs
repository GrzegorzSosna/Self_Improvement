/* Napisz metodę, która przyjmuje dwa łańcuchy znaków i określa, czy jeden jest permutacją drugiego.
Znajdź dwa różne rozwiązania tego zadania. */

using System;

namespace ConsoleApp
{
    class Program
    {
        // first method - by checking the number of characters
        static bool Permutation(string textOne, string textTwo)
        {
            if (textOne.Length != textTwo.Length)
                return false;

            for (int i = 0; i < textOne.Length; i++)
            {              
                int numberOfCharTextOne = 0;
                for (int q = 0; q < textOne.Length; q++)
                {
                    if (textOne[i] == textOne[q])
                        numberOfCharTextOne++;
                }
                int numberOfCharTextTwo = 0;
                for (int q = 0; q < textTwo.Length; q++)
                {
                    if (textOne[i] == textTwo[q])
                        numberOfCharTextTwo++;
                }
                if (numberOfCharTextOne != numberOfCharTextTwo)
                    return false;
            }
            return true;
        }

        // second method - by sorting characters and matching strings
        static bool SortingPermutation(string textOne, string textTwo)
        {
            if (textOne.Length != textTwo.Length)
                return false;

            char[] arrayTextOne = textOne.ToCharArray();
            char[] arrayTextTwo = textTwo.ToCharArray();
            Array.Sort(arrayTextOne);
            Array.Sort(arrayTextTwo);

            for (int i = 0; i < arrayTextOne.Length; i++)
            {
                if (arrayTextOne[i] != arrayTextTwo[i]) 
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            string textOne = "alo acb";
            string textTwo = "oal bac";

            if (Permutation(textOne, textTwo))
                Console.WriteLine("First method - these are permutations.");
            else
                Console.WriteLine("First method - these are not permutations.");

            if (SortingPermutation(textOne, textTwo))
                Console.WriteLine("Second method - these are permutations.");
            else
                Console.WriteLine("Second method - these are not permutations.");
        }
    }
}
