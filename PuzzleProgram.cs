using Pzl.Aoc;
using Pzl.Aquaq;
using Pzl.Client.Debug;
using Pzl.Client.Filter;
using Pzl.Client.Help;
using Pzl.Client.Params;
using Pzl.Client.Running.Runners;
using Pzl.Common;
using Pzl.Euler;
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
        var puzzleProviders = new List<IPuzzleProvider>
        {
            new AocPuzzleProvider(),
            new AquaqPuzzleProvider(),
            new EulerPuzzleProvider()
        };

        _puzzleRepository = new PuzzleRepository(puzzleProviders);
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
    
    private void RunPuzzles(Parameters parameters)
    {
        var puzzles = _puzzleRepository.GetPuzzles();
        var filteredPuzzles = new PuzzleFilter(parameters).Filter(puzzles);
        _runner.Run(filteredPuzzles);
    }

    private void Search(string query)
    {
        var puzzles = _puzzleRepository.Search(query);
        AnsiConsole.WriteLine($"Search: {query}");
        if(puzzles.Count == 0)
            AnsiConsole.WriteLine("No puzzles found!");

        foreach (var puzzle in puzzles)
        {
            AnsiConsole.WriteLine($"{puzzle.Title}: {puzzle.Name}");
        }
    }

    private Parameters ParseParameters(IEnumerable<string> args) =>
        DebugMode.IsDebugMode
            ? DebugParameters
            : Parameters.Parse(args);

    private Parameters DebugParameters => new(tags: _debugTags.Split(',').ToList());
}