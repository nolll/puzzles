using System;
using System.Collections.Generic;
using System.Linq;
using Cli.ConsoleTools;
using Cli.Printing;
using Core;
using Core.Platform;

namespace Cli;

public class Program
{
    private const int PuzzleTimeout = 10;

    private const int DebugYear = 2015;
    private const int DebugDay = 20;

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
        var puzzleRepository = new PuzzleRepository();
        var foundDay = puzzleRepository.GetDay(parameters.Year, parameters.Day);
        if (foundDay == null)
            throw new Exception("The specified day could not be found.");
            
        RunDays(new List<PuzzleDay> {foundDay}, null, true);
    }

    private static void RunEvent(Parameters parameters)
    {
        var puzzleRepository = new PuzzleRepository();
        var eventDays = puzzleRepository.GetEventDays(parameters.Year);
        if (!eventDays.Any())
            throw new Exception("Event not found!");

        var filteredDays = FilterDays(eventDays, parameters);
        RunDays(filteredDays, PuzzleTimeout, false);
    }

    private static void RunAll(Parameters parameters)
    {
        var puzzleRepository = new PuzzleRepository();
        var allDays = puzzleRepository.GetAll();
        var filteredDays = FilterDays(allDays, parameters);
        RunDays(filteredDays, PuzzleTimeout, false);
    }

    private static void RunDays(List<PuzzleDay> days, int? timeout, bool throwExceptions)
    {
        var runner = GetPuzzleRunner(timeout, throwExceptions);
            
        if (days.Count == 1)
            runner.Run(days.First());
        else
            runner.Run(days);
    }

    private static PuzzleRunner GetPuzzleRunner(int? timeout, bool throwExceptions)
    {
        return new(new SingleDayPrinter(), new MultiDayPrinter(timeout), throwExceptions, timeout);
    }

    private static void ShowHelp()
    {
        var helpPrinter = new HelpPrinter();
        helpPrinter.Print();
    }

    private static Parameters ParseParameters(string[] args)
    {
#if SINGLE
        return new Parameters(day: DebugDay, year: DebugYear);
#else
        return Parameters.Parse(args);
#endif
    }

    private static List<PuzzleDay> FilterDays(List<PuzzleDay> days, Parameters parameters)
    {
        if (parameters.RunSlowOnly)
            return days.Where(o => o.Puzzle.IsSlow).ToList();

        if (parameters.RunCommentedOnly)
            return days.Where(o => !string.IsNullOrEmpty(o.Puzzle.Comment)).ToList();

        return days;
    }
}