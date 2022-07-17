using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        // the function displays a tree of directories and files
        static void tree(string path, int spaceShift, bool orFirstDisplay)
        {
            if (orFirstDisplay)
                Console.WriteLine(Path.GetFileNameWithoutExtension(path));

            DirectoryInfo Di = new DirectoryInfo(path);
            DirectoryInfo[] Directories = Di.GetDirectories();
            foreach (DirectoryInfo directory in Directories)
            {
                for (int i = 1; i <= spaceShift; i++)
                    Console.Write(" ");

                Console.WriteLine(directory.Name);
                spaceShift++;
                tree(directory.FullName, spaceShift, false);
                spaceShift--;
            }

            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                for (int i = 1; i <= spaceShift; i++)
                    Console.Write(" ");

                FileInfo info = new FileInfo(file);
                Console.WriteLine(info.Name);
            }
        }

        static void Main(string[] args)
        {
            string path;

            while (true)
            {
                Console.Write("Enter the path to the directory whose tree you want to view: ");
                path = Console.ReadLine();

                if (!Directory.Exists(path))
                    Console.WriteLine("\nYou entered the path incorrectly or the directory does not exist. Please enter the path again.");
                else
                    break;
            }
            tree(path, 1, true);
        }
    }
}
