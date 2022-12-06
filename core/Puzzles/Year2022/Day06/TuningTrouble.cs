using System.Linq;

namespace Core.Puzzles.Year2022.Day06;

internal static class TuningTrouble
{
    public static int FindMarker(string input)
    {
        return Find(input, 4);
    }

    public static int FindMessage(string input)
    {
        return Find(input, 14);
    }

    private static int Find(string input, int searchLength)
    {
        for (var i = searchLength; i < input.Length; i++)
        {
            var s = input[(i - searchLength)..i];
            var a = s.ToCharArray();
            var d = a.Distinct();
            if (d.Count() == searchLength)
            {
                return i;
            }
        }

        return 0;
    }
}