using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202506;

[Name("Bird spotters")]
public class FlipFlop202506 : FlipFlopPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var speeds = input.Split(LineBreaks.Single).Select(Numbers.IntsFromString).Select(o => new Coord(o[0], o[1]));
        var endPositions = new List<Coord>();
        const int time = 100;
        const int size = 1000;
        foreach (var speed in speeds)
        {
            var x = time * speed.X;
            var y = time * speed.Y;
            while (x < 0) x += size;
            while (y < 0) y += size;
            x %= size;
            y %= size;
            
            endPositions.Add(new Coord(x, y));
        }

        var birdsInFrame = endPositions.Where(o => o.X is > 250 and <= 750 && o.Y is > 250 and <= 750);
        
        return new PuzzleResult(birdsInFrame.Count(), "d0cfc435d1459e83bcc2be3046271a1a");
    }

    public PuzzleResult Part2(string input)
    {
        var speeds = input.Split(LineBreaks.Single).Select(Numbers.IntsFromString).Select(o => new Coord(o[0], o[1])).ToList();
        const int size = 1000;
        var birdCount = 0;
    
        for (var i = 1; i <= 1000; i++)
        {
            var endPositions = new List<Coord>();
            //Console.WriteLine(i);
            var time = i * 3600;
            foreach (var speed in speeds)
            {
                var x = (time * speed.X % size + size) % size;
                var y = (time * speed.Y % size + size) % size;
            
                endPositions.Add(new Coord(x, y));
            }
            
            birdCount += endPositions.Count(o => o.X is > 250 and <= 750 && o.Y is > 250 and <= 750);
        }
        
        return new PuzzleResult(birdCount, "6b4351b8336078bb7ea6ade68803e6d4");
    }
    
    public PuzzleResult Part3(string input)
    {
        var speeds = input.Split(LineBreaks.Single).Select(Numbers.IntsFromString).Select(o => new Coord(o[0], o[1])).ToList();
        const int size = 1000;
        var birdCount = 0L;

        for (var i = 1; i <= 1000; i++)
        {
            var endPositions = new List<Coord>();
            var time = i * 31556926L;
            foreach (var speed in speeds)
            {
                var x = (int)(time * speed.X % size + size) % size;
                var y = (int)(time * speed.Y % size + size) % size;
            
                endPositions.Add(new Coord(x, y));
            }
            
            birdCount += endPositions.Count(o => o.X is > 250 and <= 750 && o.Y is > 250 and <= 750);
        }
        
        return new PuzzleResult(birdCount, "61dc24a9d639e326619bf87ce21094f7");
    }
}