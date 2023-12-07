namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202307;

public class Part2PokerHandComparer() : PokerHandComparer(1)
{
    public override int Compare(PokerHand? a, PokerHand? b)
    {
        if (a is null || b is null)
            return 0;

        if (a.Part2Rank != b.Part2Rank)
            return a.Part2Rank.CompareTo(b.Part2Rank);

        return Compare(a.Hand, b.Hand);
    }
}