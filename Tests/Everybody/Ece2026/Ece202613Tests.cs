using Pzl.Everybody.Puzzles.Ece2026;

namespace Tests.Everybody.Ece2026;

public class Ece202613Tests : PuzzleTest<Ece202613>
{
    [Fact]
    public void Part1_1()
    {
        const string input = """
                             hands 6:8:12
                             direction CW:CCW:CW
                             current 2:4:8
                             move 9:7:4
                             """;

        Sut.Part1(input).Should().Be(5);
    }
    
    [Fact]
    public void Part1_2()
    {
        const string input = """
                             hands 6:8:12
                             direction CW:CCW:CW
                             current 1:2:2
                             move 10:12:15
                             """;

        Sut.Part1(input).Should().Be(7);
    }
    
    [Fact]
    public void Part1_3()
    {
        const string input = """
                             hands 6:8:12
                             direction CW:CCW:CW
                             current 1:2:2
                             move 10:12:20
                             """;

        Sut.Part1(input).Should().Be(9);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             hands 6:8:12
                             direction CW:CCW:CW
                             current 2:4:8
                             move 9:7:4
                             
                             hands 6:8:12
                             direction CW:CCW:CW
                             current 1:2:2
                             move 10:12:15
                             
                             hands 6:8:12
                             direction CW:CCW:CW
                             current 1:2:2
                             move 10:12:20
                             """;

        Sut.Part2(input).Should().Be(21);
    }

    [Fact]
    public void Part3_1()
    {
        const string input = """
                             hands 6:6:28
                             direction CCW:CW:CCW
                             current 1:2:22
                             move 54874:54399:54185
                             """;

        Sut.Part3(input).Should().Be(36425);
    }
    
    [Fact]
    public void Part3_2()
    {
        const string input = """
                             hands 4:5:31
                             direction CW:CCW:CCW
                             current 0:1:10
                             move 10788421:11162892:10892093
                             """;

        Sut.Part3(input).Should().Be(9859367);
    }
    
    [Fact]
    public void Part3_3()
    {
        const string input = """
                             hands 4:11:25
                             direction CW:CW:CCW
                             current 2:1:16
                             move 65151:64221:67223
                             """;

        Sut.Part3(input).Should().Be(37953);
    }
    
    [Fact]
    public void Part3_4()
    {
        const string input = """
                             hands 8:12:20
                             direction CCW:CCW:CW
                             current 6:1:6
                             move 1484001:1435165:1478486
                             """;

        Sut.Part3(input).Should().Be(518848);
    }
}