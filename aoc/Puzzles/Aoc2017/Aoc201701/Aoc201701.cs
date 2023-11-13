using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2017.Aoc201701;

public class Aoc201701 : AocPuzzle
{
    public override string Name => "Inverse Captcha";

    protected override PuzzleResult RunPart1()
    {
        var calc = new CaptchaCalculator(InputFile);
        return new PuzzleResult(calc.Sum1, "a3151100ec696399e5149c71f7bc46c3");
    }

    protected override PuzzleResult RunPart2()
    {
        var calc = new CaptchaCalculator(InputFile);
        return new PuzzleResult(calc.Sum2, "d29f3098be44b414da54304aa4ad0c3f");
    }
}