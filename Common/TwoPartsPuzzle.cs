using System;
using System.Collections.Generic;

namespace Pzl.Common;

[NumberOfParts(2)]
public abstract class TwoPartsPuzzle : Puzzle
{
    protected abstract PuzzleResult RunPart1(string input);
    protected abstract PuzzleResult RunPart2(string input);

    public override IList<Func<PuzzleResult>> RunFunctions => [];
    public override IList<Func<string, PuzzleResult>> RunFunctionsWithInput => [RunPart1, RunPart2];
}