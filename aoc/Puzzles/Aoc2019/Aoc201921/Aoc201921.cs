using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2019.Aoc201921;

public class Aoc201921 : AocPuzzle
{
    public override string Name => "Springdroid Adventure";

    protected override PuzzleResult RunPart1()
    {
        var walkingDroid = new SpringDroid(InputFile, WalkProgram);
        walkingDroid.Run();
        return new PuzzleResult(walkingDroid.HullDamage, "94b1bc03281d28814cbce9dd5bcc5806");
    }

    protected override PuzzleResult RunPart2()
    {
        var runningDroid = new SpringDroid(InputFile, RunProgram);
        runningDroid.Run();
        return new PuzzleResult(runningDroid.HullDamage, "4b70c64b560c7856fb229521380a084d");
    }

    private const string WalkProgram = """
OR A T
AND B T
AND C T
NOT T J
AND D J
WALK
""";

    private const string RunProgram = """
OR A T
AND B T
AND C T
NOT T J
OR E T
OR H T
AND T J
AND D J
RUN
""";
}