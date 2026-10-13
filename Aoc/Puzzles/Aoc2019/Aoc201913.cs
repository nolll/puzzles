using Pzl.Common;
using Pzl.Tools.Computers.IntCode;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Care Package")]
public class Aoc201913 : AocPuzzle
{
    [Puzzle("65621a57e5ba6bbdc37540f0d2320098")]
    public int Part1(string input)
    {
        var (count, _) = Play(input);
        return count;
    }

    [Puzzle("6c32f2b8d2a26180534728ccb213e116")]
    public int Part2(string input)
    {
        var (_, score) = Play(input, 2);
        return score;
    }

    private static (int, int) Play(string input, int? startValue = null)
    {
        var mode = ArcadeMode.X;
        var score = 0;
        var x = 0;
        var y = 0;
        var ballX = 0;
        var paddleX = 0;
        var screen = new Grid<char>();
        var computer = new IntCodeComputer(input, ReadInput, WriteOutput);

        long ReadInput()
        {
            if (ballX < paddleX)
                return -1;
            if (ballX > paddleX)
                return 1;
            return 0;
        }

        bool WriteOutput(long output)
        {
            var value = (int)output;
            if (mode == ArcadeMode.X)
            {
                x = value;
                mode = ArcadeMode.Y;
                return true;
            }

            if (mode == ArcadeMode.Y)
            {
                y = value;
                mode = ArcadeMode.Type;
                return true;
            }

            if (x == -1 && y == 0)
            {
                score = value;
            }
            else
            {
                WriteToScreen(screen, x, y, value);
                var tile = ArcadeTiles.Chars[value];
                if (tile == ArcadeTiles.Ball)
                    ballX = x;

                if (tile == ArcadeTiles.Paddle)
                    paddleX = x;
            }

            mode = ArcadeMode.X;

            return true;
        }

        if (startValue != null)
            computer.SetMemory(0, startValue.Value);
        computer.Start();

        var numberOfBlockTiles = screen.Values.Count(o => o == ArcadeTiles.Block);
        return (numberOfBlockTiles, score);
    }

    private static void WriteToScreen(Grid<char> screen, int x, int y, int tile)
    {
        screen.MoveTo(new Coord(x, y));
        screen.WriteValue(ArcadeTiles.Chars[tile]);
    }

    private enum ArcadeMode
    {
        X,
        Y,
        Type
    }

    private static class ArcadeTiles
    {
        public const char Empty = ' ';
        public const char Wall = '#';
        public const char Block = '_';
        public const char Paddle = '=';
        public const char Ball = 'o';

        public static readonly char[] Chars = [Empty, Wall, Block, Paddle, Ball];
    }
}