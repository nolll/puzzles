using System;

namespace Aoc.Printing;

public class ConsoleHelpPrinter : IHelpPrinter
{
    public void Print()
    {
        Console.WriteLine("Usage dotnet run -- [-y [year]] [-d [day]]");
        Console.WriteLine("My Advent of Code solutions.");
        Console.WriteLine("If day is omitted, all days for the specified year will run.");
        Console.WriteLine("If year is omitted, all days for all years will run.");
        Console.WriteLine();
        Console.WriteLine("-d    --day       the day to run. This will be ignored if no year is specified");
        Console.WriteLine("-y    --year      the year to run. All puzzles for the event will run");
        Console.WriteLine("-s    --slow      just run days marked as slow. Can be used on all lists");
        Console.WriteLine("-c    --comment   just run days that has a comment. Can be used on all lists");
        Console.WriteLine();
        Console.WriteLine("-h    --help      display this help text");
        Console.WriteLine("");
    }
}