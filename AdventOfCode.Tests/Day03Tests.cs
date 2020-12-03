using System.Collections;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.ConsoleApp;
using NSubstitute;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day03Tests
    {
        protected TextWriter MockOutput;
        public static string[] TestMap = new string[] {
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#"
        };

        public class MapOverlapTestData : IEnumerable<object[]>
        {
            
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { (TestMap[0].Length, 0), '.' };
                yield return new object[] { (TestMap[0].Length + 3, 0), '#' };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        
        public class MapWithinBoundsTestData : IEnumerable<object[]>
        {
            
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { (0, 0), true };
                yield return new object[] { (0, TestMap.Length), false };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class MultiplePathsTestData : IEnumerable<object[]>
        {
            
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { (1, 1), 2 };
                yield return new object[] { (3, 1), 7 };
                yield return new object[] { (5, 1), 3 };
                yield return new object[] { (7, 1), 4 };
                yield return new object[] { (1, 2), 2 };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public Day03Tests()
        {
            MockOutput = Substitute.For<TextWriter>();
        }

        [Theory]
        [InlineData('#', true)]
        [InlineData('.', false)]
        public void IsTree_GivenCharacter_ExpectedResult(char inputChar, bool expected)
        {
            var component = new Day03(MockOutput);

            var result = component.IsTree(inputChar);

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(MapOverlapTestData))]
        public void GetCharAtLocation_Overlaps_ExpectedChar((int, int) location, char expectedResult)
        {
            var component = new Day03(MockOutput);
            var result = component.GetCharAtLocation(TestMap, location);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [ClassData(typeof(MapWithinBoundsTestData))]
        public void IsWithinBounds_GivenLocations_ExpectedResult((int, int) location, bool expected)
        {
            var component = new Day03(MockOutput);
            var result = component.IsWithinBounds(TestMap, location);

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(MultiplePathsTestData))]
        public void CountTreesInPath_GivenMapAndDirection_ExpectedResult((int, int) direction, int expectedAmount)
        {
            var componet = new Day03(MockOutput);
            var result = componet.CountTreesInPath(TestMap, direction, (0,0));

            Assert.Equal(expectedAmount, result);
        }

        [Fact]
        public void MultiplyTreesInPath_GivenMapAndPaths_ExpectedResult()
        {
            const int expected = 336;
            var paths = new[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };
            var component = new Day03(MockOutput);
            var result = component.MultiplyTreesInPaths(TestMap, paths);
            Assert.Equal(expected, result);
        }
    }
}