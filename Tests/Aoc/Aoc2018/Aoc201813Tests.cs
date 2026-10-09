using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201813Tests : PuzzleTest<Aoc201813>
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

        Sut.Part1(input).Should().Be("7,3");
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
    
        Sut.Part2(input).Should().Be("6,4");
    }
}