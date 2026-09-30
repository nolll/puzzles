using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201523Tests : PuzzleTest<Aoc201523>
{
    [Fact]
    public void RegisterAContains2()
    {
        const string input = """
                             inc a
                             jio a, +2
                             tpl a
                             inc a
                             """;
        
        Sut.Run([], input)['a'].Should().Be(2);
    }
}