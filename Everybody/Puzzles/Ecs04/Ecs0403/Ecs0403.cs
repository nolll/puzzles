using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Numbers;

namespace Pzl.Everybody.Puzzles.Ecs04.Ecs0403;

[Name("Hitomezashi Sashiko Floorplan")]
public class Ecs0403 : EverybodyStoryPuzzle
{
    private const int Top = 1;
    private const int Right = 2;
    private const int Bottom = 4;
    private const int Left = 8;
    private const int Sum = Top + Right + Bottom + Left;
    
    [Puzzle("bcb28178c77a846298769a6f2223df48")]
    public int Part1(string input)
    {
        var (w, h, ho, vo) = Parse(input);
        var mask = new Dictionary<Coord, int>();

        PlaceHorizontalStitches(mask, w, h, ho);
        PlaceVerticalStitches(mask, w, h, vo);

        var isolatedCoords = mask.Where(o => o.Value == Sum).Select(o => o.Key).ToArray();
        
        return isolatedCoords.Length;
    }

    [Puzzle("e892ee05396cdeb1fb3fd0ed01a43dd6")]
    public int Part2(string input) => Part2And3(input);
    
    public int Part3(string input) => Part2And3(input);

    private int Part2And3(string input)
    {
        var (w, h, ho, vo) = Parse(input);
        var mask = new Dictionary<Coord, int>();

        PlaceHorizontalStitches(mask, w, h, ho);
        PlaceVerticalStitches(mask, w, h, vo);
        var coords = GetFloorCoords(w, h).ToHashSet();
        foreach (var coord in coords)
        {
            mask.TryAdd(coord, 0);
        }
        var visited = new Dictionary<Coord, bool>();
        
        foreach (var startCoord in coords)
        {
            if (visited.ContainsKey(startCoord))
                continue;
            
            var visitedAdjacent = Grid<int>.PossibleOrthogonalAdjacentCoordsTo(startCoord)
                .Where(o => visited.ContainsKey(o)).Select(o => visited[o])
                .ToList();

            var color = visitedAdjacent.Count == 0 || !visitedAdjacent.First();
            
            var queue = new Queue<Coord>([startCoord]);
            visited[startCoord] = color;
            while (queue.Count > 0)
            {
                var coord = queue.Dequeue();
                var (x, y) = coord;

                var up = new Coord(x, y - 1);
                if(!visited.ContainsKey(up) && up.Y >= 0 && (mask[coord] & Top) != Top)
                {
                    queue.Enqueue(up);
                    visited[up] = color;
                }

                var right = new Coord(x + 1, y);
                if(!visited.ContainsKey(right) && right.X < w && (mask[coord] & Right) != Right)
                {
                    queue.Enqueue(right);
                    visited[right] = color;
                }

                var down = new Coord(x, y + 1);
                if(!visited.ContainsKey(down) && down.Y < h && (mask[coord] & Bottom) != Bottom)
                {
                    queue.Enqueue(down);
                    visited[down] = color;
                }

                var left = new Coord(x - 1, y);
                if(!visited.ContainsKey(left) && left.X >= 0 && (mask[coord] & Left) != Left)
                {
                    queue.Enqueue(left);
                    visited[left] = color;
                }
            }
        }
        
        var isolatedCoords = mask.Where(o => o.Value == Sum).Select(o => o.Key).ToArray();
        var groups = isolatedCoords.GroupBy(o => visited[o]);
        var maxCount = groups.Max(o => o.Count());

        return maxCount;
    }
    
    private IEnumerable<Coord> GetFloorCoords(int w, int h)
    {
        for (var y = 0; y < h; y++)
        {
            for (var x = 0; x < w; x++)
            {
                yield return new Coord(x, y);
            }
        }
    }

    private static void PlaceHorizontalStitches(Dictionary<Coord, int> mask, int w, int h, int[] offsets)
    {
        for (var y = 0; y <= h; y++)
        {
            var sx = offsets[y % offsets.Length];
            for (var x = sx; x <= w; x += 2)
            {
                var belowCoord = new Coord(x, y);
                var aboveCoord = new Coord(x, y - 1);
                mask.TryGetValue(belowCoord, out var belowMaskValue);
                mask[belowCoord] = belowMaskValue + Top;
                mask.TryGetValue(aboveCoord, out var aboveMaskValue);
                mask[aboveCoord] = aboveMaskValue + Bottom;
            }
        }
    }
    
    private static void PlaceVerticalStitches(Dictionary<Coord, int> mask, int w, int h, int[] offsets)
    {
        for (var x = 0; x <= w; x++)
        {
            var sy = offsets[x % offsets.Length];
            for (var y = sy; y <= h; y += 2)
            {
                var rightCoord = new Coord(x, y);
                var leftCoord = new Coord(x - 1, y);
                mask.TryGetValue(rightCoord, out var rightMaskValue);
                mask[rightCoord] = rightMaskValue + Left;
                mask.TryGetValue(leftCoord, out var leftMaskValue);
                mask[leftCoord] = leftMaskValue + Right;
            }
        }
    }
    
    private static (int, int, int[], int[]) Parse(string input)
    {
        var digits = Numbers.DigitsFromString(input.ReplaceLineEndings(" "));
        var w = int.Parse(digits[0]);
        var h = int.Parse(digits[1]);
        var ho = digits[2].ToCharArray().Select(o => int.Parse(o.ToString())).ToArray();
        var vo = digits[3].ToCharArray().Select(o => int.Parse(o.ToString())).ToArray();

        return (w, h, ho, vo);
    }
}