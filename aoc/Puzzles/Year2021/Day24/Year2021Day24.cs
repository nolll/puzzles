using System.Collections.Generic;
using System.Linq;
using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day24;

public class Year2021Day24 : AocPuzzle
{
    private List<string> _validNumbers;
    
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

    public override string Title => "Arithmetic Logic Unit";

    public override PuzzleResult RunPart1()
    {
        var result = LargestValidNumber;

        return new PuzzleResult(result, 91398299697996);
    }

    public override PuzzleResult RunPart2()
    {
        var result = SmallestValidNumber;

        return new PuzzleResult(result, 41171183141291);
    }
}