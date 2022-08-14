/* Zasada działania tego algorytmu jest często porównywana do porządkowania kart w wachlarz podczas gry. Każdą 
kartę wstawiamy w odpowiednie miejsce, tzn. po młodszej, ale przed starszą. 
Podobnie jest z liczbami.
Pierwszy element pozostaje na swoim miejscu. Następnie bierzemy drugi i sprawdzamy, w jakiej relacji jest on z 
pierwszym. Jeśli jest niemniejszy, to zostaje na drugim miejscu, w przeciwnym wypadku wędruje na pierwsze miejsce. 
Dalej sprawdzamy trzeci element (porównujemy go do dwóch pierwszych i wstawiamy w odpowiednie miejsce) itd. 
Idea działania algorytmu opiera się na podziale ciągu na dwie części: pierwsza jest posortowana, druga jeszcze nie. 
Wybieramy kolejną liczbę z drugiej części i wstawiamy ją do pierwszej. Ponieważ jest ona posortowana, to szukamy 
dla naszej liczby takiego miejsca, aby liczba na lewo była niewiększa a liczba na prawo niemniejsza. */

using System;

namespace ConsoleApp
{
    class Program
    {		
	static int[] InsertionSort(int[] array)
	{
	    for (int i = 0; i < array.Length; i++)
	    {					
		for (int j = i; j > 0; j--)
		{
		    if (array[j - 1] > array[j])
		    {
			int buffor = array[j];
			array[j] = array[j - 1];
			array[j - 1] = buffor;
		    }
		    else break;
		}
	    }
	    return array;
	}

        static void Main(string[] args)
        {           			
	    int[] array = new int[10] { 3, 115, 74, 21, 45, 123, 2, 34, 85, 23 };
	    int[] sortedArray = InsertionSort(array);

	    Console.WriteLine("Tablica posortowana :");
	    for (int i = 0; i < 10; i++)
	    {
		Console.WriteLine(sortedArray[i]);
	    }
        }		
    }
}
