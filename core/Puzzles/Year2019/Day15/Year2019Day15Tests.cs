using NUnit.Framework;

namespace Core.Puzzles.Year2019.Day15;

public class Year2019Day15Tests
{
    [Test]
    public void Returns4Minutes()
    {
        const string map = """
 ##   
#..## 
#.#..#
#.X.# 
 ###  
""";

        var filler = new OxygenFiller(map);
        var result = filler.Fill();

        Assert.That(result, Is.EqualTo(4));
    }
}