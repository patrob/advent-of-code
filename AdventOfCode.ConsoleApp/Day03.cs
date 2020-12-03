using System.IO;
using System.Linq;
using AdventOfCode.Api;

namespace AdventOfCode.ConsoleApp
{
    public class Day03 : DayBase
    {
        public const char TreeChar = '#';
        public const char OpenChar = '.';

        public Day03(TextWriter output) : base(output) { }

        public void Run(string path)
        {
            var data = InputReader.ReadAllFromFile(path)
                .ToArray();
            var puzzle1 = CountTreesInPath(data, (3, 1), (0, 0));
            Output.WriteLine($"Answer 1: {puzzle1}");
        }

        public bool IsTree(char charToCheck)
        {
            return charToCheck == TreeChar;
        }

        public char GetCharAtLocation(string[] map, (int, int) location)
        {
            var row = location.Item2;
            var column = location.Item1 % map[0].Length;
            return map[row][column];
        }

        public bool IsWithinBounds(string[] map, (int, int) location)
        {
            return location.Item2 < map.Length;
        }

        private (int, int) Move((int, int) location, (int, int) direction)
        {
            return (location.Item1 + direction.Item1, location.Item2 + direction.Item2);
        }

        public int CountTreesInPath(string[] map, (int, int) direction, (int, int) currentLocation)
        {
            if (!IsWithinBounds(map, currentLocation)) return 0;
            var charAtLocation = GetCharAtLocation(map, currentLocation);
            var nextLocation = Move(currentLocation, direction);
            if (IsTree(charAtLocation))
            {
                return 1 + CountTreesInPath(map, direction, nextLocation);
            }
            return CountTreesInPath(map, direction, nextLocation);
        }
    }
}