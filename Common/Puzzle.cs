using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pzl.Common;

public abstract class Puzzle(string? input = null, string? additionalInput = null)
{
    protected readonly string Input = input ?? string.Empty;
    protected readonly string AdditionalInput = additionalInput ?? string.Empty;

    public abstract IList<Func<PuzzleResult>> RunFunctions { get; }
}