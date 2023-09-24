using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Aoc.Puzzles.Aoc2015.Aoc201510;

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

    private static string GenerateString(Part part)
    {
        return $"{part.Count}{part.Character}";
    }

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

    private IList<Part> GetPartsWithRegex(string s)
    {
        var regex = new Regex("(.)\\1*");
        var matches = regex.Matches(s);

        var parts = new List<Part>();
        foreach (var match in matches)
        {
            var v = match.ToString()!;
            var part = new Part(v[0], v.Length);
            parts.Add(part);
        }

        return parts;
    }

    private class Part
    {
        public char Character { get; }
        public int Count { get; set; }

        public Part(char character)
        {
            Character = character;
            Count = 0;
        }

        public Part(char character, int count)
        {
            Character = character;
            Count = count;
        }
    }
}