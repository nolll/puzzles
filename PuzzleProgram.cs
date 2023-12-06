using Pzl.Client.Debug;
using Pzl.Client.Filter;
using Pzl.Client.Help;
using Pzl.Client.Running;
using Pzl.Client.Running.Runners;
using Spectre.Console;

namespace Pzl.Client;

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
    
    private void RunPuzzles(Parameters.Parameters parameters)
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

    private Parameters.Parameters ParseParameters(IEnumerable<string> args) =>
        DebugMode.IsDebugMode
            ? new Parameters.Parameters(tags: _debugTags.Split(',').ToList())
            : Parameters.Parameters.Parse(args);
}