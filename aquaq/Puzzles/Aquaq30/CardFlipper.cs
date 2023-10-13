namespace Aquaq.Puzzles.Aquaq30;

public class CardFlipper
{
    private Dictionary<char[], bool> _cache = new();

    public string Flip(string s, int index)
    {
        var modified = "";
        for (var i = 0; i < s.Length; i++)
        {
            if (i == index)
            {
                modified += '.';
            }
            else if (i == index - 1 || i == index + 1)
            {
                if (s[i] == '1')
                    modified += '0';
                else if (s[i] == '0')
                    modified += '1';
                else
                    modified += '.';
            }
            else
            {
                modified += s[i];
            }

        }

        return modified;
    }

    public bool CanBeSolved(char[] state)
    {
        if (_cache.TryGetValue(state, out var canBeSolved))
            return canBeSolved;

        var foundZero = false;

        var subStates = new List<char[]>();
        for (var i = 0; i < state.Length; i++)
        {
            var c = state[i];
            if (c == '0')
                foundZero = true;

            if (c == '1')
            {
                var left = state.Take(i).ToArray();
                if (left.Length > 0)
                {
                    var lastChar = left.Last();
                    if (lastChar == '1')
                        left[^1] = '0';
                    else if (lastChar == '0')
                        left[^1] = '1';
                }
                var right = state.Skip(i + 1).ToArray();
                if (right.Length > 0)
                {
                    var firstChar = right.Last();
                    if (firstChar == '1')
                        right[0] = '0';
                    else if (firstChar == '0')
                        right[0] = '1';
                }

                if (left.Any())
                    subStates.Add(left);

                if (right.Any())
                    subStates.Add(right);

                if (subStates.All(CanBeSolved))
                {
                    _cache.Add(state, true);
                    return true;
                }
            }
        }

        var result = !foundZero;
        _cache.Add(state, result);
        return !foundZero;
    }
}