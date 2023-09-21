using AquaQ.Platform;
using common.Puzzles;

namespace AquaQ.Challenges.Challenge03;

public class Challenge03 : AquaQPuzzle
{
    public override string Name => "One is all you need";

    public override PuzzleResult Run()
    {
        var input = FileInput.Split(' ').Select(int.Parse);
        var uniqueNumbers = GetUniqueNumbers(input);

        return new PuzzleResult(uniqueNumbers.Sum(), 321);
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