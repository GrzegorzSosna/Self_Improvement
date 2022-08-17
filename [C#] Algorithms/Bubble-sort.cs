/* SORTOWANIE BĄBELKOWE - (ang. Bubble Sort) pierwszy element porównujemy z drugim. Jeżeli pierwszy jest niewiększy od drugiego to pozostaje na swoim 
miejscu. Jeżeli pierwszy jest większy, to zamieniamy go miejscami z drugim. Następnie porównujemy drugi element z trzecim, i stosujemy podobną zasadę
jak w poprzednim porównaniu. Nastepnie porównujemy trzeci z czwartym, czwarty z piątym itd. Aż do wyczerpania wszytskich elementów tablicy. Sortowanie 
kończy się, gdy podczas kolejnej iteracji nie dokonano żadnej zmiany. */

using System;

namespace ConsoleApp
{
    class Program
    {
        static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int buffor = array[j];
                        array[j] = array[i];
                        array[i] = buffor;
                    }
                }
            }
            return array;
        }

        static void Main(string[] args)
        {           
            int[] array = new int[10] { 3, 115, 74, 21, 45, 123, 2, 34, 85, 23 };
            int[] sortedArray = BubbleSort(array);

            Console.WriteLine("Tablica posortowana :");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(sortedArray[i]);
            }
        }
    }
}
