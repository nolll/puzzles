using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2022.Aoc202209;

public class Year2022Day09Tests
{
    [Test]
    public void Part1()
    {
        var ropeBridge = new RopeBridge();
        var result = ropeBridge.Part1(Input1);

        Assert.That(result, Is.EqualTo(13));
    }

    [Test]
    public void Part2Example1()
    {
        var ropeBridge = new RopeBridge();
        var result = ropeBridge.Part2(Input1);

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Part2Example2()
    {
        var ropeBridge = new RopeBridge();
        var result = ropeBridge.Part2(Input2);

        Assert.That(result, Is.EqualTo(36));
    }

    private const string Input1 = """
R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2
"""; 
    
    private const string Input2 = """
R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20
""";
}