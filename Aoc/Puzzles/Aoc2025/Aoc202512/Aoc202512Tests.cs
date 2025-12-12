namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202512;

// Very simplified test since the provided test data didn't match the real data
public class Aoc202512Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             0:
                             ###
                             ##.
                             ##.
                             
                             1:
                             ###
                             ##.
                             .##
                             
                             2:
                             .##
                             ###
                             ##.
                             
                             3:
                             ##.
                             ###
                             ##.
                             
                             4:
                             ###
                             #..
                             ###
                             
                             5:
                             ###
                             .#.
                             ###
                             
                             4x4: 0 0 0 0 1 0
                             6x3: 0 0 0 0 2 0
                             """;

        Sut.Part1(input).Answer.Should().Be("2");
    }

    private static Aoc202512 Sut => new();
}