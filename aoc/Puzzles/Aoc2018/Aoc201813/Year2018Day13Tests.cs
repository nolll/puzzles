using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2018.Aoc201813;

public class Year2018Day13Tests
{
    [Test]
    public void LocationOfFirstCollision()
    {
        const string input = """
/->-\        
|   |  /----\
| /-+--+-\  |
| | |  | v  |
\-+-/  \-+--/
  \------/   
""";

        var detector = new CollisionDetector(input);
        detector.RunCarts();
        var coords = detector.LocationOfFirstCollision;

        var str = $"{coords!.X},{coords.Y}";
        Assert.That(str, Is.EqualTo("7,3"));
    }

    [Test]
    public void LocationOfLastCart()
    {
        const string input = """
/>-<\  
|   |  
| /<+-\
| | | v
\>+</ |
  |   ^
  \<->/
""";

        var detector = new CollisionDetector(input);
        detector.RunCarts();
        var coords = detector.LocationOfLastCart;

        var str = $"{coords!.X},{coords.Y}";
        Assert.That(str, Is.EqualTo("6,4"));
    }
}