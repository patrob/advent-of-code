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
                yield return new object[]
                {
                    TestMap,
                    (TestMap[0].Length, 0),
                    '.'
                };
                yield return new object[]
                {
                    TestMap,
                    (TestMap[0].Length + 3, 0),
                    '#'
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        
        public class MapWithinBoundsTestData : IEnumerable<object[]>
        {
            
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    TestMap,
                    (0, 0),
                    true
                };
                yield return new object[]
                {
                    TestMap,
                    (0, TestMap.Length),
                    false
                };
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
        public void GetCharAtLocation_Overlaps_ExpectedChar(string[] map, (int, int) location, char expectedResult)
        {
            var component = new Day03(MockOutput);
            var result = component.GetCharAtLocation(map, location);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [ClassData(typeof(MapWithinBoundsTestData))]
        public void IsWithinBounds_GivenLocations_ExpectedResult(string[] map, (int, int) location, bool expected)
        {
            var component = new Day03(MockOutput);
            var result = component.IsWithinBounds(map, location);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountTreesInPath_GivenMapAndDirection_ExpectedResult()
        {
            const int expectedAmount = 7;
            var componet = new Day03(MockOutput);
            var result = componet.CountTreesInPath(TestMap, (3,1), (0,0));

            Assert.Equal(expectedAmount, result);
        }
    }
}