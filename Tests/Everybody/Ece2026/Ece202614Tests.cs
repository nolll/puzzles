using Pzl.Everybody.Puzzles.Ece2026;

namespace Tests.Everybody.Ece2026;

public class Ece202614Tests : PuzzleTest<Ece202614>
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             AAAEEEFFFF
                             AADDDDDGFF
                             BACDDIGGFF
                             BABBIIIGGH
                             BBBBIIIIHH
                             """;

        Sut.Part1(input).Should().Be(67);
    }

    [Fact]
    public void Part2_1()
    {
        const string input = """
                             AAAEEEFFFF
                             AADDDDDGFF
                             BACDDIGGFF
                             BABBIIIGGH
                             BBBBIIIIHH
                             """;

        Sut.Part2(input).Should().Be(12);
    }
    
    [Fact]
    public void Part2_2()
    {
        const string input = """
                             IIIIIILOHHHHHHHHGGGGGQSRRRRKKK
                             IIIIIILOOHHHHHHGGXGGGQSRRRRKKK
                             PPPPILLLOOOODDHBGGGGGQSSRRRKKK
                             PPZPLLLLFFOODDBBBBGGQQQSSRKKKK
                             PPPPLLLLFFFONDDDBBMGGQQSSKKJJJ
                             PPPCCCCCCFFONNDDMMMGQQQSSSKJJJ
                             PCCCCCCCCFFNNDDDDMAAQQQSSSKKJJ
                             PPCCECCCFFNNNNDADMAATQTTSSSJJJ
                             PPEEEEECCFFNNAAAMMATTTTTSTSSSJ
                             PPEEEEEEEFFNNNAAAAAATTTTTTSSJJ
                             """;

        Sut.Part2(input).Should().Be(63);
    }

    [Fact]
    public void Part3_1()
    {
        const string input = """
                             AAAEEEFFFF
                             AADDDDDGFF
                             BACDDIGGFF
                             BABBIIIGGH
                             BBBBIIIIHH
                             """;

        Sut.Part3(input).Should().Be(0);
    }
    
    [Fact]
    public void Part3_2()
    {
        const string input = """
                             IIIIIILOHHHHHHHHGGGGGQSRRRRKKK
                             IIIIIILOOHHHHHHGGXGGGQSRRRRKKK
                             PPPPILLLOOOODDHBGGGGGQSSRRRKKK
                             PPZPLLLLFFOODDBBBBGGQQQSSRKKKK
                             PPPPLLLLFFFONDDDBBMGGQQSSKKJJJ
                             PPPCCCCCCFFONNDDMMMGQQQSSSKJJJ
                             PCCCCCCCCFFNNDDDDMAAQQQSSSKKJJ
                             PPCCECCCFFNNNNDADMAATQTTSSSJJJ
                             PPEEEEECCFFNNAAAMMATTTTTSTSSSJ
                             PPEEEEEEEFFNNNAAAAAATTTTTTSSJJ
                             """;

        Sut.Part3(input).Should().Be(21);
    }
}