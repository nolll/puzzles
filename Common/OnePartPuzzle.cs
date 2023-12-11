﻿using System;
using System.Collections.Generic;

namespace Pzl.Common;

[NumberOfParts(1)]
public abstract class OnePartPuzzle(string? input = null) : Puzzle(input)
{
    protected abstract PuzzleResult Run();

    public override IList<Func<PuzzleResult>> RunFunctions =>
        new List<Func<PuzzleResult>> { Run };
}