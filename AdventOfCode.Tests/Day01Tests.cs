using System;
using Xunit;
using AdventOfCode.ConsoleApp;
using System.Linq;

namespace AdventOfCode.Tests
{
    public class Day01Tests
    {
        [Fact]
        public void FindXThatSum_Find2FromSample_ExpectedOutput()
        {
            var input = new [] {1721, 979, 366, 299, 675, 1456};
            var expectedOutput = 514579;

            var output = new Day01().FindXThatSum(input, 2020, 2).Aggregate((c, n) => c * n);

            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void FindXThatSum_Find3FromSample_ExpectedOutput()
        {
            var input = new [] {1721, 979, 366, 299, 675, 1456};
            var expectedOutput = 241861950;

            var output = new Day01().FindXThatSum(input, 2020, 3).Aggregate((c, n) => c * n);

            Assert.Equal(expectedOutput, output);
        }
    }
}
