using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.ConsoleApp
{
    public class Day02
    {
        private readonly TextWriter Output;

        public Day02(TextWriter output)
        {
            Output = output;
        }

        public void Run(string path)
        {
            var data = File.OpenText(path).ReadToEnd().Split('\n');
            var result = GetNumberOfValidPasswords(data);
            Output.WriteLine($"Answer 1: {result}");
        }

        public int GetNumberOfValidPasswords(IEnumerable<string> records)
        {
            return records.Count(record => IsValidPassword(record));
        }

        public (string, string) GetPolicyAndPassword(string input)
        {
            var policyText = input.Substring(0, input.IndexOf(":"));
            var password = input.Substring(input.IndexOf(":") + 2);
            return (policyText, password);
        }

        public (int, int, char) ParsePasswordPolicy(string policyText)
        {
            var rangeAndChar = policyText.Split(" ");
            var requiredChar = rangeAndChar[1].First();
            var range = rangeAndChar[0].Split('-');
            var low = Convert.ToInt32(range[0]);
            var high = Convert.ToInt32(range[1]);
            return (low, high, requiredChar);
        }

        private int CountChars(char charToCount, string text)
        {
            return text.Count(c => c == charToCount);
        }

        public bool IsValidPassword(string input)
        {
            var policyAndPassword = GetPolicyAndPassword(input);
            var policy = ParsePasswordPolicy(policyAndPassword.Item1);
            var password = policyAndPassword.Item2;
            var charCount = CountChars(policy.Item3, password);
            
            return charCount >= policy.Item1 && charCount <= policy.Item2;
        }
    }
}