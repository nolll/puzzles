namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201621;

public class Aoc201621Tests
{
    [Fact]
    public void CorrectScramble()
    {
        const string input = """
                             swap position 4 with position 0
                             swap letter d with letter b
                             reverse positions 0 through 4
                             rotate left 1 step
                             move position 1 to position 4
                             move position 3 to position 0
                             rotate based on position of letter b
                             rotate based on position of letter d
                             """;

        const string pwd = "abcde";

        var scrambler = new StringScrambler(input.Trim());
        var result = scrambler.Scramble(pwd);

        result.Should().Be("decab");
    }

    [Fact]
    public void CorrectUnscramble()
    {
        const string input = """
                             swap position 4 with position 0
                             swap letter d with letter b
                             reverse positions 0 through 4
                             rotate left 1 step
                             move position 1 to position 4
                             move position 3 to position 0
                             rotate based on position of letter b
                             rotate based on position of letter d
                             """;

        const string pwd = "decab";

        var scrambler = new StringScrambler(input.Trim());
        var result = scrambler.Unscramble(pwd);

        result.Should().Be("abcde");
    }
}