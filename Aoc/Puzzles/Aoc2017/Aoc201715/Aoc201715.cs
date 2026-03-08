using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201715;

[Name("Dueling Generators")]
public class Aoc201715 : AocPuzzle
{
    [Puzzle("4eda86461504e63d609bceb54bbafa32")]
    public int Part1(string input)
    {
        var duel = GeneratorDuel.Parse(input);
        duel.Run(40_000_000);
        return duel.FinalCount;
    }

    [Puzzle("0e673f0bbb3b57c839d9267b2231a741")]
    public int Part2(string input)
    {
        var duel = GeneratorDuel.Parse(input);
        duel.Run2(5_000_000);
        return duel.FinalCount;
    }
}