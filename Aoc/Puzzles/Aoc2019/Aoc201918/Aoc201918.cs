using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201918;

[NeedsRewrite]
[Name("Many-Worlds Interpretation")]
[Comment("Key Collector - Part 2 is too optimized. Tests fails")]
public class Aoc201918 : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var keyCollector = new KeyCollector(InputFile);
        keyCollector.Run();

        return new PuzzleResult(keyCollector.ShortestPath, "0a9fd52dc2a8f923fd89261df9e58465");
    }

    protected override PuzzleResult RunPart2()
    {
        var keyCollector = new KeyCollector(InputFile, true);
        keyCollector.Run();

        return new PuzzleResult(keyCollector.ShortestPath, "f8dde84b510c969a3840ba944d60ddac");
    }
}