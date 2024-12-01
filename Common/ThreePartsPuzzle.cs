using System;
using System.Collections.Generic;

namespace Pzl.Common;

[NumberOfParts(3)]
public abstract class ThreePartsPuzzle : Puzzle
{
    protected abstract PuzzleResult RunPart1(string input);
    protected abstract PuzzleResult RunPart2(string input);
    protected abstract PuzzleResult RunPart3(string input);

    public override IList<Func<PuzzleResult>> RunFunctions => [];
    public override IList<Func<string, PuzzleResult>> RunFunctionsWithInput => [RunPart1, RunPart2, RunPart3];
}