using System.Collections.Generic;
using System.Text;

namespace App.Puzzles.Year2015.Day10;

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
        var parts = GetParts(s);
        var str = GenerateString(parts);
        return NextString(str, iteration + 1);
    }

    private string GenerateString(IList<Part> parts)
    {
        var sb = new StringBuilder();
        foreach (var part in parts)
        {
            sb.Append(GenerateString(part));
        }

        return sb.ToString();
    }

    private string GenerateString(Part part)
    {
        return $"{part.Count}{part.Character}";
    }

    private IList<Part> GetParts(string s)
    {
        var parts = new List<Part>();
        Part currentPart = null;
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

    private class Part
    {
        public char Character { get; }
        public int Count { get; set; }

        public Part(char character)
        {
            Character = character;
            Count = 0;
        }
    }
}