using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201904;

[Name("Secure Container")]
public class Aoc201904 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var passwordBounds = input.Split('-');
        var passwordLowerbound = int.Parse(passwordBounds[0]);
        var passwordUpperbound = int.Parse(passwordBounds[1]);

        var passwordFinder = new PasswordFinder();
        var passwords = passwordFinder.FindPart1(passwordLowerbound, passwordUpperbound);
        var passwordCount = passwords.Count();
        return new PuzzleResult(passwordCount, "130c5099df019116c1fa98e589523b7c");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var passwordBounds = input.Split('-');
        var passwordLowerbound = int.Parse(passwordBounds[0]);
        var passwordUpperbound = int.Parse(passwordBounds[1]);

        var passwordFinder = new PasswordFinder();
        var passwords = passwordFinder.FindPart2(passwordLowerbound, passwordUpperbound);
        var passwordCount = passwords.Count();
        return new PuzzleResult(passwordCount, "a91290a19800def81b170a8a45592c43");
    }
}