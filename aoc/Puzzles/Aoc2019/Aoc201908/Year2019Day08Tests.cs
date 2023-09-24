using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2019.Day08;

public class Year2019Day08Tests
{
    [Test]
    public void LayerMatrixIsCorrect()
    {
        const string data = "012011210021";
        const int width = 4;
        var layer = new SpaceImageLayer(data, width);

        Assert.That(layer.GetChar(0, 0), Is.EqualTo('0'));
        Assert.That(layer.GetChar(1, 0), Is.EqualTo('1'));
        Assert.That(layer.GetChar(2, 0), Is.EqualTo('2'));
        Assert.That(layer.GetChar(3, 0), Is.EqualTo('0'));

        Assert.That(layer.GetChar(0, 1), Is.EqualTo('1'));
        Assert.That(layer.GetChar(1, 1), Is.EqualTo('1'));
        Assert.That(layer.GetChar(2, 1), Is.EqualTo('2'));
        Assert.That(layer.GetChar(3, 1), Is.EqualTo('1'));

        Assert.That(layer.GetChar(0, 2), Is.EqualTo('0'));
        Assert.That(layer.GetChar(1, 2), Is.EqualTo('0'));
        Assert.That(layer.GetChar(2, 2), Is.EqualTo('2'));
        Assert.That(layer.GetChar(3, 2), Is.EqualTo('1'));
    }
}