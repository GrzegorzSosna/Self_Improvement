// Zad. Zaimplementuj algorytm określający, czy dany łańcuch zawiera tylko niepowtarzające się znaki.
// Jak wykonasz to zadanie, jeśli nie można stosować dodatkowych struktur danych?

using System;

namespace ConsoleApp
{
    class Program
    {
        static bool IsUniqueChar(string strOfChar)
        {
            bool repeatedChar = true;
            for(int numberChar = 0; numberChar <= 255; numberChar++)
            {
                repeatedChar = true;
                for (int i = 0; i <= strOfChar.Length - 1; i++)
                {
                    if (strOfChar[i] == (char)numberChar && repeatedChar == false)
                        return repeatedChar;
                    if (strOfChar[i] == (char)numberChar && repeatedChar == true)
                        repeatedChar = false;                    
                }
            }
            return repeatedChar;
        }

        static void Main(string[] args)
        {
            string strOfChar = "abcdefgah";
            if (IsUniqueChar(strOfChar))
                Console.WriteLine("Litery się nie powtarzają.");
            else
                Console.WriteLine("Litery się powtarzają.");
        }
    }
}
