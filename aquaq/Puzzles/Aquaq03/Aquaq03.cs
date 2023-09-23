﻿using Aquaq.Platform;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq03;

public class Aquaq03 : AquaqPuzzle
{
    public override string Name => "Short walks";

    public override PuzzleResult Run()
    {
        var walker = new Walker();
        var result = walker.Walk(FileInput);

        return new PuzzleResult(result, 2543);
    }
}