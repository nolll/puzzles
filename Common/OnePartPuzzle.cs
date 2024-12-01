using System;
using System.Collections.Generic;

namespace Pzl.Common;

[NumberOfParts(1)]
public abstract class OnePartPuzzle : Puzzle
{
    protected abstract PuzzleResult Run(string input);

    public override IList<Func<string, PuzzleResult>> RunFunctions => [Run];
}