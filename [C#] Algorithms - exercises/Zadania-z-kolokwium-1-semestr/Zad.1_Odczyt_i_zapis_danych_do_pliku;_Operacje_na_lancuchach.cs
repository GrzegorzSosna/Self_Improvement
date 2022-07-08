using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static string[] ReadFile(string path, int lineCounter)
        {
            string[] arrayData = new string[lineCounter];
            int line = 0;
            try
            {
                using (StreamReader srcSR = new StreamReader(path))
                {
                    while (!srcSR.EndOfStream)
                        arrayData[line++] = srcSR.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return arrayData;
        }

        static void WriteFile(string pathAfter, int lineCounter, string[] arrayData)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(pathAfter))
                {
                    string temp;
                    for (int i = 1; i < lineCounter; i++)
                    {
                        temp = arrayData[i];
                        sw.WriteLine(temp);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static int LineCounter(string path)
        {
            int lineCounter = 0;

            try
            {
                using (StreamReader srcSR = new StreamReader(path))
                {
                    while (!srcSR.EndOfStream)
                    {
                        srcSR.ReadLine();
                        lineCounter++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return lineCounter;
        }

        static void Main(string[] args)
        {
            string path = "numeryKart.txt";
            string pathAfter = "numeryKartMaskowane.txt";
            string[] arrayData = ReadFile(path, LineCounter(path));

            //Stopwatch stp = new Stopwatch();
            //stp.Start();
            for (int i = 1; i < arrayData.Length; i++)
            {
                // Testy z użyciem Stopwatch wykazały, że użycie StringBuildera w tym przypadku
                // spowalnia operację na łańcuchach o ok 30-40%        
                //StringBuilder temp = new StringBuilder(arrayData[i]);
                //temp = temp.Replace(",", ";");
                //temp = temp.Remove(4, 8);
                //temp = temp.Insert(4, "XXXXXXXX");
                //string[] line = temp.ToString().Split(" ");
                
                arrayData[i] = arrayData[i].Replace(",", ";");
                arrayData[i] = arrayData[i].Remove(4, 8);
                arrayData[i] = arrayData[i].Insert(4, "XXXXXXXX");
                string[] line = arrayData[i].Split(" ");

                if (line.Length == 3)
                {
                    line[2] = line[2].Remove(1);
                    line[2] = line[2].Insert(1, ".");
                    line[1] = line[2];
                    line[2] = null;
                    arrayData[i] = line[0] + " " + line[1];
                }

                if (line.Length == 2)
                {
                    line[1] = line[1].Remove(1);
                    line[1] = line[1].Insert(1, ".");
                    arrayData[i] = line[0] + " " + line[1];
                }
            }
            //stp.Stop();
            //Console.WriteLine("Czas wykonywania w milisekundach: " + stp.ElapsedTicks);

            WriteFile(pathAfter, LineCounter(path), arrayData);
        }
    }
}
