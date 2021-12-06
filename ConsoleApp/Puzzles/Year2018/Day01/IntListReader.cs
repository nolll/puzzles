using System.Collections.Generic;
using System.Linq;
using Core.Strings;

namespace ConsoleApp.Puzzles.Year2018.Day01
{
    public static class IntListReader
    {
        public static List<int> Read(string str)
        {
            return PuzzleInputReader.ReadLines(str).Select(ConvertToInt).ToList();
        }

        private static int ConvertToInt(string str)
        {
            return int.Parse(str);
        }
    }
}