using NUnit.Framework;

namespace App.Puzzles.Year2017.Day19;

public class Year2017Day19Tests
{
    [Test]
    public void FindsAllCharacters()
    {
        const string input = @"
_     |          _
_     |  +--+    _
_     A  |  C    _
_ F---|----E|--+ _
_     |  |  |  D _
_     +B-+  +--+ _";

        var finder = new TubeRouteFinder(input);
        finder.FindRoute();

        Assert.That(finder.Route, Is.EqualTo("ABCDEF"));
        Assert.That(finder.StepCount, Is.EqualTo(38));
    }
}