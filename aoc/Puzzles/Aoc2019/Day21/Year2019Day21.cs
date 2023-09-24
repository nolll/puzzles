using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2019.Day21;

public class Year2019Day21 : AocPuzzle
{
    public override string Name => "Springdroid Adventure";

    protected override PuzzleResult RunPart1()
    {
        var walkingDroid = new SpringDroid(InputFile, WalkProgram);
        walkingDroid.Run();
        return new PuzzleResult(walkingDroid.HullDamage, 19_362_822);
    }

    protected override PuzzleResult RunPart2()
    {
        var runningDroid = new SpringDroid(InputFile, RunProgram);
        runningDroid.Run();
        return new PuzzleResult(runningDroid.HullDamage, 1_143_625_214);
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