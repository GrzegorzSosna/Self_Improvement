// Zad. Zaimplementuj metodę, która przeprowadza prostą kompresję łańcuchów znaków opartą na zliczaniu 
// powtarzających się liter. Np. metoda ma przekształcać łańcuch aabcccccaaa na a2b1c5a3. Jesli
// "skompresowany" łańcuch znaków nie jest mniejszy od wyjściowego, metoda powinna zwracać pierwotny
// łańcuch.

using System;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static String StrCompression(string strOfChar)
        {
            StringBuilder strResult = new StringBuilder();
            char strBufor = strOfChar[0];
            int count = 1;

            for (int i = 1; i <= strOfChar.Length - 1; i++)
            {
                if (strOfChar[i] == strBufor)
                    count++;
                else 
                {
                    strResult.Append(strBufor + count.ToString());                
                    count = 1;                 
                }
                if (i == (strOfChar.Length - 1))
                    strResult.Append(strOfChar[i] + count.ToString());

                strBufor = strOfChar[i];
            }
            if (strOfChar.Length <= strResult.Length)
                return strOfChar;
            else 
                return strResult.ToString();
        }

        static void Main(string[] args)
        {
            string strOfChar = "aaabnmmmm";
            Console.WriteLine("Przed kompresją : " + strOfChar);
            Console.WriteLine("Po kompresji : " + StrCompression(strOfChar));
        }
    }
}
