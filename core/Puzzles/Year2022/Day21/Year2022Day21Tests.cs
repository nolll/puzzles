using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day21;

public class Year2022Day21Tests
{
    [Test]
    public void Part1()
    {
        var result = new Year2022Day21().Part1(Input);

        Assert.That(result, Is.EqualTo(152));
    }

    //[Test]
    //public void Part2Naive()
    //{
    //    var result = new Year2022Day21().Part2Naive(Input);

    //    Assert.That(result, Is.EqualTo(301));
    //}

    [Test]
    public void Part2()
    {
        var result = new Year2022Day21().Part2(Input);

        Assert.That(result, Is.EqualTo(301));
    }

    private const string Input = """
root: pppw + sjmn
dbpl: 5
cczh: sllz + lgvd
zczc: 2
ptdq: humn - dvpt
dvpt: 3
lfqf: 4
humn: 5
ljgn: 2
sjmn: drzm * dbpl
sllz: 4
pppw: cczh / lfqf
lgvd: ljgn * ptdq
drzm: hmdt - zczc
hmdt: 32
""";
}