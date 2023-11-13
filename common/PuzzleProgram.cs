using Puzzles.common.Puzzles;
using Puzzles.common.Runners;

namespace Puzzles.common;

public class PuzzleProgram
{
    private readonly IPuzzleRepository _puzzleRepository;
    private readonly IHelpPrinter _helpPrinter;
    private readonly PuzzleRunner _runner;
    private readonly string _debugPuzzle;

    public PuzzleProgram(IPuzzleRepository puzzleRepository,
        IHelpPrinter helpPrinter, Options options)
    {
        _puzzleRepository = puzzleRepository;
        _helpPrinter = helpPrinter;
        _runner = new PuzzleRunner(options.TimeoutSeconds, options.HashSeed);
        _debugPuzzle = options.DebugPuzzle;
    }

    public void Run(string[] args)
    {
        var parameters = ParseParameters(args);

        if (parameters.ShowHelp)
            _helpPrinter.Print();
        else
            RunPuzzles(parameters);
    }

    private void RunPuzzles(Puzzles.Parameters parameters)
    {
        if (parameters.Id != null)
            RunSingle(parameters.Id);
        else
            RunAll(parameters);
    }

    private void RunSingle(string id)
    {
        var puzzle = _puzzleRepository.GetPuzzle(id);

        if (puzzle == null)
            throw new Exception($"The specified puzzle could not be found ({id})");

        _runner.Run(puzzle);
    }

    private void RunAll(Puzzles.Parameters parameters)
    {
        var puzzles = _puzzleRepository.GetPuzzles();
        var filteredPuzzles = new PuzzleFilter(parameters).Filter(puzzles);
        _runner.Run(filteredPuzzles);
    }

    private Puzzles.Parameters ParseParameters(string[] args) =>
        DebugMode.IsDebugMode
            ? new Puzzles.Parameters(id: _debugPuzzle)
            : Puzzles.Parameters.Parse(args);
}