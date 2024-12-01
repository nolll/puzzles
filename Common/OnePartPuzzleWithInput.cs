using System;
using System.Collections.Generic;

namespace Pzl.Common;

[NumberOfParts(1)]
public abstract class OnePartPuzzleWithInput : Puzzle
{
    protected abstract PuzzleResult Run(string input);

    public override IList<Func<PuzzleResult>> RunFunctions => [];
    public override IList<Func<string, PuzzleResult>> RunFunctionsWithInput => [Run];
}