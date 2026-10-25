using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Aquaq.Puzzles;

[Name("One is all you need")]
public class Aquaq02 : AquaqPuzzle
{
    [Puzzle("7397f491441078a2bddb62ede05a1f8c")]
    public int Solve(string input) => GetUniqueNumbers(Numbers.IntsFromString(input)).Sum();

    public IEnumerable<int> GetUniqueNumbers(IEnumerable<int> input)
    {
        var result = new List<int>();

        foreach (var i in input)
        {
            var existingIndex = result.IndexOf(i);
            if(existingIndex > -1)
                result = [.. result.Take(existingIndex)];

            result.Add(i);
        }

        return result;
    }
}