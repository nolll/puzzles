using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Numbers;

namespace Pzl.Everybody.Puzzles.Ecs04.Ecs0403;

[Name("Hitomezashi Sashiko Floorplan")]
public class Ecs0403 : EverybodyStoryPuzzle
{
    [Puzzle("bcb28178c77a846298769a6f2223df48")]
    public int Part1(string input)
    {
        var digits = Numbers.DigitsFromString(input.ReplaceLineEndings(" "));
        var w = int.Parse(digits[0]);
        var h = int.Parse(digits[1]);
        var ho = digits[2].ToCharArray().Select(o => int.Parse(o.ToString())).ToArray();
        var vo = digits[3].ToCharArray().Select(o => int.Parse(o.ToString())).ToArray();
        
        var mask = new Dictionary<Coord, int>();
        const int top = 1;
        const int right = 2;
        const int bottom = 4;
        const int left = 8;
        const int sum = top + right + bottom + left;

        for (var y = 0; y <= h; y++)
        {
            var sx = ho[y % ho.Length];
            for (var x = sx; x <= w; x += 2)
            {
                var coord = new Coord(x, y);
                var aboveCoord = new Coord(x, y - 1);
                mask.TryGetValue(coord, out var belowMaskValue);
                mask[coord] = belowMaskValue + top;
                mask.TryGetValue(aboveCoord, out var aboveMaskValue);
                mask[aboveCoord] = aboveMaskValue + bottom;
            }
        }
        
        for (var x = 0; x <= w; x++)
        {
            var sy = vo[x % vo.Length];
            for (var y = sy; y <= h; y += 2)
            {
                var coord = new Coord(x, y);
                var leftCoord = new Coord(x - 1, y);
                mask.TryGetValue(coord, out var rightMaskValue);
                mask[coord] = rightMaskValue + right;
                mask.TryGetValue(leftCoord, out var leftMaskValue);
                mask[leftCoord] = leftMaskValue + left;
            }
        }

        var isolatedCoords = mask.Where(o => o.Value == 15).Select(o => o.Key).ToArray();
        
        return isolatedCoords.Length;
    }

    [Puzzle("")]
    public int Part2(string input)
    {
        return 0;
    }

    [Puzzle("")]
    public int Part3(string input)
    {
        return 0;
    }
}