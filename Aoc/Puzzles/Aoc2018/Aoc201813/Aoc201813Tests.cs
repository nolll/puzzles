namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201813;

public class Aoc201813Tests
{
    [Fact]
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
        str.Should().Be("7,3");
    }

    [Fact]
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
        str.Should().Be("6,4");
    }
}