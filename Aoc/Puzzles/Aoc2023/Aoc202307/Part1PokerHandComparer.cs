namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202307;

public class Part1PokerHandComparer() : PokerHandComparer(11)
{
    public override int Compare(PokerHand? a, PokerHand? b)
    {
        if (a is null || b is null)
            return 0;

        if (a.Part1Rank != b.Part1Rank)
            return a.Part1Rank.CompareTo(b.Part1Rank);

        return Compare(a.Hand, b.Hand);
    }
}