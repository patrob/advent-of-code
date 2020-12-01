using System;
using System.Linq;

namespace AdventOfCode.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            switch(args.FirstOrDefault())
            {
                case "1":
                    new Day01().Run("./Input/expenses.txt");
                    break;
                default:
                    Console.WriteLine("Please input a value from 1-25");
                    break;
            }
        }
    }
}
