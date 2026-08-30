namespace Pzl.Everybody.Puzzles.Ecs04.Ecs0401;

public class Ecs0401Tests
{
    [Fact]
    public void Part1_1()
    {
        const string input = """
                             1,2,3,4,5,6,7,8,9
                             1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30
                             """;

        Sut.Part1(input).Should().Be(66);
    }
    
    [Fact]
    public void Part1_2()
    {
        const string input = """
                             1,1,1,1,1
                             5,1,2,3,4,5,1,2,3,4
                             2,1,1,2,1,1,2,1,1,2,1,1
                             5,1,2,1,2,7,1,2,1,2,7,1,2,1,2
                             """;

        Sut.Part1(input).Should().Be(34);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             1,1,1,1,1
                             5,1,2,3,4,5,1,2,3,4
                             2,1,1,2,1,1,2,1,1,2,1,1
                             5,1,2,1,2,7,1,2,1,2,7,1,2,1,2
                             """;

        Sut.Part2(input).Should().Be(43);
    }

    [Fact]
    public void Part3_Single_1_1() => Sut.Part3("1,1,1,1,1").Should().Be(5);

    [Fact]
    public void Part3_Single_1_2() => Sut.Part3("5,1,2,3,4,5,1,2,3,4").Should().Be(20);

    [Fact]
    public void Part3_Single_1_3() => Sut.Part3("2,1,1,2,1,1,2,1,1,2,1,1").Should().Be(1);

    [Fact]
    public void Part3_Single_1_4() => Sut.Part3("5,1,2,1,2,7,1,2,1,2,7,1,2,1,2").Should().Be(1);

    [Fact]
    public void Part3_All_1()
    {
        const string input = """
                             1,1,1,1,1
                             5,1,2,3,4,5,1,2,3,4
                             2,1,1,2,1,1,2,1,1,2,1,1
                             5,1,2,1,2,7,1,2,1,2,7,1,2,1,2
                             """;

        Sut.Part3(input).Should().Be(27);
    }
    
    [Fact]
    public void Part3_Single_2_1() => Sut.Part3("5,3,1,1").Should().Be(6);

    [Fact]
    public void Part3_Single_2_2() => Sut.Part3("5,3,1,1,5,1,1,3,4,8,1,1").Should().Be(17);

    [Fact]
    public void Part3_Single_2_3() => Sut.Part3("5,3,1,1,5,1,1,3,4,8,2,1").Should().Be(7);

    [Fact]
    public void Part3_Single_2_4() => Sut.Part3("10,9,9,8,8,7,7,6,6,5,5,4,4,3,3,2,2,1").Should().Be(5);
    
    [Fact]
    public void Part3_All_2()
    {
        const string input = """
                             5,3,1,1
                             5,3,1,1,5,1,1,3,4,8,1,1
                             5,3,1,1,5,1,1,3,4,8,2,1
                             10,9,9,8,8,7,7,6,6,5,5,4,4,3,3,2,2,1
                             """;

        Sut.Part3(input).Should().Be(35);
    }
    
    [Fact]
    public void IsCrossing() => Ecs0401.IsCrossing([(6, 10)], (9, 12)).Should().Be(true);

    [Fact]
    public void IsCrossing2() => Ecs0401.IsCrossing((6, 10), (9, 12)).Should().Be(true);

    private static Ecs0401 Sut => new();
}