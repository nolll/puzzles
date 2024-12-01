using System;
using System.Collections.Generic;

namespace Pzl.Common;

public abstract class Puzzle
{
    public abstract IList<Func<PuzzleResult>> RunFunctions { get; }
    public abstract IList<Func<string, PuzzleResult>> RunFunctionsWithInput { get; }
}