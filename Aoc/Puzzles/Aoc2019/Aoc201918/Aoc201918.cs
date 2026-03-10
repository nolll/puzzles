using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201918;

[NeedsRewrite]
[Name("Many-Worlds Interpretation")]
[Comment("Key Collector - Part 2 is too optimized. Tests fails")]
public class Aoc201918 : AocPuzzle
{
    [Puzzle("0a9fd52dc2a8f923fd89261df9e58465")]
    public PuzzleResult Part1(string input)
    {
        var keyCollector = new KeyCollector(input);
        keyCollector.Run();

        return new PuzzleResult(keyCollector.ShortestPath);
    }

    [Puzzle("f8dde84b510c969a3840ba944d60ddac")]
    public PuzzleResult Part2(string input)
    {
        var keyCollector = new KeyCollector(input, true);
        keyCollector.Run();

        return new PuzzleResult(keyCollector.ShortestPath);
    }
}