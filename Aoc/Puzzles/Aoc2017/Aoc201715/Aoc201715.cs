using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201715;

[Name("Dueling Generators")]
public class Aoc201715 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var duel = GeneratorDuel.Parse(input);
        duel.Run(40_000_000);
        return new PuzzleResult(duel.FinalCount, "4eda86461504e63d609bceb54bbafa32");
    }

    public PuzzleResult RunPart2(string input)
    {
        var duel2 = GeneratorDuel.Parse(input);
        duel2.Run2(5_000_000);
        return new PuzzleResult(duel2.FinalCount, "0e673f0bbb3b57c839d9267b2231a741");
    }
}