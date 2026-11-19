using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.State;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Explavigation")]
public class Ece202615 : EverybodyEventPuzzle
{
    [Puzzle("9b6e7363573119422efe76f283f5c321")]
    public int Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var start = grid.FindCoords('S').First();
        var end = grid.FindCoords('E').First();
        var sulphurCoords = grid.FindCoords('@').ToHashSet();
        grid.WriteValueAt([.. sulphurCoords, start, end], '.');
        var bitState = new CoordBitStateHandler(sulphurCoords);
        var seen = new Dictionary<(Coord Coord, GridDirection Direction, long State), int>();
        var queue = new Queue<(Coord Coord, GridDirection Direction, long State, int Cost)>([(start, GridDirection.Right, 0, 0)]);

        while (queue.Count > 0)
        {
            var (coord, direction, sulphur, cost) = queue.Dequeue();

            if (sulphurCoords.Contains(coord))
                sulphur = bitState.MarkValue(sulphur, coord);
            seen[(coord, direction, sulphur)] = cost;
            
            if (coord == end && sulphur == bitState.MaxValue)
                continue;

            var newCost = cost + 1;

            var leftDir = direction.TurnLeft();
            var left = coord.Forward(leftDir);
            var isPathLeft = grid.ReadValueAt(left) == '.';
            var seenLeft = seen.ContainsKey((left, leftDir, sulphur));
            if (isPathLeft && (!seenLeft || seen[(left, leftDir, sulphur)] > newCost))
                queue.Enqueue((left, leftDir, sulphur, newCost));

            var rightDir = direction.TurnRight();
            var right = coord.Forward(rightDir);
            var isPathRight = grid.ReadValueAt(right) == '.';
            var seenRight = seen.ContainsKey((right, rightDir, sulphur));
            if (isPathRight && (!seenRight || seen[(right, rightDir, sulphur)] > newCost))
                queue.Enqueue((right, rightDir, sulphur, newCost));

            var forward = coord.Forward(direction);
            var isPathForward = grid.ReadValueAt(forward) == '.';
            var seenForward = seen.ContainsKey((forward, direction, sulphur));
            if (isPathForward && (!seenForward || seen[(forward, direction, sulphur)] > newCost))
                queue.Enqueue((forward, direction, sulphur, newCost));
        }

        return seen.Where(o => o.Key.Item1 == end && o.Key.Item3 == bitState.MaxValue).Min(o => o.Value);
    }

    [Puzzle("063adb75d06940df49f0808807319937")]
    public int Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var start = grid.FindCoords('S').First();
        var end = grid.FindCoords('E').First();
        var sulphurCoords = grid.FindCoords('@').ToHashSet();
        grid.WriteValueAt([.. sulphurCoords, start, end], '.');
        const int sulphurTarget = 2026;
        var seen = new Dictionary<(Coord Coord, GridDirection Direction, bool Done), (int Sulphur, int Cost)>();
        var queue = new Queue<(Coord Coord, GridDirection Direction, int Sulphur, int Cost)>([(start, GridDirection.Right, 0, 0)]);

        while (queue.Count > 0)
        {
            var (coord, direction, sulphur, cost) = queue.Dequeue();

            seen[(coord, direction, sulphur == sulphurTarget)] = (Sulphur: sulphur, Cost: cost);
            
            if (coord == end && sulphur == sulphurTarget)
                continue;

            var newCost = cost + 1;

            var leftDir = direction.TurnLeft();
            var left = coord.Forward(leftDir);
            var isPathLeft = grid.ReadValueAt(left) == '.';
            var leftSulphur = sulphurCoords.Contains(left) && sulphur < sulphurTarget ? sulphur + 1 : sulphur;
            var leftKey = (left, leftDir, leftSulphur == sulphurTarget);
            var seenLeft = seen.ContainsKey(leftKey);
            if (isPathLeft && (!seenLeft || seen[leftKey].Sulphur < leftSulphur || seen[leftKey].Cost > newCost))
                queue.Enqueue((left, leftDir, leftSulphur, newCost));

            var rightDir = direction.TurnRight();
            var right = coord.Forward(rightDir);
            var isPathRight = grid.ReadValueAt(right) == '.';
            var rightSulphur = sulphurCoords.Contains(right) && sulphur < sulphurTarget ? sulphur + 1 : sulphur;
            var rightKey = (right, rightDir, rightSulphur == sulphurTarget);
            var seenRight = seen.ContainsKey(rightKey);
            if (isPathRight && (!seenRight || seen[rightKey].Sulphur < rightSulphur || seen[rightKey].Cost > newCost))
                queue.Enqueue((right, rightDir, rightSulphur, newCost));

            var forward = coord.Forward(direction);
            var isPathForward = grid.ReadValueAt(forward) == '.';
            var forwardSulphur = sulphurCoords.Contains(forward) && sulphur < sulphurTarget ? sulphur + 1 : sulphur;
            var forwardKey = (forward, direction, forwardSulphur == sulphurTarget);
            var seenForward = seen.ContainsKey(forwardKey);
            if (isPathForward && (!seenForward || seen[forwardKey].Sulphur < forwardSulphur || seen[forwardKey].Cost > newCost))
                queue.Enqueue((forward, direction, forwardSulphur, newCost));
        }

        return seen.Where(o => o.Key.Coord == end && o.Value.Sulphur >= sulphurTarget).Min(o => o.Value).Cost;
    }

    [Puzzle("")]
    public int Part3(string input)
    {
        return 0;
    }
}