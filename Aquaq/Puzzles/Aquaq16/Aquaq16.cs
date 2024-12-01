using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq16;

[AdditionalLocalInputFile("Alphabet.txt")]
[Name("Keming")]
public class Aquaq16(string additionalInput) : AquaqPuzzle
{
    private const int LetterHeight = 6;

    public PuzzleResult Run(string input)
    {
        return new PuzzleResult(RunInternal(input), "b900eb74f94c2243de65005bcc4ebd2c");
    }
    
    public int RunInternal(string input2)
    {
        var alphabet = ParseLetters(additionalInput)
            .ToDictionary(k => k.Character, v => v);

        var letters = input2.ToCharArray().Select(o => alphabet[o]).ToArray();
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

    private static int Tighten(Letter left, Letter right)
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
        var lines = StringReader.ReadLines(alphabet).ToArray();
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
