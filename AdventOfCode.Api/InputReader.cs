using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Api
{
    public class InputReader
    {
        public static IEnumerable<string> ReadAllFromFile(string filePath)
        {
            return File.ReadAllText(filePath).Split('\n');
        }
    }
}