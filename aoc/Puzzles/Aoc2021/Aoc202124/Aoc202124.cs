using System.Collections.Generic;
using System.Linq;
using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202124;

public class Aoc202124 : AocPuzzle
{
    private List<string>? _validNumbers;
    
    private List<string> ValidNumbers
    {
        get
        {
            if (_validNumbers == null)
            {
                _validNumbers = new List<string>();
                var monad = new Monad();
                monad.Search(0, 0, new int[14], _validNumbers);
                _validNumbers = _validNumbers.OrderBy(o => o).ToList();
            }

            return _validNumbers;
        }
    }

    private long SmallestValidNumber => long.Parse(ValidNumbers.First());
    private long LargestValidNumber => long.Parse(ValidNumbers.Last());

    public override string Name => "Arithmetic Logic Unit";

    protected override PuzzleResult RunPart1()
    {
        var result = LargestValidNumber;

        return new PuzzleResult(result, "e513806c32f88d6227c6a529844981ef");
    }

    protected override PuzzleResult RunPart2()
    {
        var result = SmallestValidNumber;

        return new PuzzleResult(result, "aa756b55fecfa23d098754af71fcc02a");
    }
}