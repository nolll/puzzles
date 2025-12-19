using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202506;

[Name("Bird spotters")]
public class FlipFlop202506 : FlipFlopPuzzle
{
    private const long SecondsInAYear = 31556926L;
    private const int SecondsInAnHour = 3600;
    private const int GridSize = 1000;
    private const int FrameStart = GridSize / 4;
    private const int GridEnd = GridSize * 3 / 4;
    private const int PictureCount = 1000;

    public PuzzleResult Part1(string input)
    {
        var speeds = input.Split(LineBreaks.Single).Select(Numbers.IntsFromString).Select(o => new Coord(o[0], o[1]));
        const int time = 100;
        var birdsInFrame = speeds.Select(o => Move(o, time)).Where(IsInFrame);
        
        return new PuzzleResult(birdsInFrame.Count(), "d0cfc435d1459e83bcc2be3046271a1a");
    }

    public PuzzleResult Part2(string input)
    {
        var speeds = input.Split(LineBreaks.Single).Select(Numbers.IntsFromString).Select(o => new Coord(o[0], o[1])).ToList();
        var birdCount = 0;
    
        for (var i = 1; i <= PictureCount; i++)
        {
            var time = i * SecondsInAnHour;
            birdCount += speeds.Select(o => Move(o, time)).Count(IsInFrame);
        }
        
        return new PuzzleResult(birdCount, "6b4351b8336078bb7ea6ade68803e6d4");
    }
    
    public PuzzleResult Part3(string input)
    {
        var speeds = input.Split(LineBreaks.Single).Select(Numbers.IntsFromString).Select(o => new Coord(o[0], o[1])).ToList();
        var birdCount = 0L;

        for (var i = 1; i <= PictureCount; i++)
        {
            var time = i * SecondsInAYear;
            birdCount += speeds.Select(o => Move(o, time)).Count(IsInFrame);
        }
        
        return new PuzzleResult(birdCount, "61dc24a9d639e326619bf87ce21094f7");
    }

    private static Coord Move(Coord coord, long time)
    {
        var x = (int)(time * coord.X % GridSize + GridSize) % GridSize;
        var y = (int)(time * coord.Y % GridSize + GridSize) % GridSize;
        return new Coord(x, y);
    }

    private static bool IsInFrame(Coord o) => o.X is > FrameStart and <= GridEnd && o.Y is > FrameStart and <= GridEnd;
}