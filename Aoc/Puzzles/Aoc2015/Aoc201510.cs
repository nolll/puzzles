using System.Text;
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("Elves Look, Elves Say")]
public class Aoc201510 : AocPuzzle
{
    [Puzzle("1c32a9d4af561a5e8468442397ce06c0")]
    public int Part1(string input) => new LookAndSayGame(input, 40).Result.Length;

    [Puzzle("f96f3f93bd5cbf8f3cf1bcf814ba4707")]
    public int Part2(string input) => new LookAndSayGame(input, 50).Result.Length;
    
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
}