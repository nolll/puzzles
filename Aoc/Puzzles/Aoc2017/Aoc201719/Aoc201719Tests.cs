using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201719;

public class Aoc201719Tests
{
    [Test]
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

        var finder = new TubeRouteFinder(input);
        finder.FindRoute();

        finder.Route.Should().Be("ABCDEF");
        finder.StepCount.Should().Be(38);
    }
}