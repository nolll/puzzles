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
        foreach (var group in groups)
        {
            var name = group.Key;
            var count = group.Count();
            Printer.WriteMarkupLine($"{name}: {Printer.MarkupColor(count.ToString(), Color.Green)}");
        }
    }
}