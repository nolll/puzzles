using Pzl.Common;
using Pzl.Tools.Computers.IntCode;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Tractor Beam")]
[Comment("Fix warning about outer scope")]
public class Aoc201919 : AocPuzzle
{
    [Puzzle("984c01d5977631fa8cd48a8fbd689c1c")]
    public int Part1(string input) => GetPullCount(input, 50, 50);

    [Puzzle("c22eb8f92f96b6e515142cffa3b161c0")]
    public int Part2(string input) => Find100By100Square(input);

    public int GetPullCount(string program, int width, int height)
    {
        var x = 0;
        var y = 0;
        var count = 0;
        var mode = TractorBeamInputMode.X;
        var computer = new IntCodeComputer(program, ReadInput, WriteOutput);
        while (x < width && y < height)
            computer.Start();

        return count;

        long ReadInput()
        {
            if (mode == TractorBeamInputMode.X)
            {
                var returnValue = x;
                mode = TractorBeamInputMode.Y;
                x += 1;
                if (x > width - 1)
                {
                    x = 0;
                    y += 1;
                }

                return returnValue;
            }
            else
            {
                var returnValue = y;
                mode = TractorBeamInputMode.X;

                return returnValue;
            }
        }

        bool WriteOutput(long output)
        {
            if (output == 1)
                count += 1;

            return true;
        }
    }
    
    public int Find100By100Square(string program)
    {
        var x = 0;
        var y = 100;
        var tempX = 0;
        var tempY = 0;
        var output = 0;
        var mode = TractorBeamInputMode.X;

        var computer = new IntCodeComputer(program, ReadInput, WriteOutput);

        while (true)
        {
            tempX = x;
            tempY = y;
            computer.Start();
            if (output == 1)
            {
                tempX = x + 99;
                tempY = y - 99;
                computer.Start();
                if (output == 1)
                    break;

                y += 1;
            }

            x += 1;
        }

        return x * 10000 + y - 99;

        long ReadInput()
        {
            if (mode == TractorBeamInputMode.X)
            {
                mode = TractorBeamInputMode.Y;
                return tempX;
            }

            mode = TractorBeamInputMode.X;
            return tempY;
        }

        bool WriteOutput(long o)
        {
            output = (int)o;
            return true;
        }
    }

    private enum TractorBeamInputMode
    {
        X,
        Y
    }
}