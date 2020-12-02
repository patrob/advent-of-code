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
                    new Day01().Run("./Input/day01.txt");
                    break;
                case "2":
                    new Day02(Console.Out).Run("./Input/day02.txt");
                    break;
                default:
                    Console.WriteLine("Please input a value from 1-25");
                    break;
            }
        }
    }
}
