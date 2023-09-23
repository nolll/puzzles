using Common.Puzzles;
using Common.Runners;

namespace Common;

public class Program
{
    private const int PuzzleTimeout = 10;

    private readonly IPuzzleRepository _puzzleRepository;
    private readonly IHelpPrinter _helpPrinter;
    private readonly PuzzleRunner _runner = new(PuzzleTimeout);

    public Program(
        IPuzzleRepository puzzleRepository, 
        IHelpPrinter helpPrinter)
    {
        _puzzleRepository = puzzleRepository;
        _helpPrinter = helpPrinter;
    }

    public void Run(string[] args, string debugPuzzle)
    {
        var parameters = ParseParameters(args, debugPuzzle);

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

    private static Puzzles.Parameters ParseParameters(string[] args, string debugPuzzle) =>
        DebugMode.IsDebugMode
            ? new Puzzles.Parameters(id: debugPuzzle)
            : Puzzles.Parameters.Parse(args);
}