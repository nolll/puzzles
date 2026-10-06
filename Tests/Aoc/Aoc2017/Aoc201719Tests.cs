using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201719Tests : PuzzleTest<Aoc201719>
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
        
        var (route, stepCount) = Sut.FindRoute(input);

        route.Should().Be("ABCDEF");
        stepCount.Should().Be(38);
    }
}