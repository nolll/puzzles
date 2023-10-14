using System.Text;

namespace Aquaq.Puzzles.Aquaq30;

public class CardFlipper
{
    private readonly Dictionary<char[], bool> _cache = new();

    public int CountValidStartingMoves(string input)
    {
        var count = 0;
        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] == '1')
            {
                var flipped = Flip(input, i);
                var canBeSolved = CanBeSolved(flipped.ToCharArray());
                if (canBeSolved)
                    count++;
            }
        }

        return count;
    }

    public static string Flip(string s, int index)
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

    public bool CanBeSolved(char[] state)
    {
        if (_cache.TryGetValue(state, out var canBeSolved))
            return canBeSolved;

        var subStates = new List<char[]>();
        for (var i = 0; i < state.Length; i++)
        {
            var c = state[i];

            if (c != '1') 
                continue;
            
            if (i > 0)
            {
                var left = state.Take(i).ToArray();
                left[^1] = FlipCard(left.Last());
                subStates.Add(left);
            }
                
            if (i < state.Length - 1)
            {
                var right = state.Skip(i + 1).ToArray();
                right[0] = FlipCard(right.First());
                subStates.Add(right);
            }
                
            if (subStates.All(CanBeSolved))
            {
                _cache.Add(state, true);
                return true;
            }
        }

        var result = !state.Contains('0');
        _cache.Add(state, result);
        return result;
    }

    private static char FlipCard(char c) => c switch
    {
        '1' => '0',
        '0' => '1',
        _ => '.'
    };
}