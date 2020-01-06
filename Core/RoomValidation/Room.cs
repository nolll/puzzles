using System.Collections.Generic;
using System.Linq;

namespace Core.RoomValidation
{
    public class Room
    {
        public int Id { get; }
        public bool IsValid { get; }

        public Room(string input)
        {
            var split1 = input.Split('[').ToList();
            var checksum = split1[1].Substring(0, split1[1].Length - 1);
            var sortedChecksum = string.Join('-', checksum.ToCharArray().OrderBy(o => o)).Replace("-", "");
            var split2 = split1[0].Split('-');
            Id = int.Parse(split2.Last());
            var encryptedName = string.Join('-', split2.Take(split2.Length - 1)).Replace("-", "");
            var characters = encryptedName.ToCharArray().OrderBy(o => o);
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
    }
}