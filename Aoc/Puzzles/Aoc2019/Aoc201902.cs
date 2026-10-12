using Pzl.Common;
using Pzl.Tools.Computers.IntCode;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("1202 Program Alarm")]
public class Aoc201902 : AocPuzzle
{
    private const int LowerBound = 1;
    private const int UpperBound = 99;
    
    [Puzzle("85e8cb8123555ca9bd39b2c6b962e54a")]
    public long Part1(string input)
    {
        var computer = new Computer(input);
        computer.Start(false, 12, 2);
        return computer.Result;
    }

    [Puzzle("b505e47f6dc62ca5acbbe708dd2192a5")]
    public int Part2(string input)
    {
        var (noun, verb) = FindSolution(input, 19690720);
        return 100 * noun + verb;
    }

    private static (int, int) FindSolution(string input, int target)
    {
        var computer = new Computer(input);
        for (var noun = LowerBound; noun <= UpperBound; noun++)
        {
            for (var verb = LowerBound; verb <= UpperBound; verb++)
            {
                computer.Start(false, noun, verb);
                var result = computer.Result;
                if (result == target)
                    return (noun, verb);
            }
        }

        throw new Exception("No solution found");
    }
    
    private class Computer(string input) : IntCodeComputer(input, () => 0, _ => true);
}