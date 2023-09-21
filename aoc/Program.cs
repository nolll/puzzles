using System;
using System.Linq;
using Aoc.ConsoleTools;
using Aoc.Platform;
using Aoc.Printing;
using Aoc.Puzzles;
using common.Runners;

namespace Aoc;

public class Program
{
    private const int PuzzleTimeout = 10;

    private const int DebugYear = 2018;
    private const int DebugDay = 4;

    private static readonly PuzzleRunner Runner = new(PuzzleTimeout);
    private static readonly PuzzleRepository PuzzleRepository = new();

    static void Main(string[] args)
    {
        var parameters = ParseParameters(args);

        if (parameters.ShowHelp)
            ShowHelp();
        else
            RunPuzzles(parameters);
    }

    private static void RunPuzzles(Parameters parameters)
    {
        if (parameters.Year != null && parameters.Day != null)
            RunSingle(parameters);
        else if (parameters.Year != null)
            RunEvent(parameters);
        else
            RunAll(parameters);
    }

    private static void RunSingle(Parameters parameters)
    {
        var foundDay = PuzzleRepository.GetDay(parameters.Year, parameters.Day);
        if (foundDay == null)
            throw new Exception("The specified day could not be found.");
            
        Runner.Run(foundDay);
    }

    private static void RunEvent(Parameters parameters)
    {
        var eventDays = PuzzleRepository.GetEventDays(parameters.Year);
        if (!eventDays.Any())
            throw new Exception("Event not found!");

        var filteredDays = new DayFilter(parameters).Filter(eventDays);
        Runner.Run(filteredDays);
    }

    private static void RunAll(Parameters parameters)
    {
        var allDays = PuzzleRepository.GetAll();
        var filteredDays = new DayFilter(parameters).Filter(allDays);
        Runner.Run(filteredDays);
    }

    private static void ShowHelp() => SpectreHelpPrinter.Print();

    private static Parameters ParseParameters(string[] args)
    {
#if SINGLE
        return new Parameters(day: DebugDay, year: DebugYear);
#else
        return Parameters.Parse(args);
#endif
    }
}