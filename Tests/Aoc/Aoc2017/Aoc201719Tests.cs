using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201719Tests
{
    [Fact]
    public void FindsAllCharacters()
    {
        const string input = """
                                  |          
                                  |  +--+    
                                  A  |  C    
                              F---|----E|--+ 
                                  |  |  |  D 
                                  +B-+  +--+ 
                             """;

        var finder = new Aoc201719.TubeRouteFinder(input);
        finder.FindRoute();

        finder.Route.Should().Be("ABCDEF");
        finder.StepCount.Should().Be(38);
    }
}