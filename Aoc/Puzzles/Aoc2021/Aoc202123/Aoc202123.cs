using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202123;

[NeedsRewrite]
[Name("Amphipod")]
[Comment("Solved by hand")]
public class Aoc202123 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var amphipods = new Amphipods(Input1);
        amphipods.ArrangePart1();
        var result = amphipods.Energy;

        return new PuzzleResult(result, "8547c3b85863d2e52d88fad570aefbe9");
    }

    public PuzzleResult RunPart2(string input)
    {
        var amphipods = new Amphipods(Input2);
        amphipods.ArrangePart2();
        var result = amphipods.Energy;

        return new PuzzleResult(result, "afb93cd8fe6106e1b659d77f58b53c61");
    }

    private const string Input1 = """
                                  #############
                                  #...........#
                                  ###B#C#A#D###
                                  ###B#C#D#A###
                                  #############
                                  """;

    private const string Input2 = """
                                  #############
                                  #...........#
                                  ###B#C#A#D###
                                  ###D#C#B#A###
                                  ###D#B#A#C###
                                  ###B#C#D#A###
                                  #############
                                  """;
}