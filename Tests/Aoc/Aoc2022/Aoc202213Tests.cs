using Pzl.Aoc.Puzzles.Aoc2022;

namespace Tests.Aoc.Aoc2022;

public class Aoc202213Tests : PuzzleTest<Aoc202213>
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(13);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(140);

    private const string Input = """
                                 [1,1,3,1,1]
                                 [1,1,5,1,1]

                                 [[1],[2,3,4]]
                                 [[1],4]

                                 [9]
                                 [[8,7,6]]

                                 [[4,4],4,4]
                                 [[4,4],4,4,4]

                                 [7,7,7,7]
                                 [7,7,7]

                                 []
                                 [3]

                                 [[[]]]
                                 [[]]

                                 [1,[2,[3,[4,[5,6,7]]]],8,9]
                                 [1,[2,[3,[4,[5,6,0]]]],8,9]
                                 """;
}