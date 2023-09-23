﻿using Common.Puzzles;
using Common.Runners;

namespace Common;

public class Program
{
    private const int ProblemTimeout = 10;

    private readonly IPuzzleRepository _puzzleRepository;
    private readonly IHelpPrinter _helpPrinter;
    private readonly PuzzleRunner _runner = new(ProblemTimeout);

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
            RunProblems(parameters);
    }

    private void RunProblems(Puzzles.Parameters parameters)
    {
        if (parameters.Id != null)
            RunSingle(parameters.Id);
        else
            RunAll(parameters);
    }

    private void RunSingle(string id)
    {
        var problem = _puzzleRepository.GetPuzzle(id);

        if (problem == null)
            throw new Exception($"The specified puzzle could not be found ({id})");

        _runner.Run(problem);
    }

    private void RunAll(Puzzles.Parameters parameters)
    {
        var allProblems = _puzzleRepository.GetPuzzles();
        var filteredProblems = new PuzzleFilter(parameters).Filter(allProblems);
        _runner.Run(filteredProblems);
    }

    private static Puzzles.Parameters ParseParameters(string[] args, string debugPuzzle) =>
        DebugMode.IsDebugMode
            ? new Puzzles.Parameters(id: debugPuzzle)
            : Puzzles.Parameters.Parse(args);
}