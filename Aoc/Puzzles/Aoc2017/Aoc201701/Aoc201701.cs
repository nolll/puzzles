using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201701;

[Name("Inverse Captcha")]
public class Aoc201701 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var calc = new CaptchaCalculator(input);
        return new PuzzleResult(calc.Sum1, "a3151100ec696399e5149c71f7bc46c3");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var calc = new CaptchaCalculator(input);
        return new PuzzleResult(calc.Sum2, "d29f3098be44b414da54304aa4ad0c3f");
    }
}