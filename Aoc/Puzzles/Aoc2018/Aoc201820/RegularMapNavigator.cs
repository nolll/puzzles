using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201820;

public class RegularMapNavigator
{
    private readonly Grid<char> _map;
    private readonly IDictionary<Coord, int> _distances;

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

    public int MostDoors { get; }
    public int RoomsMoreThat1000DoorsAway { get; }

    public RegularMapNavigator(string input)
    {
        MostDoors = 0;
        const int size = 220;
        const int start = size / 2;
        _map = new Grid<char>(size, size, Chars.Wall);
        _distances = new Dictionary<Coord, int>();
        var startAddress = new Coord(start, start);
        _map.MoveTo(startAddress);
        BuildMap(input);
        MostDoors = _distances.Values.MaxBy(o => o);
        RoomsMoreThat1000DoorsAway = _distances.Values.Count(o => o >= 1000);
    }
        
    private void BuildMap(string input)
    {
        input = input.TrimEnd(Chars.End).TrimStart(Chars.Start);
        _distances[_map.Coord] = 0;
        _map.WriteValue(Chars.Room);
        var queue = new Stack<Coord>();
        foreach (var c in input)
        {
            if (c == Chars.GroupStart)
                queue.Push(_map.Coord);
            else if (c == Chars.GroupEnd)
                _map.MoveTo(queue.Pop());
            else if (c == Chars.Next)
                _map.MoveTo(queue.Peek());
            else
                Move(c);
        }
    }

    private void Move(char c)
    {
        var lastDistance = _distances[_map.Coord];
        var move = GetMoveFunc(c);
        move();
        _map.WriteValue(Chars.Room);
        move();
        if (_map.ReadValue() == Chars.Wall)
        {
            _map.WriteValue(Chars.Room);
        }

        var distance = lastDistance + 1;
        _distances[_map.Coord] = _distances.TryGetValue(_map.Coord, out var existingDistance)
            ? Math.Min(distance, existingDistance)
            : distance;
    }

    private Action GetMoveFunc(char c)
    {
        return c switch
        {
            Chars.North => MoveNorth,
            Chars.East => MoveEast,
            Chars.South => MoveSouth,
            _ => MoveWest
        };
    }

    private void MoveNorth() => _map.MoveUp();
    private void MoveEast() => _map.MoveRight();
    private void MoveSouth() => _map.MoveDown();
    private void MoveWest() => _map.MoveLeft();
}