namespace Puzzles.Common.Strings;

public static class LevenshteinDistance
{
    // Calculates similarity of strings. Shorter distance means more similar strings.
    // Algorithm from https://www.dotnetperls.com/levenshtein
    public static int Compute(string s, string t)
    {
        var n = s.Length;
        var m = t.Length;
        var d = new int[n + 1, m + 1];

        // Verify arguments
        if (n == 0)
            return m;

        if (m == 0)
            return n;

        // Initialize arrays
        for (var i = 0; i <= n; d[i, 0] = i++)
        {
        }

        for (var j = 0; j <= m; d[0, j] = j++)
        {
        }

        // Begin looping
        for (var i = 1; i <= n; i++)
        {
            for (var j = 1; j <= m; j++)
            {
                // Compute cost
                var cost = t[j - 1] == s[i - 1]
                    ? 0 
                    : 1;
                    
                d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
            }
        }

        // Return cost
        return d[n, m];
    }
}