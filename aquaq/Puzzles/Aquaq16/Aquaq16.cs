using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq16;

public class Aquaq16 : AquaqPuzzle
{
    private const int LetterHeight = 6;

    public override string Name => "Keming";

    protected override PuzzleResult Run()
    {
        return new PuzzleResult(Run(InputFile), 246882);
    }

    public int Run(string input)
    {
        var alphabet = ParseLetters(TextFile("Alphabet.txt"))
            .ToDictionary(k => k.Character, v => v);

        var letters = input.ToCharArray().Select(o => alphabet[o]).ToArray();
        var spaceCount = 0;
        for (var i = 0; i < letters.Length - 1; i++)
        {
            var left = letters[i];
            var right = letters[i + 1];
            var tighten = Tighten(left, right);
            spaceCount += left.SpaceCount + LetterHeight - tighten * LetterHeight;
        }

        spaceCount += letters.Last().SpaceCount;
        
        return spaceCount;
    }

    private int Tighten(Letter left, Letter right)
    {
        var commonSpaces = new List<int>();
        for (var i = 0; i < left.Rows.Count; i++)
        {
            commonSpaces.Add(left.Rows[i].RightSpace + right.Rows[i].LeftSpace);
        }

        return commonSpaces.Min();
    }

    private static IEnumerable<Letter> ParseLetters(string alphabet)
    {
        var lines = alphabet.Split(Environment.NewLine).ToArray();
        var c = 'A';
        for (var i = 0; i < alphabet.Length; i += LetterHeight)
        {
            yield return new Letter(c, lines.Skip(i).Take(6));
            c++;
        }
    }
    
    private class Letter
    {
        public char Character { get; }
        public IList<LetterRow> Rows { get; }
        public int SpaceCount { get; }

        public Letter(char character, IEnumerable<string> rows)
        {
            Character = character;
            Rows = rows.Select(o => new LetterRow(o)).ToList();
            SpaceCount = Rows.Sum(o => o.String.ToCharArray().Count(p => p == '.'));
        }
    }

    private class LetterRow
    {
        public string String { get; }
        public int LeftSpace { get; }
        public int RightSpace { get; }

        public LetterRow(string s)
        {
            String = s.Replace(' ', '.');
            LeftSpace = s.Length - s.TrimStart().Length;
            RightSpace = s.Length - s.TrimEnd().Length;
        }
    }
}
