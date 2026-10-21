using System.Text;
using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Supply Stacks")]
public class Aoc202205 : AocPuzzle
{
    [Puzzle("9828a1b1c82b8879448ee5d92f6245f8")]
    public string Part1(string input)
    {
        var (stacks, moves) = Parse(input);
        foreach (var s in moves)
        {
            var (count, from, to) = ParseMove(s);

            for (var i = 0; i < count; i++)
            {
                var crate = stacks[from].Pop();
                stacks[to].Push(crate);
            }
        }

        return GetMessage(stacks);
    }

    [Puzzle("be487b7be9543b1de622347458714dcd")]
    public string Part2(string input)
    {
        var (stacks, moves) = Parse(input);
        foreach (var s in moves)
        {
            var (count, from, to) = ParseMove(s);

            var cratesToMove = new List<char>();
            for (var i = 0; i < count; i++) 
                cratesToMove.Add(stacks[from].Pop());

            cratesToMove.Reverse();
            foreach (var crate in cratesToMove) 
                stacks[to].Push(crate);
        }

        return GetMessage(stacks);
    }

    private static IDictionary<int, Stack<char>> ParseStacks(IEnumerable<string> lines)
    {
        var stackLines = lines.Reverse().Skip(1);
        var stacks = new Dictionary<int, Stack<char>>();
        foreach (var line in stackLines)
        {
            var stackPos = 1;
            var pos = 1;
            while (pos < line.Length)
            {
                var c = line[pos];
                if (c != ' ')
                {
                    if(!stacks.TryAdd(stackPos, new([c])))
                        stacks[stackPos].Push(c);
                }

                stackPos++;
                pos += 4;
            }
        }

        return stacks;
    }

    private static (int count, int from, int to) ParseMove(string s)
    {
        var (count, from, to) = Numbers.IntsFromString(s);
        return (count, from, to);
    }

    private static string GetMessage(IDictionary<int, Stack<char>> stacks)
    {
        var message = new StringBuilder();
        var stackNumber = 1;
        while (stacks.ContainsKey(stackNumber))
        {
            message.Append(stacks[stackNumber].Pop());
            stackNumber++;
        }

        return message.ToString();
    }

    private static (IDictionary<int, Stack<char>>, string[]) Parse(string input)
    {
        var (stacks, moves) = input.Split(LineBreaks.Double)
            .Select(o => o.Split(LineBreaks.Single))
            .ToArray();

        return (ParseStacks(stacks), moves);
    }
}