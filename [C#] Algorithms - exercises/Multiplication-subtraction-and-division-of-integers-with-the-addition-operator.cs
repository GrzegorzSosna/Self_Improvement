/* Zad. Napisz metody wykonujące operacje mnożenia, odejmowania i dzielenia liczb całkowitych. Możesz zastosować
 wyłącznie operator dodawania. */
using System;

namespace ConsoleApp
{
    class Program
    {
        static int Multiplication(int numberA, int numberB)
        {
            int result = 0;
            // to reduce the number of iterations in the 'for' loop, substitute the variable with the smaller absolute value for numberB
            if (Math.Abs(numberA) < Math.Abs(numberB))
                return Multiplication(numberB, numberA);

            for (int i = 1; i <= Math.Abs(numberB); i++)
                result += numberA;

            if (numberB < 0 && numberA > 0)
                result = NegativeSign(result);
         
            if (numberB < 0 && numberA < 0)
                result = Math.Abs(result);
            
            return result;
        }

        static int Minus(int numberA, int numberB)
        {
            int result = 0;
            if (numberB > 0)
                result = numberA + NegativeSign(numberB);
            else
                result = numberA + Math.Abs(numberB);

            return result;
        }

        static int Division(int numberA, int numberB)
        {
            if (numberB == 0) throw new DivideByZeroException("Cannot be divided by zero.");
            int result = 0;
            int resultSum = 0;

            while (resultSum + Math.Abs(numberB) <= Math.Abs(numberA))
            {
                resultSum += Math.Abs(numberB);
                result++;
            }

            if (numberB < 0 && numberA > 0)
                result = NegativeSign(result);

            if (numberB > 0 && numberA < 0)
                result = NegativeSign(result);
         
            // the division result is rounded down
            return result;
        }

        // function that changes the sign of a number to negative
        static int NegativeSign(int number)
        {
            int result = 0;

            while (Math.Abs(result) != number)
                result += -1;

            return result;
        }

        static void Main(string[] args)
        {
            int numberA = -10;
            int numberB = 2;

            try
            {
                Console.WriteLine($"Numbers: {numberA}, {numberB}");
                Console.WriteLine("Multiplication: " + Multiplication(numberA, numberB));
                Console.WriteLine("Minus: " + Minus(numberA, numberB));
                Console.WriteLine("Division: " + Division(numberA, numberB));
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }                
        }
    }
}
