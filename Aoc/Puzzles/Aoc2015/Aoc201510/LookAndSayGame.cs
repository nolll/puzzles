using System.Text;
using System.Text.RegularExpressions;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201510;

public class LookAndSayGame
{
    private readonly int _iterations;
    public string Result { get; }

    public LookAndSayGame(string input, int iterations)
    {
        _iterations = iterations;
        Result = NextString(input, 0);
    }

    private string NextString(string s, int iteration)
    {
        if (iteration >= _iterations)
            return s;
        var parts = GetPartsWithLoop(s);
        var str = GenerateString(parts);
        return NextString(str, iteration + 1);
    }

    private static string GenerateString(IEnumerable<Part> parts)
    {
        var sb = new StringBuilder();
        foreach (var part in parts)
        {
            sb.Append(GenerateString(part));
        }

        return sb.ToString();
    }

    private static string GenerateString(Part part) => $"{part.Count}{part.Character}";

    private static IList<Part> GetPartsWithLoop(string s)
    {
        var parts = new List<Part>();
        Part? currentPart = null;
        foreach (var c in s)
        {
            if (currentPart == null || c != currentPart.Character)
            {
                currentPart = new Part(c);
                parts.Add(currentPart);
            }

            currentPart.Count++;
        }

        return parts;
    }

    private class Part(char character)
    {
        public char Character { get; } = character;
        public int Count { get; set; } = 0;
    }
}