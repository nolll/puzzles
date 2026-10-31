using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Rankening")]
public class Ece202604 : EverybodyEventPuzzle
{
    [Puzzle("5cba4da390def1689ad3d5ff54693631")]
    public int Part1(string input) => GetResultsPart1And2(input)
        .OrderBy(o => o.Value.Time)
        .Select((o, i) => (i + 1) * o.Value.Time)
        .Sum();

    [Puzzle("efe20da86e661914acf4ae30036a77d4")]
    public int Part2(string input) => GetResultsPart1And2(input)
        .OrderByDescending(o => o.Value.Parts)
        .ThenBy(o => o.Value.Time)
        .Select((o, i) => (i + 1) * o.Value.Time)
        .Sum();

    private Dictionary<int, Player> GetResultsPart1And2(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var dictionary = new Dictionary<int, Player>();
        foreach (var line in lines)
        {
            var (id, _, _, time) = Numbers.IntsFromString(line);
            if (!dictionary.ContainsKey(id)) 
                dictionary.Add(id, new Player());
            
            dictionary[id].Parts += 1;
            dictionary[id].Time += time;
        }

        return dictionary;
    }

    [Puzzle("")]
    public int Part3(string input)
    {
        return 0;
    }

    private class Player
    {
        public int Parts { get; set; }
        public int Time { get; set; }
    }
}