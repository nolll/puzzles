using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day05;

public class Year2022Day05Tests
{
    [Test]
    public void Part1()
    {
        var crane = new CargoCrane(Input);
        crane.Run1();
        var result = crane.Message;

        Assert.That(result, Is.EqualTo("CMZ"));
    }

    [Test]
    public void Part2()
    {
        var crane = new CargoCrane(Input);
        crane.Run2();
        var result = crane.Message;

        Assert.That(result, Is.EqualTo("MCD"));
    }

    private const string Input = """
    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2
""";
}