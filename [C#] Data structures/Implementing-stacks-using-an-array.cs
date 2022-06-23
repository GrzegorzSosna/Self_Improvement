// Implement three stacks with one array.

using System;

namespace ConsoleApp
{
    class Program
    {
        static void peek(int[] stacks, int[] topStacks, int numberStacks)
        {
            if (topStacks[numberStacks - 1] < 0)
            {
                Console.Clear();
                Console.WriteLine($"Stack {numberStacks} contains no items.");
            }
            int elements = 1;
            for (int i = numberStacks - 1; i <= ((topStacks[numberStacks - 1] + 1) * 3) - (4 - numberStacks); i += 3)
            {
                if (i <= 2)
                {
                    Console.Clear();
                    Console.WriteLine($"The number of elements in the stack {numberStacks} : " + (topStacks[numberStacks - 1] + 1));
                    Console.WriteLine($"Stack elements {numberStacks} : ");
                }
                Console.WriteLine("(" + elements + $") {stacks[i]}");
                elements++;
            }
            Console.WriteLine();
        }

        static void add(int[] stacks, int[] topStacks, int numberStacks, uint sizeStacks, int value)
        {
            if (topStacks[numberStacks - 1] == sizeStacks - 1)
                throw new ArgumentException("\nThe stack is full. You cannot add any more items.\n");
            stacks[((topStacks[numberStacks - 1] + 1) * 3) - (4 - numberStacks) + 3] = value;
            topStacks[numberStacks - 1]++;
            Console.Clear();
            Console.WriteLine($"The item has been added to the stack {numberStacks}.\n");
        }

        static void remove(int[] stacks, int[] topStacks, int numberStacks)
        {
            if (topStacks[numberStacks - 1] == -1)
                throw new ArgumentException("\nThe stack is empty. You have nothing to delete.\n");
            stacks[((topStacks[numberStacks - 1] + 1) * 3) - (4 - numberStacks)] = 0;
            topStacks[numberStacks - 1]--;
            Console.Clear();
            Console.WriteLine($"The item has been removed from the stack {numberStacks}.\n");
        }

        static void Main(string[] args)
        {
            uint sizeStacks = 5; // stack memory area
            int[] stacks = new int[sizeStacks * 3];
            int[] topStacks = new int[3] { -1, -1, -1 };
            int numberStacks = 0, value = 0;

            while (true)
            {
                Console.Write("(p) peek, (a) add, (r) remove : ");
                string choice = Console.ReadLine();

                if (choice == "p")
                {
                    try
                    {
                        Console.Write("Enter stack number (1-3) : ");
                        numberStacks = int.Parse(Console.ReadLine());
                        if (numberStacks < 1 || numberStacks > 3)
                            throw new ArgumentException("\nEnter a number from 1 to 3.\n");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nYou entered the wrong character.\n");
                    }
                    peek(stacks, topStacks, numberStacks);
                }

                if (choice == "a")
                {
                    try
                    {
                        Console.Write("Enter stack number (1-3) : ");
                        numberStacks = int.Parse(Console.ReadLine());
                        if (numberStacks < 1 || numberStacks > 3)
                            throw new ArgumentException("\nEnter a number from 1 to 3.\n");
                        Console.Write("Enter the value of the item : ");
                        value = int.Parse(Console.ReadLine());
                        add(stacks, topStacks, numberStacks, sizeStacks, value);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nYou entered the wrong character.\n");
                    }                 
                }

                if (choice == "r")
                {
                    try
                    {
                        Console.Write("Enter stack number (1-3) : ");
                        numberStacks = int.Parse(Console.ReadLine());
                        if (numberStacks < 1 || numberStacks > 3)
                            throw new ArgumentException("\nEnter a number from 1 to 3.\n");
                        remove(stacks, topStacks, numberStacks);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nYou entered the wrong character.\n");
                    }
                }
            }
        }
    }
}
