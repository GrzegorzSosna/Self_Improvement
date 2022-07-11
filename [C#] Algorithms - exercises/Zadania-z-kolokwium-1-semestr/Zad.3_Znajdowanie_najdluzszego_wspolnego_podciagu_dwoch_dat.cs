using System;
using System.Globalization;

namespace Kolokwium
{
    class Program
    {
        static void Main(string[] args)
        {
            string timeOne = DateTime.Now.ToString(new CultureInfo("pl-PL"));
            string timeTwo = DateTime.Now.ToString(new CultureInfo("en-US"));
            string longestSubstring = null;
            int lengthSubstring = 0;

            for (int i = 0; i < timeOne.Length; i++)
            {
                string timeOneSubstring = timeOne[i].ToString();

                for (int q = i + 1; q < timeOne.Length; q++)
                {
                    timeOneSubstring += timeOne[q].ToString();
                    if (timeTwo.Contains(timeOneSubstring) && lengthSubstring < timeOneSubstring.Length)
                    {
                        lengthSubstring = timeOneSubstring.Length;
                        longestSubstring = timeOneSubstring;
                    }
                }
            }
            Console.WriteLine(timeOne);
            Console.WriteLine(timeTwo);
            Console.WriteLine("Najdłuższy wspólny podciąg: " + longestSubstring);
        }
    }
}
