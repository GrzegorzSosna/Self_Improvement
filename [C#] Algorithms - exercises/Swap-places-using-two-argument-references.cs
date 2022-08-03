/* Zad. Napisać funkcję, która zamieni miejscami dwa elementy typu int, podane jako jej
argumenty. Oczywiście argumenty muszą być przekazane przez adres. Uwaga: Choć taka funkcja
operująca na danych typu int może wydawać się nieprzydatna (to tylko ćwiczenia) to w podobny
sposób można napisać funkcję zamieniającą bardzo złożone typy danych. */

using System;

namespace ConsoleApp
{
    class Program
    {
		static void Variables(int a, int b)
		{
			int t = a;
			a = b;
			b = t;
		}
			
		static void Reference(ref int a, ref int b)
		{
			int t = a;
			a = b;
			b = t;
		}
			
		static void Arrays(int[] a, int[] b)
		{
			int t = a[0];
			a[0] = b[0];
			b[0] = t;
		}


        static void Main(string[] args)
		{
			int varA = 2, varB = 4;	
			Variables(varA, varB);		
			Console.WriteLine(varA + ", " + varB); // output: 2, 4
			
			int refA = 2, refB = 4;	
			Reference(ref refA, ref refB);		
			Console.WriteLine(refA + ", " + refB); // output: 4, 2
			
			int[] arrayA = new int[] {2};
			int[] arrayB = new int[] {4};
			Arrays(arrayA, arrayB);		
			Console.WriteLine(arrayA[0] + ", " + arrayB[0]); // output: 4, 2
        }
    }
}
