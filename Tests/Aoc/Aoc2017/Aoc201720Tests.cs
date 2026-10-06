using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201720Tests : PuzzleTest<Aoc201720>
{
    private const string Input1 = """
                                  p=<3,0,0>, v=<2,0,0>, a=<-1,0,0>
                                  p=<4,0,0>, v=<0,0,0>, a=<-2,0,0>
                                  """;

    private const string Input2 = """
                                  p=<-6,0,0>, v=<3,0,0>, a=<0,0,0>
                                  p=<-4,0,0>, v=<2,0,0>, a=<0,0,0>
                                  p=<-2,0,0>, v=<1,0,0>, a=<0,0,0>
                                  p=<3,0,0>, v=<-1,0,0>, a=<0,0,0>
                                  """;
    
    [Fact]
    public void Part1() => Sut.GetClosestParticleInTheLongRunSimple(Input1).Should().Be(0);

    [Fact]
    public void Part2() => Sut.GetRemainingParticleCount(Input2).Should().Be(1);
}