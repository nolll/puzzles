using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2021.Aoc202123;

public class Aoc202123 : AocPuzzle
{
    public override string Name => "Amphipod";
    public override bool NeedsRewrite => true;
    public override string Comment => "Solved manually";

    protected override PuzzleResult RunPart1()
    {
        var amphipods = new Amphipods(Input1);
        amphipods.ArrangePart1();
        var result = amphipods.Energy;

        return new PuzzleResult(result, "8547c3b85863d2e52d88fad570aefbe9");
    }

    protected override PuzzleResult RunPart2()
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