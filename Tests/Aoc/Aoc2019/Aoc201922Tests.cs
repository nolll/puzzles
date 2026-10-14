using Pzl.Aoc.Puzzles.Aoc2019;

namespace Tests.Aoc.Aoc2019;

public class Aoc201922Tests : PuzzleTest<Aoc201922>
{
    [Fact]
    public void DealIntoNewStack() => Sut.Reverse([0, 1, 2, 3, 4, 5, 6, 7, 8, 9]).Should().BeEquivalentTo([9, 8, 7, 6, 5, 4, 3, 2, 1, 0]);

    [Fact]
    public void PositiveCut() => Sut.Cut([0, 1, 2, 3, 4, 5, 6, 7, 8, 9], 3).Should().BeEquivalentTo([3, 4, 5, 6, 7, 8, 9, 0, 1, 2]);

    [Fact]
    public void NegativeCut() => Sut.Cut([0, 1, 2, 3, 4, 5, 6, 7, 8, 9], -4).Should().BeEquivalentTo([6, 7, 8, 9, 0, 1, 2, 3, 4, 5]);

    [Fact]
    public void Increment() => Sut.Increment([0, 1, 2, 3, 4, 5, 6, 7, 8, 9], 3).Should().BeEquivalentTo([0, 7, 4, 1, 8, 5, 2, 9, 6, 3]);

    [Fact]
    public void ShuffleMany()
    {
        const string input = """
                             deal into new stack
                             cut -2
                             deal with increment 7
                             cut 8
                             cut -4
                             deal with increment 7
                             cut 3
                             deal with increment 9
                             deal with increment 3
                             cut -1
                             """;

        Sut.Shuffle(10, input).Should().BeEquivalentTo([9, 2, 5, 8, 1, 4, 7, 0, 3, 6]);
    }
}