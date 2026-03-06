using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ecs03.Ecs0302;

[Name("How Quack Echoes Back")]
public class Ecs0302 : EverybodyStoryPuzzle
{
    private const char Visited = '+';
    private const char Current = '@';
    private const char Empty = '.';
    private const char Bone = '#';

    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input, Empty);
        var start = grid.FindAddresses(Current).First();
        var end = grid.FindAddresses(Bone).First();
        grid.MoveTo(start);
        grid.WriteValue(Visited);
        grid.TurnTo(GridDirection.Up);
        var stepCount = 0;

        while (grid.Coord != end)
        {
            stepCount++;
            while (true)
            {
                grid.MoveForward();
                if (grid.ReadValue() == Visited)
                {
                    grid.MoveBackward();
                    grid.TurnRight();
                    continue;
                }

                break;
            }
            
            grid.WriteValue(Visited);
            grid.TurnRight();
        }
        
        return new PuzzleResult(stepCount, "38aac781a486c5ca9eb6efe32f529b4e");
    }

    public PuzzleResult Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input, Empty);
        var start = grid.FindAddresses(Current).First();
        var end = grid.FindAddresses(Bone).First();
        grid.MoveTo(start);
        grid.WriteValue(Visited);
        grid.WriteValueAt(end, Visited);
        grid.TurnTo(GridDirection.Up);
        var stepCount = 0;
        
        var endAdjCoords = grid.PossibleOrthogonalAdjacentCoordsTo(end).ToList();

        while (endAdjCoords.Any(o => grid.ReadValueAt(o) != Visited))
        {
            stepCount++;
         
            while (true)
            {
                grid.MoveForward();
                if (grid.ReadValue() == Visited)
                {
                    grid.MoveBackward();
                    grid.TurnRight();
                    continue;
                }

                break;
            }

            grid.WriteValue(Visited);
            var adj = grid.PossibleOrthogonalAdjacentCoords;
            foreach (var a in adj)
            {
                var ort = grid.OrthogonalAdjacentValuesTo(a);
                if(ort.Count == 4 && ort.All(o => o != Empty))
                    grid.WriteValueAt(a, Visited);
            }
            
            grid.TurnRight();
        }
        
        return new PuzzleResult(stepCount, "9621d21040a0ca3450ce213d1dca7bb5");
    }

    public PuzzleResult Part3(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input, Empty);
        var start = grid.FindAddresses(Current).First();
        
        var boneCoords = grid.CoordsOf(Bone).ToList();
        var boneAdjCoords = boneCoords.SelectMany(o => grid.PossibleOrthogonalAdjacentCoordsTo(o)).ToHashSet();
        
        grid.MoveTo(start);
        grid.WriteValue(Visited);
        foreach (var coord in boneCoords)
        {
            grid.WriteValueAt(coord, Visited);
        }
        grid.TurnTo(GridDirection.Up);
        var stepCount = 0;
        var directionIndex = -1;
        GridDirection[] directions =
        [
            GridDirection.Up, GridDirection.Up, GridDirection.Up,
            GridDirection.Right, GridDirection.Right, GridDirection.Right,
            GridDirection.Down, GridDirection.Down, GridDirection.Down,
            GridDirection.Left, GridDirection.Left, GridDirection.Left
        ];

        var emptyCoords = grid.Coords.Where(o => grid.ReadValueAt(o) == Empty);
        foreach (var emptyCoord in emptyCoords)
        {
            var enclosedCoords = GetEnclosedCoords(grid, emptyCoord);
            foreach (var enclosedCoord in enclosedCoords)
            {
                grid.WriteValueAt(enclosedCoord, Visited);
            }
        }
        
        while (boneAdjCoords.Any(o => grid.ReadValueAt(o) == Empty))
        {
            stepCount++;
            directionIndex++;
            if (directionIndex >= directions.Length) directionIndex = 0;
            grid.TurnTo(directions[directionIndex]);
         
            while (true)
            {
                grid.MoveForward();
                if (grid.ReadValue() == Visited)
                {
                    grid.MoveBackward();
                    directionIndex++;
                    if (directionIndex >= directions.Length) directionIndex = 0;
                    grid.TurnTo(directions[directionIndex]);
                    continue;
                }

                break;
            }

            grid.WriteValue(Visited);
            var adj = grid.PossibleOrthogonalAdjacentCoords.Where(o => grid.ReadValueAt(o) == Empty);
            foreach (var possiblyEnclosed in adj)
            {
                var enclosedCoords = GetEnclosedCoords(grid, possiblyEnclosed);
                foreach (var e in enclosedCoords)
                {
                    grid.WriteValueAt(e, Visited);
                }
            }
        }
        
        return new PuzzleResult(stepCount, "91141abd782d1d77e4fc599ef1a7d8f3");
    }

    private static IEnumerable<Coord> GetEnclosedCoords(Grid<char> grid, Coord start)
    {
        if (grid.ReadValueAt(start) != Empty)
            return [];
        
        HashSet<Coord> seen = [];
        var queue = new Queue<Coord>();
        queue.Enqueue(start);
        seen.Add(start);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            // Just picked a number to make it easier. Could search for min and max x and y or something
            if (seen.Count > 175)
                return [];

            var adj = grid.PossibleOrthogonalAdjacentCoordsTo(current).Where(o => grid.ReadValueAt(o) == Empty);
            foreach (var a in adj)
            {
                if (seen.Add(a))
                    queue.Enqueue(a);
                
            }
        }
        
        return seen;
    }
}