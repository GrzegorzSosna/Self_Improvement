// Zad. Zaimplementuj algorytm określający, czy dany łańcuch zawiera tylko niepowtarzające się znaki.
// Jak wykonasz to zadanie, jeśli nie można stosować dodatkowych struktur danych?

using System;

namespace ConsoleApp
{
    class Program
    {
        static bool IsUniqueChar(string word)
        {
            bool repeatedChar = false;
            for(int numberChar = 0; numberChar <= 255; numberChar++)
            {
                for(int i = 0; i <= word.Length - 1; i++)
                {
                    if (word[i] == (char)numberChar && repeatedChar == false)
                        repeatedChar = true;
                    else if (word[i] == (char)numberChar) 
                        repeatedChar = false;
                }
            }
             return repeatedChar;
        }
		
        static void Main(string[] args)
        {
                string word = "abcdefga";
                Console.WriteLine(IsUniqueChar(word));           
        }
    }
}
