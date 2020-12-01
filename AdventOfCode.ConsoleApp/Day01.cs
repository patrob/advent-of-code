using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.ConsoleApp
{
    public class Day01
    {
        public void Run(string path)
        {
            var data = File.OpenText(path)
                .ReadToEnd()
                .Split('\n')
                .Select(line => Convert.ToInt32(line))
                .ToArray();
            var puzzle1 = Find2ThatSum(data, 2020).Aggregate((c, n) => c * n);
            Console.WriteLine($"Answer 1: {puzzle1}");
            var puzzle2 = FindXThatSum(data, 2020, 3).Aggregate((c, n) => c * n);
            Console.WriteLine($"Answer 2: {puzzle2}");
        }

        public int Run(int[] input)
        {
            var expenses = Find2ThatSum(input, 2020);
            return expenses[0] * expenses[1];
        }

        public int[] Find2ThatSum(int[] input, int sum)
        {
            for(var i = 0; i < input.Length; i++)
            {
                var num1 = input[i];
                for(var j = 1; j < input.Length; j++)
                {
                    if (i == j) continue;
                    var num2 = input[j];

                    if (num1 + num2 == sum) return new int[] {num1, num2};
                }
            }
            return null;
        }

        public int[] FindXThatSum(int[] input, int sum, int count)
        {
            var findings = FindXThatSum(new List<int>(), input, sum, count);
            return findings;
        }

        public int[] FindXThatSum(List<int> expenses, int[] input, int searchSum, int count)
        {
            if (count < 0) return null;
            if (expenses.Sum() > searchSum) return null;
            if (expenses.Sum() == searchSum && count == 0) return expenses.ToArray();
            for (var i = 0; i < input.Length; i++)
            {
                if (expenses.Any(e => e == input[i])) continue;
                var newExpenses = new int[expenses.Count + 1];
                expenses.CopyTo(newExpenses);
                newExpenses[newExpenses.Length - 1] = input[i];
                var result = FindXThatSum(newExpenses.ToList(), input, searchSum, count - 1);
                if (result != null) return result;
            }
            return null;
        }

        public int[] FindXThatSum(int[] expenses, int[] input, int sum, int index)
        {
            if (expenses.All(e => e >= 0) && expenses.Sum() == sum) return expenses;
            else if(expenses.Sum() < sum) {
                
            }
            return null;
        }
    }
}