using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201904;

[Name("Secure Container")]
public class Aoc201904 : AocPuzzle
{
    [Puzzle("130c5099df019116c1fa98e589523b7c")]
    public int Part1(string input)
    {
        var (lowerbound, upperbound) = Parse(input);
        return new PasswordFinder().FindPart1(lowerbound, upperbound).Count();
    }

    [Puzzle("a91290a19800def81b170a8a45592c43")]
    public int Part2(string input)
    {
        var (lowerbound, upperbound) = Parse(input);
        return new PasswordFinder().FindPart2(lowerbound, upperbound).Count();
    }

    private static (int, int) Parse(string input)
    {
        var (a, b) = input.Split('-');
        return (int.Parse(a), int.Parse(b));
    }
}