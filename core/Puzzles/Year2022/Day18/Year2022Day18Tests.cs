using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day18;

public class Year2022Day18Tests
{
    [Test]
    public void Part1Small()
    {
        var lavaCubes = new LavaCubes();
        var result = lavaCubes.Part1(SmallInput);

        Assert.That(result, Is.EqualTo(10));
    }

    [Test]
    public void Part1Large()
    {
        var lavaCubes = new LavaCubes();
        var result = lavaCubes.Part1(LargeInput);

        Assert.That(result, Is.EqualTo(64));
    }

    [Test]
    public void Part2()
    {
        var lavaCubes = new LavaCubes();
        var result = lavaCubes.Part2(LargeInput);

        Assert.That(result, Is.EqualTo(58));
    }

    private const string SmallInput = """
1,1,1
2,1,1
"""; 
    
    private const string LargeInput = """
2,2,2
1,2,2
3,2,2
2,1,2
2,3,2
2,2,1
2,2,3
2,2,4
2,2,6
1,2,5
3,2,5
2,1,5
2,3,5
""";
}