namespace Pzl.Client.Filter;

public class SlowPuzzleInTest : PuzzleInTest
{
    public override string Name => "Slow Puzzle";
    public override bool IsSlow => true;
}