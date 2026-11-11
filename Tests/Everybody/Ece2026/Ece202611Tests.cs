using Pzl.Everybody.Puzzles.Ece2026;

namespace Tests.Everybody.Ece2026;

public class Ece202611Tests : PuzzleTest<Ece202611>
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             portals: 10
                             
                             5 10
                             2 7
                             """;

        Sut.Part1(input).Should().Be(60);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             portals: 10
                             
                             5 10
                             2 7
                             """;

        Sut.Part2(input).Should().Be(6);
    }

    [Fact]
    public void Part3_1()
    {
        const string input = """
                             portals: 32
                             
                             1 10
                             20 30
                             15 29
                             13 10
                             """;

        Sut.Part3(input).Should().Be(854);
    }
    
    // Much too slow, 55s
    // [Fact]
    // public void Part3_2()
    // {
    //     const string input = """
    //                          portals: 64
    //                          
    //                          1 40
    //                          3 35
    //                          5 42
    //                          7 50
    //                          """;
    //
    //     Sut.Part3(input).Should().Be(9634);
    // }
}