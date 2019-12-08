using System;

namespace ConsoleApp
{
    public class HelpPrinter
    {
        public void Print()
        {
            Console.WriteLine("Usage aoc [-d [day]]");
            Console.WriteLine("My Advent of Code solutions");
            Console.WriteLine();
            Console.WriteLine("-d    --day       the day to run. If omitted, the most recent day will run");
            Console.WriteLine("-y    --year      the year to run. If omitted, the most recent year will run");
            Console.WriteLine();
            Console.WriteLine("-h    --help      display this help text");
            Console.WriteLine("");
        }
    }
}