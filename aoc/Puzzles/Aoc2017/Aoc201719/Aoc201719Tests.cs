using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2017.Aoc201719;

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

        Assert.That(finder.Route, Is.EqualTo("ABCDEF"));
        Assert.That(finder.StepCount, Is.EqualTo(38));
    }
}