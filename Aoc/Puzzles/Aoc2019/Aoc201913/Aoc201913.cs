using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201913;

[Name("Care Package")]
public class Aoc201913 : AocPuzzle
{
    [Puzzle("65621a57e5ba6bbdc37540f0d2320098")]
    public int Part1(string input)
    {
        var arcade = new Arcade(input);
        arcade.Play();

        return arcade.NumberOfBlockTiles;
    }

    [Puzzle("6c32f2b8d2a26180534728ccb213e116")]
    public int Part2(string input)
    {
        var arcade = new Arcade(input);
        arcade.Play(2);

        return arcade.Score;
    }
}