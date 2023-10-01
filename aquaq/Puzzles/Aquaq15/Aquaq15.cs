using Common.Puzzles;
using Common.Strings;

namespace Aquaq.Puzzles.Aquaq15;

public class Aquaq15 : AquaqPuzzle
{
    public override string Name => "word wore more mare maze";

    protected override PuzzleResult Run()
    {
        return new PuzzleResult(Run(InputFile));
    }

    public int Run(string input)
    {
        var validWords = TextFile("ValidWords.txt").Split(Environment.NewLine);
        var transformations = input.Split(Environment.NewLine)
            .Select(o => o.Split(','))
            .Select(o => new WordTransformation(o[0], o[1]))
            .ToList();

        var product = 1;
        foreach (var transformation in transformations)
        {
            var n = PerformTransformation(transformation, validWords);
            //Console.WriteLine();
            //Console.WriteLine($"{transformation.From}-{transformation.To}: {n}");

            product *= n;
        }

        return product;
    }

    private static int PerformTransformation(WordTransformation transformation, IEnumerable<string> validWords)
    {
        var visited = new List<string>();
        var vw = validWords.Where(o => o.Length == transformation.From.Length).ToArray();

        return FindShortestPath(transformation, vw, visited, 1);
    }

    private static int FindShortestPath(
        WordTransformation transformation,
        string[] validWords,
        List<string> visited,
        int stepCount)
    {
        if (transformation.To == transformation.From)
        {
            return stepCount;
        }

        var requiredMatchingChars = CountMatchingChars(transformation.From, transformation.To) + 1;

        var similarWords = validWords
            .Where(o => !visited.Contains(o) &&
                        CountMatchingChars(transformation.To, o) == requiredMatchingChars)
            .ToList();

        if (!similarWords.Any())
            return int.MaxValue;

        var newVisited = visited.ToList();
        newVisited.Add(transformation.From);
        var results = new List<int>();
        foreach (var similarWord in similarWords)
        {
            results.Add(FindShortestPath(transformation with { From = similarWord }, validWords, newVisited, stepCount + 1));
        }

        return results.Min();
    }

    private static int CountMatchingChars(string a, string b) => a.Where((c, i) => c == b[i]).Count();

    private record WordTransformation(string From, string To);
}
