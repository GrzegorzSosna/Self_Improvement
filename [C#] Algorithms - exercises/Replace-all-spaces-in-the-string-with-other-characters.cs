/* Zad. Napisz metodę, która zastępuje wszystkie spacje w łańcuchu znaków sekwencją %20. Przyjmij, że na
końcu łańcucha dostępne jest miejsce na dodatkowe znaki, a także, że znasz prawdziwą długość łańcucha.
Jeżeli implementujesz rozwiązanie w Javie, zastosuj tablicę znaków, aby móc wykonać operację w miejscu
(bez kopiowania łańcuchów) */

using System;

namespace ConsoleApp
{
    class Program
    {
        static void ModifiedText(string text)
        {
            int numberOfSpaces = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                    numberOfSpaces++;
            }

            int lengthModifiedText = text.Length + 2 * numberOfSpaces;

            char[] arrayText = new char[lengthModifiedText];
            for (int i = 0; i < text.Length; i++)
                arrayText[i] = text[i];

            for (int i = text.Length - 1; i >= 0; i--)
            {
                if (arrayText[i] == ' ')
                {
                    arrayText[--lengthModifiedText] = '0';
                    arrayText[--lengthModifiedText] = '2';
                    arrayText[--lengthModifiedText] = '%';
                }
                else
                    arrayText[--lengthModifiedText] = arrayText[i];
            }
            Console.WriteLine(arrayText);
        }

        static void Main(string[] args)
        {
            string text = "Ala ma kota";
            ModifiedText(text);
        }
    }
}
