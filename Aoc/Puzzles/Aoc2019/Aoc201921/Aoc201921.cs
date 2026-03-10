using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201921;

[Name("Springdroid Adventure")]
public class Aoc201921 : AocPuzzle
{
    [Puzzle("94b1bc03281d28814cbce9dd5bcc5806")]
    public PuzzleResult RunPart1(string input)
    {
        var walkingDroid = new SpringDroid(input, WalkProgram);
        walkingDroid.Run();
        return new PuzzleResult(walkingDroid.HullDamage);
    }

    [Puzzle("4b70c64b560c7856fb229521380a084d")]
    public PuzzleResult Part2(string input)
    {
        var runningDroid = new SpringDroid(input, RunProgram);
        runningDroid.Run();
        return new PuzzleResult(runningDroid.HullDamage);
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