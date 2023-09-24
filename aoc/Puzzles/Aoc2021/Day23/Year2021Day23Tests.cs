using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2021.Day23;

public class Year2021Day23Tests
{
    [Test]
    public void Moving()
    {
        var amphipods = new Amphipods(Input2, true);
        amphipods.TestArrange();
        var result = amphipods.Energy;

        Assert.That(result, Is.EqualTo(44169));
    }

    private const string Input2 = """
#############
#...........#
###B#C#B#D###
###D#C#B#A###
###D#B#A#C###
###A#D#C#A###
#############
""";
}