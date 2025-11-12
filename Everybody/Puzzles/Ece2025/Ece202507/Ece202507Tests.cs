namespace Pzl.Everybody.Puzzles.Ece2025.Ece202507;

public class Ece202507Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             Oronris,Urakris,Oroneth,Uraketh
                             
                             r > a,i,o
                             i > p,w
                             n > e,r
                             o > n,m
                             k > f,r
                             a > k
                             U > r
                             e > t
                             O > r
                             t > h
                             """;

        Sut.Part1(input).Answer.Should().Be("Oroneth");
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             Xanverax,Khargyth,Nexzeth,Helther,Braerex,Tirgryph,Kharverax
                             
                             r > v,e,a,g,y
                             a > e,v,x,r
                             e > r,x,v,t
                             h > a,e,v
                             g > r,y
                             y > p,t
                             i > v,r
                             K > h
                             v > e
                             B > r
                             t > h
                             N > e
                             p > h
                             H > e
                             l > t
                             z > e
                             X > a
                             n > v
                             x > z
                             T > i
                             """;

        Sut.Part2(input).Answer.Should().Be("23");
    }

    [Fact]
    public void Part3_1()
    {
        const string input = """
                             Xaryt
                             
                             X > a,o
                             a > r,t
                             r > y,e,a
                             h > a,e,v
                             t > h
                             v > e
                             y > p,t
                             """;

        Sut.Part3(input).Answer.Should().Be("25");
    }
    
    [Fact]
    public void Part3_2()
    {
        const string input = """
                             Khara,Xaryt,Noxer,Kharax
                             
                             r > v,e,a,g,y
                             a > e,v,x,r,g
                             e > r,x,v,t
                             h > a,e,v
                             g > r,y
                             y > p,t
                             i > v,r
                             K > h
                             v > e
                             B > r
                             t > h
                             N > e
                             p > h
                             H > e
                             l > t
                             z > e
                             X > a
                             n > v
                             x > z
                             T > i
                             """;

        Sut.Part3(input).Answer.Should().Be("1154");
    }

    private static Ece202507 Sut => new();
}