namespace Pzl.Everybody.Puzzles.Ecs03.Ecs0303;

public class Ecs0303Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             id=1, plug=BLUE HEXAGON, leftSocket=GREEN CIRCLE, rightSocket=BLUE PENTAGON, data=?
                             id=2, plug=GREEN CIRCLE, leftSocket=BLUE HEXAGON, rightSocket=BLUE CIRCLE, data=?
                             id=3, plug=BLUE PENTAGON, leftSocket=BLUE CIRCLE, rightSocket=BLUE CIRCLE, data=?
                             id=4, plug=BLUE CIRCLE, leftSocket=RED HEXAGON, rightSocket=BLUE HEXAGON, data=?
                             id=5, plug=RED HEXAGON, leftSocket=GREEN CIRCLE, rightSocket=RED HEXAGON, data=?
                             """;

        Sut.Part1(input).Should().Be(43);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             id=1, plug=RED TRIANGLE, leftSocket=RED TRIANGLE, rightSocket=RED TRIANGLE, data=?
                             id=2, plug=GREEN TRIANGLE, leftSocket=BLUE CIRCLE, rightSocket=GREEN CIRCLE, data=?
                             id=3, plug=BLUE PENTAGON, leftSocket=BLUE CIRCLE, rightSocket=GREEN CIRCLE, data=?
                             id=4, plug=RED TRIANGLE, leftSocket=BLUE PENTAGON, rightSocket=GREEN PENTAGON, data=?
                             id=5, plug=RED PENTAGON, leftSocket=GREEN CIRCLE, rightSocket=GREEN CIRCLE, data=?
                             """;

        Sut.Part2(input).Should().Be(50);
    }

    [Fact]
    public void Part3_1()
    {
        const string input = """
                             id=1, plug=RED TRIANGLE, leftSocket=RED TRIANGLE, rightSocket=RED TRIANGLE, data=?
                             id=2, plug=GREEN TRIANGLE, leftSocket=BLUE CIRCLE, rightSocket=GREEN CIRCLE, data=?
                             id=3, plug=BLUE PENTAGON, leftSocket=BLUE CIRCLE, rightSocket=GREEN CIRCLE, data=?
                             id=4, plug=RED TRIANGLE, leftSocket=BLUE PENTAGON, rightSocket=GREEN PENTAGON, data=?
                             id=5, plug=RED PENTAGON, leftSocket=GREEN CIRCLE, rightSocket=GREEN CIRCLE, data=?
                             """;

        Sut.Part3(input).Should().Be(38);
    }

    [Fact]
    public void Part3_2()
    {
        const string input = """
                             id=1, plug=RED TRIANGLE, leftSocket=BLUE TRIANGLE, rightSocket=GREEN TRIANGLE, data=?
                             id=2, plug=GREEN TRIANGLE, leftSocket=BLUE CIRCLE, rightSocket=GREEN CIRCLE, data=?
                             id=3, plug=BLUE PENTAGON, leftSocket=BLUE CIRCLE, rightSocket=GREEN CIRCLE, data=?
                             id=4, plug=RED TRIANGLE, leftSocket=BLUE PENTAGON, rightSocket=GREEN PENTAGON, data=?
                             id=5, plug=BLUE TRIANGLE, leftSocket=GREEN CIRCLE, rightSocket=RED CIRCLE, data=?
                             id=6, plug=BLUE TRIANGLE, leftSocket=GREEN CIRCLE, rightSocket=RED CIRCLE, data=?
                             """;

        Sut.Part3(input).Should().Be(60);
    }

    private static Ecs0303 Sut => new();
}