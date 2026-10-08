using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Alchemical Reduction")]
public class Aoc201805 : AocPuzzle
{
    private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    [Puzzle("b0180e8fdf70d1a6cb40a7e588873a5f")]
    public int Part1(string input) => RunPart1(input).Length;

    [Puzzle("923436b9c396a53a404f30f51617b9d9")]
    public int Part2(string input) => RunPart2(input).Length;

    public string RunPart1(string input)
    {
        var charLookup = GetCharLookup();
        var list = ConvertToList(input);
        list = Reduce(charLookup, list);
        return ConvertToString(list);
    }
    
    public string RunPart2(string input)
    {
        var charLookup = GetCharLookup();
        var shortest = input;
        foreach (var c in Letters)
        {
            var character = c.ToString();
            var improved = input.Replace(character, "").Replace(character.ToLower(), "");
            var list = ConvertToList(improved);
            var reduced = Reduce(charLookup, list);

            if (reduced.Count < shortest.Length)
                shortest = ConvertToString(reduced);
        }

        return shortest;
    }

    private static Dictionary<char, char> GetCharLookup()
    {
        var uppercase = Letters.ToCharArray();
        var lowercase = Letters.ToLower().ToCharArray();

        var charLookup = new Dictionary<char, char>();
        for (var i = 0; i < lowercase.Length; i++)
        {
            charLookup.Add(lowercase[i], uppercase[i]);
            charLookup.Add(uppercase[i], lowercase[i]);
        }

        return charLookup;
    }

    private static LinkedList<char> ConvertToList(string str) => new(str.ToCharArray());
    private static string ConvertToString(LinkedList<char> list) => new(list.ToArray());

    private static LinkedList<char> Reduce(Dictionary<char, char> charLookup, LinkedList<char> list)
    {
        var length = list.Count;
        ReplaceLetters(charLookup, list);
        return list.Count != length 
            ? Reduce(charLookup, list) 
            : list;
    }

    private static void ReplaceLetters(Dictionary<char, char> charLookup, LinkedList<char> list)
    {
        var currentItem = list.First;
        var nextItem = currentItem?.Next;
        while (nextItem != null)
        {
            if (IsPair(charLookup, currentItem!.Value, nextItem.Value))
            {
                var newCurrent = nextItem.Next;
                list.Remove(currentItem);
                list.Remove(nextItem);
                currentItem = newCurrent;
                nextItem = currentItem?.Next;
            }
            else
            {
                currentItem = nextItem;
                nextItem = currentItem.Next;
            }
        }
    }

    private static bool IsPair(Dictionary<char, char> charLookup, char a, char b) => a == charLookup[b];
}