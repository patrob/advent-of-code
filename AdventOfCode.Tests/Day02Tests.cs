using AdventOfCode.ConsoleApp;
using NSubstitute;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day02Tests
    {
        public class PasswordPolicyTextTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {"1-3 a", (1, 3, 'a')};
                yield return new object[] {"1-3 b", (1, 3, 'b')};
                yield return new object[] {"2-9 c", (2, 9, 'c')};
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        public class PasswordAndPolicyTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {"1-3 a: abcde", ("1-3 a", "abcde")};
                yield return new object[] {"1-3 b: cdefg", ("1-3 b", "cdefg")};
                yield return new object[] {"2-9 c: ccccccccc", ("2-9 c", "ccccccccc")};
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class IsValidPasswordTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {"1-3 a: abcde", true};
                yield return new object[] {"1-3 b: cdefg", false};
                yield return new object[] {"2-9 c: ccccccccc", true};
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class Part1PasswordPolicyTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {(1, 3, 'a'), "abcde", true};
                yield return new object[] {(1, 3, 'b'), "cdefg", false};
                yield return new object[] {(2, 9, 'c'), "ccccccccc", true};
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class Part2PasswordPolicyTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {(1, 3, 'a'), "abcde", true};
                yield return new object[] {(1, 3, 'b'), "cdefg", false};
                yield return new object[] {(2, 9, 'c'), "ccccccccc", false};
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory]
        [ClassData(typeof(Part1PasswordPolicyTestData))]
        public void Part1PasswordPolicy_IsValidPassword_SampleData_ExpectedResult((int, int, char) policy, string password, bool expectedResult)
        {
            var passwordPolicy = new Part1PasswordPolicy();
            var result = passwordPolicy.IsValidPassword(password, policy);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [ClassData(typeof(Part2PasswordPolicyTestData))]
        public void Part2PasswordPolicy_IsValidPassword_SampleData_ExpectedResult((int, int, char) policy, string password, bool expectedResult)
        {
            var passwordPolicy = new Part2PasswordPolicy();
            var result = passwordPolicy.IsValidPassword(password, policy);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [ClassData(typeof(PasswordPolicyTextTestData))]
        public void ParsePasswordPolicy_SampleData_ExpectedTuple(string input, (int, int, char) expectedOutput)
        {
            var outputWriter = Substitute.For<TextWriter>();
            var testComponent = new Day02(outputWriter);
            var output = testComponent.ParsePasswordPolicy(input);

            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [ClassData(typeof(PasswordAndPolicyTestData))]
        public void GetPolicyAndPassword_SampleData_ExpectedTuple(string input, (string, string) expectedOutput)
        {
            var outputWriter = Substitute.For<TextWriter>();
            var testComponent = new Day02(outputWriter);
            var output = testComponent.GetPolicyAndPassword(input);

            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [ClassData(typeof(IsValidPasswordTestData))]
        public void IsValidPassword_SampleData_ExpectedResult(string input, bool expectedOutput)
        {
            var outputWriter = Substitute.For<TextWriter>();
            var testComponent = new Day02(outputWriter);
            var policy = new Part1PasswordPolicy();
            var result = testComponent.IsValidPassword(input, policy);

            Assert.Equal(expectedOutput, result);
        }
    }
}