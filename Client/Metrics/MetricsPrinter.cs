using Pzl.Client.Running.Runners;
using Spectre.Console;

namespace Pzl.Client.Metrics;

public class MetricsPrinter(PuzzleRepository puzzleRepository)
{
    public void Print()
    {
        var puzzles = puzzleRepository.GetPuzzles();
        var groups = puzzles.GroupBy(o => o.PuzzleType.Name);
        
        Printer.WriteMarkupLine(Printer.MarkupColor("Puzzle Metrics", Color.DarkTurquoise));
        Console.WriteLine();

        Printer.WriteMarkupLine(Printer.MarkupColor("Number of puzzles:", Color.DarkTurquoise));
        var totalPuzzleCount = 0;
        var totalPartsCount = 0;
        foreach (var group in groups)
        {
            var name = group.Key;
            var puzzleCount = group.Count();
            totalPuzzleCount += puzzleCount;
            var partsCount = group.SelectMany(PuzzleFactory.GetPuzzleFuncs).Count();
            totalPartsCount += partsCount;
            var puzzleCountMarkup = Printer.MarkupColor(puzzleCount.ToString(), Color.Green);
            var partsCountMarkup = Printer.MarkupColor(partsCount.ToString(), Color.Green);
            
            Printer.WriteMarkupLine($"{name}: {puzzleCountMarkup} puzzles, {partsCountMarkup} parts");
        }

        Console.WriteLine(string.Concat(Enumerable.Repeat<string>("-", 40)));
        Printer.WriteMarkupLine($"Total: {totalPuzzleCount} puzzles, {totalPartsCount} parts");
    }
}