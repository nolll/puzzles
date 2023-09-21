using System.Linq;
using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2020.Day03;

public class Year2020Day03 : AocPuzzle
{
    public override string Name => "Toboggan Trajectory";

    public override PuzzleResult RunPart1()
    {
        var navigator = new TreeNavigator(FileInput);
        var treeCount = navigator.GetSingleTreeCount();
        return new PuzzleResult(treeCount, 198);
    }

    public override PuzzleResult RunPart2()
    {
        var navigator = new TreeNavigator(FileInput);
        var treeCounts = navigator.GetAllTreeCounts().ToList();
        var product = treeCounts.Aggregate((long)1, (a, b) => a * b);
        return new PuzzleResult(product, 5_140_884_672);
    }
}