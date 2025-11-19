namespace Pzl.Everybody.Puzzles.Ece2025.Ece202512;

public class Ece202512Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             989601
                             857782
                             746543
                             766789
                             """;

        Sut.Part1(input).Answer.Should().Be("16");
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             9589233445
                             9679121695
                             8469121876
                             8352919876
                             7342914327
                             7234193437
                             6789193538
                             6781219648
                             5691219769
                             5443329859
                             """;

        Sut.Part2(input).Answer.Should().Be("58");
    }

    [Fact]
    public void Part3_1()
    {
        const string input = """
                             5411
                             3362
                             5235
                             3112
                             """;

        Sut.Part3(input).Answer.Should().Be("14");
    }
    
    [Fact]
    public void Part3_2()
    {
        const string input = """
                             41951111131882511179
                             32112222211518122215
                             31223333322115122219
                             31234444432147511128
                             91223333322176121892
                             61112222211166431583
                             14661111166111111746
                             11111119142122222177
                             41222118881233333219
                             71222127839122222196
                             56111126279711111517
                             """;

        Sut.Part3(input).Answer.Should().Be("136");
    }

    private static Ece202512 Sut => new();
}