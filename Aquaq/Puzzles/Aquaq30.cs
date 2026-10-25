using System.Text;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles;

[Name("Flip Out")]
public class Aquaq30 : AquaqPuzzle
{
    [Puzzle("a7ac2d6ffdd2d7759b9d51599832deae")]
    public int Solve(string input)
    {
        var cache = new Dictionary<char[], bool>();
        return input.Split(LineBreaks.Single).Sum(o => CountValidStartingMoves(cache, o));
    }

    public int CountValidStartingMoves(Dictionary<char[], bool> cache, string input)
    {
        var count = 0;
        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] != '1')
                continue;

            var flipped = Flip(input, i);
            var canBeSolved = CanBeSolved(cache, flipped.ToCharArray());
            if (canBeSolved)
                count++;
        }

        return count;
    }

    public string Flip(string s, int index)
    {
        var modified = new StringBuilder();
        for (var i = 0; i < s.Length; i++)
        {
            if (i == index)
                modified.Append('.');
            else if (i == index - 1 || i == index + 1)
                modified.Append(FlipCard(s[i]));
            else
                modified.Append(s[i]);
        }

        return modified.ToString();
    }

    public bool CanBeSolved(Dictionary<char[], bool> cache, char[] state)
    {
        if (cache.TryGetValue(state, out var canBeSolved))
            return canBeSolved;

        if (state.Contains('1'))
        {
            for (var i = 0; i < state.Length; i++)
            {
                var subStates = new List<char[]>();
                var c = state[i];

                if (c != '1')
                    continue;

                if (i > 0)
                    subStates.Add(TakeLeftAndFlipLast(state, i));

                if (i < state.Length - 1)
                    subStates.Add(TakeRightAndFlipFirst(state, i));

                var r = subStates.All(state1 => CanBeSolved(cache, state1));
                cache.Add(state, r);
                return r;
            }

            return false;
        }

        var result = !state.Contains('0');
        cache.Add(state, result);
        return result;
    }

    private static char[] TakeLeftAndFlipLast(IEnumerable<char> state, int index)
    {
        var left = state.Take(index).ToArray();
        left[^1] = FlipCard(left.Last());
        return left;
    }

    private static char[] TakeRightAndFlipFirst(IEnumerable<char> state, int index)
    {
        var right = state.Skip(index + 1).ToArray();
        right[0] = FlipCard(right.First());
        return right;
    }

    private static char FlipCard(char c) => c switch
    {
        '1' => '0',
        '0' => '1',
        _ => '.'
    };
}