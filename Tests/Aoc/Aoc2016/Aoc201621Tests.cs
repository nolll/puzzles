using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201621Tests :  PuzzleTest<Aoc201621>
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

        Sut.Scramble(input, "abcde").Should().Be("decab");
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

        Sut.Unscramble(input, "decab").Should().Be("abcde");
    }
}