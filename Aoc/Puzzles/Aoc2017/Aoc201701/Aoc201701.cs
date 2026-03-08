using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201701;

[Name("Inverse Captcha")]
public class Aoc201701 : AocPuzzle
{
    [Puzzle("a3151100ec696399e5149c71f7bc46c3")]
    public int Part1(string input) => new CaptchaCalculator(input).Sum1;

    [Puzzle("d29f3098be44b414da54304aa4ad0c3f")]
    public int Part2(string input) => new CaptchaCalculator(input).Sum2;
}