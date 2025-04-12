using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202001;

[Name("Report Repair")]
public class Aoc202001 : AocPuzzle
{
    private const int Target = 2020;
    
    public PuzzleResult Part1(string input)
    {
        var product = FindNumbersThatAddUpTo(input.Split(LineBreaks.Single).Select(int.Parse).ToList(), Target, 2).Aggregate(1, (a, b) => a * b);
        return new PuzzleResult(product, "89120e7d60fb863cc69d69128748e52d");
    }

    public PuzzleResult Part2(string input)
    {
        var product = FindNumbersThatAddUpTo(Parse(input), Target, 3).Aggregate(1, (a, b) => a * b);
        return new PuzzleResult(product, "12c4424e1149b29c37b5be950a3c5939");
    }

    private static List<int> Parse(string input) => input.Split(LineBreaks.Single).Select(int.Parse).ToList();

    private static IList<int> FindNumbersThatAddUpTo(List<int> numbers, int target, int numbersToFind) => 
        PermutationGenerator.GetPermutations(numbers, numbersToFind).First(o => o.Sum() == target).ToList();
}