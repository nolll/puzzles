using Pzl.Common;
using Pzl.Tools.Chars;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("A Regular Map")]
public class Aoc201820 : AocPuzzle
{
    [Puzzle("83076f3a8aaf1a87fab2dcf2ecc1d1ea")]
    public int Part1(string input) => GetDistances(input).Values.MaxBy(o => o);

    [Puzzle("500a039b53fddc7bdd70781ce0f8df5a")]
    public int Part2(string input) => GetDistances(input).Values.Count(o => o >= 1000);

    private static IDictionary<Coord, int> GetDistances(string input)
    {
        const int size = 220;
        const int start = size / 2;
        var startAddress = new Coord(start, start);
        var map = new Grid<char>(size, size, Chars.Wall);
        var distances = new Dictionary<Coord, int>();
        map.MoveTo(startAddress);

        input = input.TrimEnd(Chars.End).TrimStart(Chars.Start);
        distances[map.Coord] = 0;
        map.WriteValue(Chars.Room);
        var queue = new Stack<Coord>();
        foreach (var c in input)
        {
            if (c == Chars.GroupStart)
                queue.Push(map.Coord);
            else if (c == Chars.GroupEnd)
                map.MoveTo(queue.Pop());
            else if (c == Chars.Next)
                map.MoveTo(queue.Peek());
            else
                Move(map, distances, c);
        }

        return distances;
    }

    private static void Move(Grid<char> map, Dictionary<Coord, int> distances, char c)
    {
        var lastDistance = distances[map.Coord];
        var move = GetMoveFunc(c);
        move(map);
        map.WriteValue(Chars.Room);
        move(map);
        if (map.ReadValue() == Chars.Wall)
        {
            map.WriteValue(Chars.Room);
        }

        var distance = lastDistance + 1;
        distances[map.Coord] = distances.TryGetValue(map.Coord, out var existingDistance)
            ? Math.Min(distance, existingDistance)
            : distance;
    }

    private static Action<Grid<char>> GetMoveFunc(char c) => c switch
    {
        Chars.North => map => map.MoveUp(),
        Chars.East => map => map.MoveRight(),
        Chars.South => map => map.MoveDown(),
        _ => map => map.MoveLeft()
    };
    
    private static class Chars
    {
        public const char Start = '^';
        public const char End = '$';
        public const char North = 'N';
        public const char East = 'E';
        public const char South = 'S';
        public const char Room = '.';
        public const char Wall = '#';
        public const char Next = '|';
        public const char GroupStart = '(';
        public const char GroupEnd = ')';
    }
}