using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202123Tests : PuzzleTest<Aoc202123>
{
    [Fact]
    public void Moving()
    {
        var amphipods = new Aoc202123.Amphipods(Input2, true);
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