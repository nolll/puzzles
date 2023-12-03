using Puzzles.Common.Puzzles;

namespace Puzzles.Aquaq.Puzzles.Aquaq02;

public class Aquaq02 : AquaqPuzzle
{
    public override string Name => "One is all you need";

    protected override PuzzleResult Run()
    {
        var input = InputFile.Split(' ').Select(int.Parse);
        var uniqueNumbers = GetUniqueNumbers(input);

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