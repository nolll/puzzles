using Puzzles.Common.Puzzles;
using Puzzles.Common.Runners;
using Spectre.Console;

namespace Puzzles.Common;

public class PuzzleProgram
{
    private readonly PuzzleRepository _puzzleRepository;
    private readonly HelpPrinter _helpPrinter;
    private readonly PuzzleRunner _runner;
    private readonly string _debugTags;

    public PuzzleProgram(Options options)
    {
        _puzzleRepository = new PuzzleRepository();
        _helpPrinter = new HelpPrinter();
        _runner = new PuzzleRunner(options.TimeoutSeconds, options.HashSeed, DebugMode.IsDebugMode);
        _debugTags = options.DebugTags;
    }

    public void Run(IEnumerable<string> args)
    {
        var parameters = ParseParameters(args);

        if (parameters.ShowHelp)
            _helpPrinter.Print();
        else if (parameters.Query is not null)
            Search(parameters.Query);
        else
            RunPuzzles(parameters);
    }
    
    private void RunPuzzles(Puzzles.Parameters parameters)
    {
        var puzzles = _puzzleRepository.GetPuzzles();
        var filteredPuzzles = new PuzzleFilter(parameters).Filter(puzzles);
        _runner.Run(filteredPuzzles);
    }

    private void Search(string query)
    {
        var puzzles = _puzzleRepository.Search(query);
        AnsiConsole.WriteLine($"Search: {query}");
        if(!puzzles.Any())
            AnsiConsole.WriteLine("No puzzles found!");

        foreach (var puzzle in puzzles)
        {
            AnsiConsole.WriteLine($"{puzzle.Title}: {puzzle.Name}");
        }
    }

    private Puzzles.Parameters ParseParameters(IEnumerable<string> args) =>
        DebugMode.IsDebugMode
            ? new Puzzles.Parameters(tags: _debugTags.Split(',').ToList())
            : Puzzles.Parameters.Parse(args);
}