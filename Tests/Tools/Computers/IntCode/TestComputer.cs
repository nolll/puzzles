using Pzl.Tools.Computers.IntCode;

namespace Tests.Tools.Computers.IntCode;

public class TestComputer(string input) : IntCodeComputer(input, ReadInput, WriteOutput)
{
    private static long ReadInput() => 0;
    private static bool WriteOutput(long output) => true;
}