using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202414;

[Name("Restroom Redoubt")]
public class Aoc202414 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var result = Part1(input, 101, 103);

        return new PuzzleResult(result, "b1d1ce0325bc4a8e41d033f8bfb0a58e");
    }
    
    public PuzzleResult Part2(string input)
    {
        var s = Part2(input, 101, 103);
        return new PuzzleResult(s, "258b802fdbfe2ab2ad0cf4f04b73be1d");
    }

    public long Part1(string input, int width, int height)
    {
        const int time = 100;
        var lines = input.Split(LineBreaks.Single);
        var nums = lines.Select(Numbers.IntsFromString);
        var robots = nums.Select(o => new Robot(new Coord(o[0], o[1]), new Coord(o[2], o[3]))).ToArray();
        
        foreach (var robot in robots)
        {
            var x = (robot.Location.X + robot.Velocity.X * time) % width;
            var y = (robot.Location.Y + robot.Velocity.Y * time) % height;
            while (x < 0) x += width;
            while (y < 0) y += height;
            robot.Location = new Coord(x, y);    
        }

        var matrix = new Grid<int>(width, height);
        foreach (var robot in robots)
        {
            var v = matrix.ReadValueAt(robot.Location);
            matrix.WriteValueAt(robot.Location, v + 1);
        }
        
        Coord[] sliceCoords =
        [
            new(0, 0),
            new(width / 2 + 1, 0),
            new(0, height / 2 + 1),
            new(width / 2 + 1, height / 2 + 1)
        ];
        
        var quadrants = sliceCoords.Select(o => matrix.Slice(o, width / 2, height / 2));
        var sum = quadrants.Aggregate(1, (v, quadrant) => v * quadrant.Values.Sum());

        return sum;
    }
    
    public long Part2(string input, int width, int height)
    {
        const int time = 10000;
        var lines = input.Split(LineBreaks.Single);
        var nums = lines.Select(Numbers.IntsFromString);
        var robots = nums.Select(o => new Robot(new Coord(o[0], o[1]), new Coord(o[2], o[3]))).ToArray();
        
        for (var t = 0; t < time; t++)
        {
            foreach (var robot in robots)
            {
                var x = (robot.Location.X + robot.Velocity.X + width) % width;
                var y = (robot.Location.Y + robot.Velocity.Y + height) % height;
                robot.Location = new Coord(x, y); 
            }

            var centeredRobots = robots.Count(o => o.Location.X > 30 && o.Location.X < width - 30 && o.Location.Y > 50);
            if (centeredRobots * 100 / robots.Length > 50)
                return t + 1;
        }
        
        return 0;
    }

    private class Robot(Coord location, Coord velocity)
    {
        public Coord Location { get; set; } = location;
        public Coord Velocity { get; } = velocity;
    }
}