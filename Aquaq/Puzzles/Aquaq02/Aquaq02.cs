using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq02;

[Name("One is all you need")]
public class Aquaq02 : AquaqPuzzle
{
    protected override PuzzleResult Run(string input)
    {
        var input2 = input.Split(' ').Select(int.Parse);
        var uniqueNumbers = GetUniqueNumbers(input2);

        return new PuzzleResult(uniqueNumbers.Sum(), "7397f491441078a2bddb62ede05a1f8c");
    }

    public static IEnumerable<int> GetUniqueNumbers(IEnumerable<int> input)
    {
        var result = new List<int>();

        foreach (var i in input)
        {
            var existingIndex = result.IndexOf(i);
            if(existingIndex > -1)
                result = result.Take(existingIndex).ToList();

            result.Add(i);
        }

        return result;
    }
}