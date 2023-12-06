using System;
using System.Collections.Generic;

namespace Pzl.Common;

public abstract class TwoPartsPuzzle : Puzzle
{
    protected abstract PuzzleResult RunPart1();
    protected abstract PuzzleResult RunPart2();

    public override IList<Func<PuzzleResult>> RunFunctions =>
        new List<Func<PuzzleResult>> { RunPart1, RunPart2 };
}