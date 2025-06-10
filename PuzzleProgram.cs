using Pzl.Aoc;
using Pzl.Aquaq;
using Pzl.Client.Debugging;
using Pzl.Client.Filter;
using Pzl.Client.Help;
using Pzl.Client.Params;
using Pzl.Client.Running.Results;
using Pzl.Client.Running.Runners;
using Pzl.Codyssi;
using Pzl.Common;
using Pzl.Euler;
using Pzl.Everybody;
using Pzl.Tools.Cryptography;
using Spectre.Console;

namespace Pzl.Client;

public class PuzzleProgram
{
    private readonly PuzzleRepository _puzzleRepository;
    private readonly HelpPrinter _helpPrinter;
    private readonly PuzzleRunner _runner;
    private readonly ParameterProvider _parameterProvider;

    public PuzzleProgram(Options options)
    {
        var puzzleProviders = new List<IPuzzleProvider>
        {
            new AocPuzzleProvider(),
            new AquaqPuzzleProvider(),
            new EulerPuzzleProvider(),
            new EverybodyEventPuzzleProvider(),
            new EverybodyStoryPuzzleProvider(),
            new CodyssiPuzzleProvider()
        };

        var fileReader = new FileReader();
        var puzzleFactory = new PuzzleFactory(fileReader);
        var hashFactory = new HashFactory();
        var resultVerifier = new ResultVerifier(hashFactory, options.HashSeed);
        var runMode = new RunMode();
        _parameterProvider = new ParameterProvider(runMode, options.DebugTags);
        _puzzleRepository = new PuzzleRepository(puzzleProviders);
        _helpPrinter = new HelpPrinter();
        _runner = new PuzzleRunner(puzzleFactory, resultVerifier, options.TimeoutSeconds, runMode);
    }

    public void Run(IEnumerable<string> args) => Run(_parameterProvider.GetParameters(args));

    private void Run(Parameters parameters)
    {
        if (parameters.ShowHelp)
            Print();
        else if (parameters.Query is not null)
            Search(parameters.Query);
        else
            RunPuzzles(parameters);
    }
    
    private void Print() => _helpPrinter.Print();

    private void RunPuzzles(Parameters parameters)
    {
        var puzzles = _puzzleRepository.GetPuzzles();
        var filteredPuzzles = new PuzzleFilter(parameters).Filter(puzzles).ToList();
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
}

public class ParameterProvider(RunMode runMode, string debugTags)
{
    public Parameters GetParameters(IEnumerable<string> args) =>
        runMode.IsDebug
            ? DebugParameters
            : Parameters.Parse(args);

    private Parameters DebugParameters => new(tags: debugTags.Split(',').ToArray());
}