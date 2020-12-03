using System.IO;

namespace AdventOfCode.ConsoleApp
{
    public abstract class DayBase
    {
        protected TextWriter Output;

        protected DayBase(TextWriter output)
        {
            Output = output;
        }
    }
}