using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq15;

[AdditionalCommonInputFile("Words.txt")]
[Name("word wore more mare maze")]
public class Aquaq15(string input, string additionalInput) : AquaqPuzzle
{
    protected override PuzzleResult Run()
    {
        return new PuzzleResult(Run(input), "ffafde1afff1c3904275c8225e772bf1");
    }

    public int Run(string input2) 
    {
        var transformations = StringReader.ReadLines(input2)
            .Select(o => o.Split(','))
            .Select(o => new WordTransformation(o[0], o[1]))
            .ToList();

        var wordLengths = transformations.Select(o => o.WordLength).ToList();
        var maxLength = wordLengths.Max();
        var minLength = wordLengths.Min();

        var validWords = StringReader.ReadLines(additionalInput)
            .Where(o => o.Length >= minLength && o.Length <= maxLength)
            .GroupBy(o => o.Length)
            .ToDictionary(k => k.Key, o => BuildInputs(o.ToList()).ToList());

        var product = 1;
        foreach (var transformation in transformations)
        {
            var inputs = validWords[transformation.WordLength];
            product *= Graph.GetLowestCost(inputs, transformation.From, transformation.To) + 1;
        }

        return product;
    }

    private static IEnumerable<Graph.Input> BuildInputs(List<string> validWords)
    {
        var length = validWords.First().Length;
        foreach (var validWord in validWords)
        {
            var similarWords = validWords.Where(o => IsSimilar(validWord, o));
            foreach (var similarWord in similarWords)
            {
                yield return new Graph.Input(validWord, similarWord);
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