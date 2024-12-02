using Pzl.Common;

namespace Pzl.Client.Running.Runners;

public class PuzzleInstance(Puzzle puzzle, PuzzleFunction[] funcs)
{
    public Puzzle Puzzle { get; } = puzzle;
    public PuzzleFunction[] Funcs { get; } = funcs;
}