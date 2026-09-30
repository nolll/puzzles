using System.Text;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Signals and Noise")]
public class Aoc201606 : AocPuzzle
{
    [Puzzle("d501463dd43fdef3d85d722210ab3940")]
    public string Part1(string input) => Solve(input, GetMostCommonChar);

    [Puzzle("509675b487b1cf475001b9592fab4a95")]
    public string Part2(string input) => Solve(input, GetLeastCommonChar);

    private static char GetMostCommonChar(string chars) => 
        chars.GroupBy(o => o).MaxBy(o => o.Count())?.Key ?? ' ';
    
    private static char GetLeastCommonChar(string chars) => 
        chars.GroupBy(o => o).MinBy(o => o.Count())?.Key ?? ' ';

    private static string Solve(string input, Func<string, char> getChar)
    {
        var strings = Parse(input);
        var messageLength = strings.First().Length;
        var message = new StringBuilder();

        for (var i = 0; i < messageLength; i++)
        {
            var index = i;
            var chars = string.Concat(strings.Select(s => s[index]));
            var c = getChar(chars);
            message.Append(c);
        }

        return message.ToString();
    }

    private static List<string> Parse(string input) => 
        input.Trim().Split(LineBreaks.Single).Select(o => o.Trim()).ToList();
}