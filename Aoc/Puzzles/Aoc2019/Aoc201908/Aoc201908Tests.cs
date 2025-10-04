namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201908;

public class Aoc201908Tests
{
    [Fact]
    public void LayerMatrixIsCorrect()
    {
        const string data = "012011210021";
        const int width = 4;
        var layer = new SpaceImageLayer(data, width);

        layer.GetChar(0, 0).Should().Be('0');
        layer.GetChar(1, 0).Should().Be('1');
        layer.GetChar(2, 0).Should().Be('2');
        layer.GetChar(3, 0).Should().Be('0');

        layer.GetChar(0, 1).Should().Be('1');
        layer.GetChar(1, 1).Should().Be('1');
        layer.GetChar(2, 1).Should().Be('2');
        layer.GetChar(3, 1).Should().Be('1');

        layer.GetChar(0, 2).Should().Be('0');
        layer.GetChar(1, 2).Should().Be('0');
        layer.GetChar(2, 2).Should().Be('2');
        layer.GetChar(3, 2).Should().Be('1');
    }
}