using System;
using Xunit;
using AdventOfCode.ConsoleApp;
using System.Linq;

namespace AdventOfCode.Tests
{
    public class Day01Tests
    {
        [Fact]
        public void Find2ThatSum_TestInput_ExpectedOutput()
        {
            var input = new [] {1721, 979, 366, 299, 675, 1456};
            var expectedOutput = 514579;

            var output = new Day01().Find2ThatSum(input, 2020).Aggregate((c, n) => c * n);

            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Find2ThatSum_ValidTwoNumbers_ExpectedOutput()
        {
            var input = new [] {1722, 298};
            var expectedOutput = 513156;

            var output = new Day01().Find2ThatSum(input, 2020).Aggregate((c, n) => c * n);

            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void FindXThatSum_TestInput_ExpectedOutput()
        {
            var input = new [] {1721, 979, 366, 299, 675, 1456};
            var expectedOutput = 241861950;

            var output = new Day01().FindXThatSum(input, 2020, 3).Aggregate((c, n) => c * n);

            Assert.Equal(expectedOutput, output);
        }
    }
}
