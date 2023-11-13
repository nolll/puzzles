using System.Text;

namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201604;

public class Room
{
    public int Id { get; }
    public bool IsValid { get; }
    private string EncryptedName { get; }

    public Room(string input)
    {
        var split1 = input.Split('[').ToList();
        var checksum = split1[1].Substring(0, split1[1].Length - 1);
        var sortedChecksum = string.Join('-', checksum.ToCharArray().OrderBy(o => o)).Replace("-", "");
        var split2 = split1[0].Split('-');
        Id = int.Parse(split2.Last());
        EncryptedName = string.Join('-', split2.Take(split2.Length - 1));
        var characters = EncryptedName.Replace("-", "").ToCharArray().OrderBy(o => o);
        var characterCounts = new List<CharacterCount>();
        foreach (var c in characters)
        {
            var characterCount = characterCounts.FirstOrDefault(o => o.C == c);
            if (characterCount == null)
            {
                characterCount = new CharacterCount(c);
                characterCounts.Add(characterCount);
            }

            characterCount.Increment();
        }

        var sortedCounts = characterCounts.OrderByDescending(o => o.Count).ThenBy(o => o.C);
        var charList = sortedCounts.Take(5).Select(o => o.C).OrderBy(o => o);
        var fiveString = string.Join('-', charList).Replace("-", "");
        IsValid = fiveString == sortedChecksum;
    }

    public string Name
    {
        get
        {
            var name = new StringBuilder();
            foreach (var c in EncryptedName)
            {
                if (c == '-')
                    name.Append(' ');
                else
                {
                    var newC = c + Id;
                    while (newC > 'z')
                        newC -= 26;
                    name.Append((char)newC);
                }
            }

            return name.ToString();
        }
    }
}