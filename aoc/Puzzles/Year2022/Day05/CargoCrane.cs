using System.Collections.Generic;
using System.Linq;
using Aoc.Common.Strings;

namespace Aoc.Puzzles.Year2022.Day05;

public class CargoCrane
{
    private IDictionary<int, Stack<char>> _stacks;
    private IList<string> _moves;
    public string Message { get; set; }

    public CargoCrane(string input)
    {
        var groups = PuzzleInputReader.ReadLineGroupsWithWhiteSpace(input);
        _stacks = ParseStacks(groups.First());
        _moves = groups[1];
    }

    public void Run1()
    {
        foreach (var s in _moves)
        {
            var (count, from, to) = ParseMove(s);

            for (var i = 0; i < count; i++)
            {
                var crate = _stacks[from].Pop();
                _stacks[to].Push(crate);
            }
        }

        Message = GetMessage();
    }

    public void Run2()
    {
        foreach (var s in _moves)
        {
            var (count, from, to) = ParseMove(s);

            var cratesToMove = new List<char>();
            for (var i = 0; i < count; i++)
            {
                cratesToMove.Add(_stacks[from].Pop());
            }

            cratesToMove.Reverse();
            foreach (var crate in cratesToMove)
            {
                _stacks[to].Push(crate);
            }
        }
        
        Message = GetMessage();
    }

    private IDictionary<int, Stack<char>> ParseStacks(IEnumerable<string> lines)
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
                    if (!stacks.ContainsKey(stackPos))
                    {
                        stacks[stackPos] = new Stack<char>();
                    }
                    stacks[stackPos].Push(c);
                }

                stackPos++;
                pos += 4;
            }
        }

        return stacks;
    }
    
    private (int count, int from, int to) ParseMove(string s)
    {
        var moveParts = s.Split(' ');
        var count = int.Parse(moveParts[1]);
        var from = int.Parse(moveParts[3]);
        var to = int.Parse(moveParts[5]);
        return (count, from, to);
    }

    private string GetMessage()
    {
        var message = "";
        var stackNumber = 1;
        while (_stacks.ContainsKey(stackNumber))
        {
            message += _stacks[stackNumber].Pop();
            stackNumber++;
        }

        return message;
    }
}