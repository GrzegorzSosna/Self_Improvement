/* Zad. Napisz kod, który przyjmuje dodatnią liczbę całkowitą i wyświetla najbliższą mniejszą i większą wartość
o tej samej liczbie jedynek w reprezentacji binarnej. */
using System;

namespace ConsoleApp
{
	class Program
	{
		static string BinaryNumber(double number, int numberOfBits)
		{
			string binaryNumber = null;
			for (int i = numberOfBits - 1; i >= 0; i--)
			{
				if (number / Math.Pow(2, i) >= 1)
				{
					binaryNumber += "1";
					number -= Math.Pow(2, i);
				}
				else
					binaryNumber += "0";
			}
			return binaryNumber;
		}

		static int NumberOfOnes(double number, int numberOfBits)
        {
			int numberOfOnes = 0;
			for (int i = numberOfBits - 1; i >= 0; i--)
			{
				if (number / Math.Pow(2, i) >= 1)
				{
					numberOfOnes++;
					number -= Math.Pow(2, i);
				}
			}		
			return numberOfOnes;
		}

		static void TheSameNumberOfOnes(double number, int numberOfBits)
        {
			int numberOfOnes = NumberOfOnes(number, numberOfBits);
			bool isItBigger = true, isItSmaller = true;
			int numberOfOnesBigger = 0, numberOfOnesSmaller = 0;
			string binaryNumberBigger = null, binaryNumberSmaller = null;

			double numberTemp = number; 
			while (numberOfOnes != numberOfOnesBigger)
            {
				numberTemp++;
				if (numberTemp > Math.Pow(2, numberOfBits - 1))
                {
					isItBigger = false;
					break;
				}				
				binaryNumberBigger = BinaryNumber(numberTemp, numberOfBits);
				numberOfOnesBigger = NumberOfOnes(numberTemp, numberOfBits);
			}

			numberTemp = number;
			while (numberOfOnes != numberOfOnesSmaller)
			{
				numberTemp--;
				if (numberTemp < 0)
                {
					isItSmaller = false;
					break;
				}					
				binaryNumberSmaller = BinaryNumber(numberTemp, numberOfBits);
				numberOfOnesSmaller = NumberOfOnes(numberTemp, numberOfBits);
			}
			Console.WriteLine("Liczba podana: " + BinaryNumber(number, numberOfBits));
			if (isItBigger == true)
				Console.WriteLine("Większa liczba: " + binaryNumberBigger);
			else
				Console.WriteLine("Nie znaleziono większej liczby spełniającej warunek w podanym zakresie.");
			if (isItSmaller == true)
				Console.WriteLine("Mniejsza liczba: " + binaryNumberSmaller);
			else
				Console.WriteLine("Nie znaleziono mniejszej liczby spełniającej warunek w podanym zakresie.");
		}

		static void Main(string[] args)
		{
			int numberOfBits = 16;
			try
            {
				Console.Write("Podaj dodatnią liczbę całkowitą: ");
				uint number = uint.Parse(Console.ReadLine());
				TheSameNumberOfOnes(Convert.ToDouble(number), numberOfBits);
			}
			catch(SystemException)
            {
				Console.WriteLine("Nie podałeś poprawnej liczby.");
            }			
		}
	}
}
