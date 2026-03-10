using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202124;

[Name("Arithmetic Logic Unit")]
public class Aoc202124 : AocPuzzle
{
    private List<string> ValidNumbers
    {
        get
        {
            if (field == null)
            {
                field = [];
                var monad = new Monad();
                monad.Search(0, 0, new int[14], field);
                field = field.OrderBy(o => o).ToList();
            }

            return field;
        }
    }

    private long SmallestValidNumber => long.Parse(ValidNumbers.First());
    private long LargestValidNumber => long.Parse(ValidNumbers.Last());

    [Puzzle("e513806c32f88d6227c6a529844981ef")]
    public PuzzleResult Part1(string input)
    {
        var result = LargestValidNumber;

        return new PuzzleResult(result);
    }

    [Puzzle("aa756b55fecfa23d098754af71fcc02a")]
    public PuzzleResult Part2(string input)
    {
        var result = SmallestValidNumber;

        return new PuzzleResult(result);
    }
}