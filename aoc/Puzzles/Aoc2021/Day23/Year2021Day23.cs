using Common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day23;

public class Year2021Day23 : AocPuzzle
{
    public override string Name => "Amphipod";
    public override string Comment => "Solved manually";

    protected override PuzzleResult RunPart1()
    {
        var amphipods = new Amphipods(Input1);
        amphipods.ArrangePart1();
        var result = amphipods.Energy;

        return new PuzzleResult(result, 11120);
    }

    protected override PuzzleResult RunPart2()
    {
        var amphipods = new Amphipods(Input2);
        amphipods.ArrangePart2();
        var result = amphipods.Energy;

        return new PuzzleResult(result, 49232);
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