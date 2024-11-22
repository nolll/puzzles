using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202123;

public class Aoc202123Tests
{
    [Test]
    public void Moving()
    {
        var amphipods = new Amphipods(Input2, true);
        amphipods.TestArrange();
        var result = amphipods.Energy;

        result.Should().Be(44169);
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