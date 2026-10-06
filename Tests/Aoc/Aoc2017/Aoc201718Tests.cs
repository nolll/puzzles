using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201718Tests : PuzzleTest<Aoc201718>
{
    [Fact]
    public void SingleRunnerFindsFrequency()
    {
        const string input = """
                             set a 1
                             add a 2
                             mul a a
                             mod a 5
                             snd a
                             set a 0
                             rcv a
                             jgz a -1
                             set a 1
                             jgz a -2
                             """;
        
        Sut.RunPart1(input).Should().Be(4);
    }

    [Fact]
    public void DuetRunnerSendCountIsCorrect()
    {
        const string input = """
                             snd 1
                             snd 2
                             snd p
                             rcv a
                             rcv b
                             rcv c
                             rcv d
                             """;
        
        Sut.RunPart2(input).Should().Be(3);
    }
}