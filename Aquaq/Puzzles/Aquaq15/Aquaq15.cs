using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq15;

[Name("word wore more mare maze")]
public class Aquaq15 : AquaqPuzzle
{
    [AdditionalCommonInputFile("Words.txt")]
    public PuzzleResult Run(string input, string additionalInput)
    {
        return new PuzzleResult(RunInternal(input, additionalInput), "ffafde1afff1c3904275c8225e772bf1");
    }

    public int RunInternal(string input, string additionalInput) 
    {
        var transformations = StringReader.ReadLines(input)
            .Select(o => o.Split(','))
            .Select(o => new WordTransformation(o[0], o[1]))
            .ToList();

        var wordLengths = transformations.Select(o => o.WordLength).ToList();
        var maxLength = wordLengths.Max();
        var minLength = wordLengths.Min();

        var validWords = StringReader.ReadLines(additionalInput)
            .Where(o => o.Length >= minLength && o.Length <= maxLength)
            .GroupBy(o => o.Length)
            .ToDictionary(k => k.Key, o => BuildEdges(o.ToList()).ToList());

        var product = 1;
        foreach (var transformation in transformations)
        {
            var inputs = validWords[transformation.WordLength];
            product *= Dijkstra.BestCost(inputs, transformation.From, transformation.To) + 1;
        }

        return product;
    }

    private static IEnumerable<GraphEdge> BuildEdges(List<string> validWords)
    {
        foreach (var validWord in validWords)
        {
            var similarWords = validWords.Where(o => IsSimilar(validWord, o));
            foreach (var similarWord in similarWords)
            {
                yield return new GraphEdge(validWord, similarWord);
            }
        }
    }
    
    private static bool IsSimilar(string a, string b)
    {
        var diffCount = 0;
        var length = a.Length;
        for (var i = 0; i < length; i++)
        {
            if (a[i] == b[i])
                continue;
            
            if (diffCount == 1)
                return false;

            diffCount++;
        }

        return a != b;
    }

    private record WordTransformation(string From, string To)
    {
        public int WordLength => From.Length;
    }
}