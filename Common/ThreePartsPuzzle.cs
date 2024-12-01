using System;
using System.Collections.Generic;

namespace Pzl.Common;

[NumberOfParts(3)]
public abstract class ThreePartsPuzzle : Puzzle
{
    public abstract PuzzleResult RunPart1(string input);
    public abstract PuzzleResult RunPart2(string input);
    public abstract PuzzleResult RunPart3(string input);

    public override IList<Func<string, PuzzleResult>> RunFunctions => [RunPart1, RunPart2, RunPart3];
}