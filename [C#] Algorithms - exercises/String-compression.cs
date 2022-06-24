/* Zad. Zaimplementuj metodę, która przeprowadza prostą kompresję łańcuchów znaków opartą na zliczaniu powtarzających się liter. 
Np. metoda ma przekształcać łańcuch aabcccccaaa na a2b1c5a3. Jeśli"skompresowany" łańcuch znaków nie jest mniejszy od wyjściowego, 
metoda powinna zwracać pierwotny łańcuch. */

using System;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static String StrCompression(string strOfChar)
        {
            StringBuilder strResult = new StringBuilder();
            int count = 1;

            for (int i = 1; i < strOfChar.Length; i++)
            {
                if (strOfChar[i] == strOfChar[i - 1])
                    count++;
                else
                {
                    strResult.Append(strOfChar[i - 1] + count.ToString());
                    count = 1;
                }
                if (i == (strOfChar.Length - 1))
                    strResult.Append(strOfChar[i] + count.ToString());
            }
		
            if (strOfChar.Length <= strResult.Length)
                return strOfChar;
            else
                return strResult.ToString();
        }

        static void Main(string[] args)
        {
            string strOfChar = "abcdddddd";
            Console.WriteLine("Przed kompresją : " + strOfChar);
            Console.WriteLine("Po kompresji : " + StrCompression(strOfChar));
        }
    }
}
