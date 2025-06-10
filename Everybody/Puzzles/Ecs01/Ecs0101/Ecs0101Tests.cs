using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Ecs01.Ecs0101;

public class Ecs0101Tests
{
    [Test]
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
    
    [Test]
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
    
    [Test]
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
    
    [Test]
    public void EniSum() => Sut.EniSum(4, 4, 6, 3, 4, 5, 11).Should().Be(114644);

    [TestCase(2, 4, 5, 1342)]
    [TestCase(3, 5, 16, 311193)]
    public void Eni(long n, long exp, long mod, long expected) => Sut.Eni(n, exp, mod).Should().Be(expected);

    private static Ecs0101 Sut => new();
}