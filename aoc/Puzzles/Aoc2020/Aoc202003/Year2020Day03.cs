using System.Linq;
using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Day03;

public class Year2020Day03 : AocPuzzle
{
    public override string Name => "Toboggan Trajectory";

    protected override PuzzleResult RunPart1()
    {
        var navigator = new TreeNavigator(InputFile);
        var treeCount = navigator.GetSingleTreeCount();
        return new PuzzleResult(treeCount, 198);
    }

    protected override PuzzleResult RunPart2()
    {
        var navigator = new TreeNavigator(InputFile);
        var treeCounts = navigator.GetAllTreeCounts().ToList();
        var product = treeCounts.Aggregate((long)1, (a, b) => a * b);
        return new PuzzleResult(product, 5_140_884_672);
    }
}