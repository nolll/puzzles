using FluentAssertions;

namespace Pzl.Everybody.Puzzles.Ecs01.Ecs0101;

public class Ecs0101Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             A=4 B=4 C=6 X=3 Y=4 Z=5 M=11
                             A=8 B=4 C=7 X=8 Y=4 Z=6 M=12
                             A=2 B=8 C=6 X=2 Y=4 Z=5 M=13
                             A=5 B=9 C=6 X=8 Y=6 Z=8 M=14
                             A=5 B=9 C=7 X=6 Y=6 Z=8 M=15
                             A=8 B=8 C=8 X=6 Y=9 Z=6 M=16
                             """;

        Sut.RunPart1(input).Answer.Should().Be("11611972920");
    }
    
    [Fact]
    public void Part2_1()
    {
        const string input = """
                             A=4 B=4 C=6 X=3 Y=14 Z=15 M=11
                             A=8 B=4 C=7 X=8 Y=14 Z=16 M=12
                             A=2 B=8 C=6 X=2 Y=14 Z=15 M=13
                             A=5 B=9 C=6 X=8 Y=16 Z=18 M=14
                             A=5 B=9 C=7 X=6 Y=16 Z=18 M=15
                             A=8 B=8 C=8 X=6 Y=19 Z=16 M=16
                             """;

        Sut.RunPart2(input).Answer.Should().Be("11051340");
    }
    
    [Fact]
    public void Part2_2()
    {
        const string input = """
                             A=3657 B=3583 C=9716 X=903056852 Y=9283895500 Z=85920867478 M=188
                             A=6061 B=4425 C=5082 X=731145782 Y=1550090416 Z=87586428967 M=107
                             A=7818 B=5395 C=9975 X=122388873 Y=4093041057 Z=58606045432 M=102
                             A=7681 B=9603 C=5681 X=716116871 Y=6421884967 Z=66298999264 M=196
                             A=7334 B=9016 C=8524 X=297284338 Y=1565962337 Z=86750102612 M=145
                             """;

        Sut.RunPart2(input).Answer.Should().Be("1507702060886");
    }
    
    [Fact]
    public void Part3_1()
    {
        const string input = """
                             A=4 B=4 C=6 X=3000 Y=14000 Z=15000 M=110
                             A=8 B=4 C=7 X=8000 Y=14000 Z=16000 M=120
                             A=2 B=8 C=6 X=2000 Y=14000 Z=15000 M=130
                             A=5 B=9 C=6 X=8000 Y=16000 Z=18000 M=140
                             A=5 B=9 C=7 X=6000 Y=16000 Z=18000 M=150
                             A=8 B=8 C=8 X=6000 Y=19000 Z=16000 M=160
                             """;

        Sut.RunPart3(input).Answer.Should().Be("3279640");
    }
    
    [Fact]
    public void Part3_2()
    {
        const string input = """
                             A=3657 B=3583 C=9716 X=903056852 Y=9283895500 Z=85920867478 M=188
                             A=6061 B=4425 C=5082 X=731145782 Y=1550090416 Z=87586428967 M=107
                             A=7818 B=5395 C=9975 X=122388873 Y=4093041057 Z=58606045432 M=102
                             A=7681 B=9603 C=5681 X=716116871 Y=6421884967 Z=66298999264 M=196
                             A=7334 B=9016 C=8524 X=297284338 Y=1565962337 Z=86750102612 M=145
                             """;

        Sut.RunPart3(input).Answer.Should().Be("7276515438396");
    }
    
    [Theory]
    [InlineData(2, 4, 5, 1342)]
    [InlineData(3, 5, 16, 311193)]
    public void Eni1(long n, long exp, long mod, long expected) => Ecs0101.Eni1(n, exp, mod).Should().Be(expected);
    
    [Fact]
    public void Eni1Sum() => Ecs0101.EniSum(Ecs0101.Eni1, 4, 4, 6, 3, 4, 5, 11).Should().Be(114644);

    [Theory]
    [InlineData(2, 7, 5, 34213)]
    [InlineData(3, 8, 16, 111931)]
    [InlineData(4, 14, 11, 39541)]
    public void Eni2(long n, long exp, long mod, long expected) =>
        Ecs0101.Eni2(n, exp, mod).Should().Be(expected);
    
    [Theory]
    [InlineData(4, 4, 6, 3, 14, 15, 11, 150231)]
    [InlineData(8, 4, 7, 8, 14, 16, 12, 110099)]
    [InlineData(2, 8, 6, 2, 14, 15, 13, 9387665)]
    [InlineData(5, 9, 6, 8, 16, 18, 14, 1113198)]
    [InlineData(5, 9, 7, 6, 16, 18, 15, 11051340)]
    [InlineData(8, 8, 8, 6, 19, 16, 16, 0)]
    public void Eni2Sum(long a, long b, long c, long x, long y, long z, long m, long expected) => 
        Ecs0101.EniSum(Ecs0101.Eni2, a, b, c, x, y, z, m).Should().Be(expected);
    
    [Theory]
    [InlineData(2, 7, 5, 19)]
    [InlineData(3, 8, 16, 48)]
    public void Eni3(long n, long exp, long mod, long expected) =>
        Ecs0101.Eni3(n, exp, mod).Should().Be(expected);
    
    [Theory]
    [InlineData(2, 8, 6, 2000, 14000, 15000, 130, 2079860)]
    [InlineData(8, 8, 8, 6000, 19000, 16000, 160, 3279640)]
    public void Eni3Sum(long a, long b, long c, long x, long y, long z, long m, long expected) => 
        Ecs0101.EniSum(Ecs0101.Eni3, a, b, c, x, y, z, m).Should().Be(expected);

    private static Ecs0101 Sut => new();
}