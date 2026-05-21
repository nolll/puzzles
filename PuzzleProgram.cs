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
using Pzl.FlipFlop;
using Pzl.Tools.Cryptography;

namespace Pzl.Client;

public class PuzzleProgram
{
    private readonly Options _options;
    private readonly PuzzleRepository _puzzleRepository;
    private readonly HelpPrinter _helpPrinter;
    private readonly ParameterProvider _parameterProvider;
    private readonly PuzzleFactory _puzzleFactory;
    private readonly ResultVerifier _resultVerifier;
    private readonly RunMode _runMode;

    public PuzzleProgram(Options options)
    {
        _options = options;
        
        IPuzzleProvider[] puzzleProviders =
        [
            new AocPuzzleProvider(),
            new AquaqPuzzleProvider(),
            new CodyssiPuzzleProvider(),
            new EulerPuzzleProvider(),
            new EverybodyEventPuzzleProvider(),
            new EverybodyStoryPuzzleProvider(),
            new FlipFlopPuzzleProvider()
        ];

        var fileReader = new FileReader();
        _puzzleFactory = new PuzzleFactory(fileReader);
        var hashFactory = new HashFactory();
        _resultVerifier = new ResultVerifier(hashFactory, options.HashSeed);
        _runMode = new RunMode();
        _parameterProvider = new ParameterProvider(_runMode, options.DebugTags);
        _puzzleRepository = new PuzzleRepository(puzzleProviders);
        _helpPrinter = new HelpPrinter();
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
        var runFunc = GetRunFunc(filteredPuzzles);
        runFunc();
    }
    
    private Action GetRunFunc(List<PuzzleDefinition> puzzles) => puzzles.Count switch
    {
        0 => () => Printer.WriteLine("No puzzles found."),
        1 => () => new StandaloneSinglePuzzleRunner(_puzzleFactory, _resultVerifier, puzzles.First(), _runMode).Run(),
        _ => () => new MultiPuzzleRunner(_puzzleFactory, _resultVerifier, puzzles, _options.TimeoutSeconds).Run()
    };

    private void Search(string query)
    {
        var puzzles = _puzzleRepository.Search(query);
        Printer.WriteLine($"Search: {query}");
        if(puzzles.Count == 0)
            Printer.WriteLine("No puzzles found!");

        foreach (var puzzle in puzzles)
        {
            Printer.WriteLine($"{puzzle.Title}: {puzzle.Name}");
        }
    }
}

public class ParameterProvider(RunMode runMode, string debugTags)
{
    public Parameters GetParameters(IEnumerable<string> args) =>
        runMode.IsDebug
            ? DebugParameters
            : Parameters.Parse(args);

    private Parameters DebugParameters => new(tags: debugTags.Split(','));
}