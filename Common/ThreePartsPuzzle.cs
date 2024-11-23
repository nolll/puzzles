using System;
using System.Collections.Generic;

namespace Pzl.Common;

[NumberOfParts(3)]
public abstract class ThreePartsPuzzle : Puzzle
{
    protected abstract PuzzleResult RunPart1();
    protected abstract PuzzleResult RunPart2();
    protected abstract PuzzleResult RunPart3();

    public override IList<Func<PuzzleResult>> RunFunctions =>
        new List<Func<PuzzleResult>> { RunPart1, RunPart2, RunPart3 };
}