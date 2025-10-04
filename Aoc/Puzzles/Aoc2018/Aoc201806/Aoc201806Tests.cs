namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201806;

public class Aoc201806Tests
{
    [Fact]
    public void FindsLargestArea()
    {
        const string input = """
                             1, 1
                             1, 6
                             8, 3
                             3, 4
                             5, 5
                             8, 9
                             """;

        var finder = new LargestAreaFinder(input);
        var area = finder.GetSizeOfLargestArea();

        area.Should().Be(17);
    }

    [Fact]
    public void FindsAreaOfCentralArea()
    {
        const string input = """
                             1, 1
                             1, 6
                             8, 3
                             3, 4
                             5, 5
                             8, 9
                             """;

        var finder = new LargestAreaFinder(input);
        var area = finder.GetSizeOfCentralArea(32);

        area.Should().Be(16);
    }
}