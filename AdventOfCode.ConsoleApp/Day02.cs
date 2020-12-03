using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Api;

namespace AdventOfCode.ConsoleApp
{
    public interface IPasswordPolicy {
        bool IsValidPassword(string password, (int, int, char) policy);
    }

    public abstract class PasswordPolicy : IPasswordPolicy {
        protected int CountChars(char charToCount, string text)
        {
            return text.Count(c => c == charToCount);
        }

        public virtual bool IsValidPassword(string password, (int, int, char) policy)
        {
            throw new NotImplementedException("implement child class");
        }
    }

    public class Part1PasswordPolicy : PasswordPolicy {
        public override bool IsValidPassword(string password, (int, int, char) policy)
        {
            var charCount = CountChars(policy.Item3, password);
            return charCount >= policy.Item1 && charCount <= policy.Item2;
        }
    }

    public class Part2PasswordPolicy : PasswordPolicy {
        public override bool IsValidPassword(string password, (int, int, char) policy)
        {
            var charAt1 = password[policy.Item1 - 1];
            var charAt2 = password[policy.Item2 - 1];
            return charAt1 == policy.Item3 ^ charAt2 == policy.Item3;
        }
    }

    public class Day02 : DayBase
    {
        public Day02(TextWriter output) : base(output) {}

        public void Run(string path)
        {
            var data = InputReader.ReadAllFromFile(path);
            var part1Policy = new Part1PasswordPolicy();
            var result1 = GetNumberOfValidPasswords(data, part1Policy);
            Output.WriteLine($"Answer 1: {result1}");
            var part2Policy = new Part2PasswordPolicy();
            var result2 = GetNumberOfValidPasswords(data, part2Policy);
            Output.WriteLine($"Answer 2: {result2}");
        }

        public int GetNumberOfValidPasswords(IEnumerable<string> records, IPasswordPolicy policy)
        {
            return records.Count(record => IsValidPassword(record, policy));
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

        public bool IsValidPassword(string input, IPasswordPolicy passwordPolicy)
        {
            var policyAndPassword = GetPolicyAndPassword(input);
            var policy = ParsePasswordPolicy(policyAndPassword.Item1);
            var password = policyAndPassword.Item2;
            var charCount = CountChars(policy.Item3, password);
            
            return passwordPolicy.IsValidPassword(password, policy);
        }
    }
}