using Pzl.Common;
using Pzl.Tools.Computers.IntCode;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Sensor Boost")]
public class Aoc201909 : AocPuzzle
{
    [Puzzle("d7f50f8a7d7941f1943aebc443a86484")]
    public long Part1(string input) => Solve(input, 1);

    [Puzzle("336de8801a44e745a6f69e2c6dc0d4a3")]
    public long Part2(string input) => Solve(input, 2);

    private long Solve(string input, int mode) => Run(input, mode).Last();

    public IList<long> Run(string input, int mode)
    {
        var outputs = new List<long>();
        var computer = new IntCodeComputer(input, () => mode, WriteOutput);
        computer.Start();

        return outputs;

        bool WriteOutput(long o)
        {
            outputs.Add(o);
            return true;
        }
    }
}