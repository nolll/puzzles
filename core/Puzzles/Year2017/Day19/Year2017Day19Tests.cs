using NUnit.Framework;

namespace Core.Puzzles.Year2017.Day19;

public class Year2017Day19Tests
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