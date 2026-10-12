using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201819Tests : PuzzleTest<Aoc201819>
{
    private const string Input = """
                                 #ip 0
                                 seti 5 0 1
                                 seti 6 0 2
                                 addi 0 1 0
                                 addr 1 2 3
                                 setr 1 0 0
                                 seti 8 0 4
                                 seti 9 0 5
                                 """;

    [Fact]
    public void CorrectValueInRegister0AfterProgramHalts() => 
        new Aoc201819.Computer().RunInstructionPointerProgram(Input, 0, false).Should().Be(6);
}