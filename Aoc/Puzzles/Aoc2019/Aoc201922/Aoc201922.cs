using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201922;

[NeedsRewrite]
[Name("Slam Shuffle")]
[Comment("Learn more math")]
public class Aoc201922 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var shuffler1 = new CardShuffler();
        var deck = shuffler1.Shuffle(10_007, input);
        var positionOfCard2019 = deck.IndexOf(2019);
        return new PuzzleResult(positionOfCard2019, "40fa2fae9a8a1308387285c95b7d3844");
    }

    public PuzzleResult RunPart2(string input)
    {
        var shuffler2 = new CardShuffler();
        var cardAtPosition2020 = shuffler2.ShuffleBig(input);
        return new PuzzleResult((long)cardAtPosition2020, "19df07b5230d776df66b9378ef69dfc8");
    }
}