namespace Pzl.Everybody.Puzzles.Ece2025.Ece202509;

public class Ece202509Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             1:CAAGCGCTAAGTTCGCTGGATGTGTGCCCGCG
                             2:CTTGAATTGGGCCGTTTACCTGGTTTAACCAT
                             3:CTAGCGCTGAGCTGGCTGCCTGGTTGACCGCG
                             """;

        Sut.Part1(input).Answer.Should().Be("414");
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             1:GCAGGCGAGTATGATACCCGGCTAGCCACCCC
                             2:TCTCGCGAGGATATTACTGGGCCAGACCCCCC
                             3:GGTGGAACATTCGAAAGTTGCATAGGGTGGTG
                             4:GCTCGCGAGTATATTACCGAACCAGCCCCTCA
                             5:GCAGCTTAGTATGACCGCCAAATCGCGACTCA
                             6:AGTGGAACCTTGGATAGTCTCATATAGCGGCA
                             7:GGCGTAATAATCGGATGCTGCAGAGGCTGCTG
                             """;

        Sut.Part2(input).Answer.Should().Be("1245");
    }

    [Fact]
    public void Part3_1()
    {
        const string input = """
                             1:GCAGGCGAGTATGATACCCGGCTAGCCACCCC
                             2:TCTCGCGAGGATATTACTGGGCCAGACCCCCC
                             3:GGTGGAACATTCGAAAGTTGCATAGGGTGGTG
                             4:GCTCGCGAGTATATTACCGAACCAGCCCCTCA
                             5:GCAGCTTAGTATGACCGCCAAATCGCGACTCA
                             6:AGTGGAACCTTGGATAGTCTCATATAGCGGCA
                             7:GGCGTAATAATCGGATGCTGCAGAGGCTGCTG
                             """;

        Sut.Part3(input).Answer.Should().Be("12");
    }
    
    [Fact]
    public void Part3_2()
    {
        const string input = """
                             1:GCAGGCGAGTATGATACCCGGCTAGCCACCCC
                             2:TCTCGCGAGGATATTACTGGGCCAGACCCCCC
                             3:GGTGGAACATTCGAAAGTTGCATAGGGTGGTG
                             4:GCTCGCGAGTATATTACCGAACCAGCCCCTCA
                             5:GCAGCTTAGTATGACCGCCAAATCGCGACTCA
                             6:AGTGGAACCTTGGATAGTCTCATATAGCGGCA
                             7:GGCGTAATAATCGGATGCTGCAGAGGCTGCTG
                             8:GGCGTAAAGTATGGATGCTGGCTAGGCACCCG
                             """;

        Sut.Part3(input).Answer.Should().Be("36");
    }

    private static Ece202509 Sut => new();
}