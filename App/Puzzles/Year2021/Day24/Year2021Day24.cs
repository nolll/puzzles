using System;
using System.Collections.Generic;
using System.Linq;
using App.Platform;

namespace App.Puzzles.Year2021.Day24;

public class Year2021Day24 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var monad = new Monad2();
        var validNumbers = new List<string>();
        monad.Search(0, 0, new int[14], validNumbers);
        validNumbers = validNumbers.OrderByDescending(o => o).ToList();
        var result = validNumbers.First();

        return new PuzzleResult(result);
    }

    public override PuzzleResult RunPart2()
    {
        return new PuzzleResult(0);
    }
}