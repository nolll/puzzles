using System;
using Aoc.Printing;
using Aoc.Puzzles;
using common.Puzzles;
using Common.Puzzles;
using common.Runners;

namespace Aoc;

public class AocProgram
{
    private const int PuzzleTimeout = 10;
    private const string DebugPuzzle = "201804";

    private static readonly PuzzleRunner Runner = new(PuzzleTimeout);
    private static readonly IPuzzleRepository PuzzleRepository = new AocPuzzleRepository();
    private static readonly IHelpPrinter HelpPrinter = new AocHelpPrinter();

    static void Main(string[] args)
    {
        var parameters = ParseParameters(args);

        if (parameters.ShowHelp)
            HelpPrinter.Print();
        else
            RunPuzzles(parameters);
    }

    private static void RunPuzzles(Parameters parameters)
    {
        if (parameters.Id != null)
            RunSingle(parameters.Id);
        else
            RunAll(parameters);
    }

    private static void RunSingle(string id)
    {
        var foundDay = PuzzleRepository.GetPuzzle(id);
        if (foundDay == null)
            throw new Exception("The specified day could not be found.");
            
        Runner.Run(foundDay);
    }
    
    private static void RunAll(Parameters parameters)
    {
        var allDays = PuzzleRepository.GetPuzzles();
        var filteredDays = new PuzzleFilter(parameters).Filter(allDays);
        Runner.Run(filteredDays);
    }

    private static Parameters ParseParameters(string[] args) =>
        DebugMode.IsDebugMode
            ? new Parameters(id: DebugPuzzle)
            : Parameters.Parse(args);
}