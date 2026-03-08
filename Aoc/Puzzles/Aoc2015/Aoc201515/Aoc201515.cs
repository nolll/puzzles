using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201515;

[Name("Science for Hungry People")]
public class Aoc201515 : AocPuzzle
{
    [Puzzle("f40d60cbbeb6aff8eff639104c438ab2")]
    public int Part1(string input) => new CookieBakery(input).HighestScore;

    [Puzzle("b617905d91fbff24a49282c5ea2ec636")]
    public int Part2(string input) => new CookieBakery(input).HighestScoreWith500Calories;
}