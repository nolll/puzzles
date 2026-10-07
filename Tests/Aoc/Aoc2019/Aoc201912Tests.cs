using Pzl.Aoc.Puzzles.Aoc2019;

namespace Tests.Aoc.Aoc2019;

public class Aoc201912Tests : PuzzleTest<Aoc201912>
{
    [Fact]
    public void TotalEnergyAfter10Steps()
    {
        const string input = """
                           <x=-1, y=0, z=2>
                           <x=2, y=-10, z=-7>
                           <x=4, y=-8, z=8>
                           <x=3, y=5, z=-1>
                           """;
        
        Sut.Part1(input, 10).Should().Be(179);
    }

    [Fact]
    public void CycleLengthIs2772()
    {
        const string input = """
                           <x=-1, y=0, z=2>
                           <x=2, y=-10, z=-7>
                           <x=4, y=-8, z=8>
                           <x=3, y=5, z=-1>
                           """;
        
        Sut.Part2(input).Should().Be(2772);
    }

    [Fact]
    public void CycleLengthIs4686774924()
    {
        const string input = """
                           <x=-8, y=-10, z=0>
                           <x=5, y=5, z=10>
                           <x=2, y=-7, z=3>
                           <x=9, y=-8, z=-3>
                           """;

        Sut.Part2(input).Should().Be(4686774924);
    }
    
    private static Aoc201912 Sut => new();
}