/* WYSZUKIWANIE BINARNE - (ang. Binary Search) algorytm opierający się na metodzie dziel i zwyciężaj, który w czasie logarytmicznym stwierdza, czy 
szukany element znajduje się w uporządkowanej tablicy i jeśli się znajduje, podaje jego indeks. */

using System;

namespace ConsoleApp
{
    class Program
    {		
        static void BinarySearch(int[] array, int searchedItem)
        {
            int lowerLimit = 0;
	    int upperLimit = array.Length - 1;
	    int iteration= 0;
			
	    while (lowerLimit <= upperLimit)
            {   
		++iteration;
		int binarySearch = (lowerLimit + upperLimit) / 2;			
				
		if (searchedItem < array[binarySearch])
			upperLimit = binarySearch - 1;
				
		if (searchedItem > array[binarySearch])					
			lowerLimit = binarySearch + 1;
				
		if (searchedItem == array[binarySearch])
		{
		    Console.WriteLine($"Ilość iteracji: {iteration}");
		    Console.WriteLine($"Indeks tablicy elementu {searchedItem} to {binarySearch}.");
		    return;
	        }
	    }
	    Console.WriteLine($"Ilość iteracji: {iteration}");
	    Console.WriteLine($"Nie znaleziono indeksu tablicy dla elementu {searchedItem}.");
	}   

	static void Main(string[] args)
	{           			
	    int[] array = new int[10] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };
	    int searchedItem = 256;
			
	    BinarySearch(array, searchedItem);
	}		
    }
}

