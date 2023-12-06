namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202020;

public class TopEdgeMatcher : EdgeMatcher
{
    protected override string Edge => "top";

    public TopEdgeMatcher(string edgeToMatch) : base(edgeToMatch)
    {
    }
}