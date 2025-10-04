namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202517;

public class Codyssi202517Tests
{
    private const string Input1 = """
                                  S1 : 0 -> 6 : FROM START TO END
                                  S2 : 2 -> 3 : FROM S1 TO S1

                                  Possible Moves : 1, 3
                                  """;

    private const string Input2 = """
                                  S1 : 0 -> 6 : FROM START TO END
                                  S2 : 2 -> 4 : FROM S1 TO S1
                                  S3 : 3 -> 5 : FROM S2 TO S1
                                  
                                  Possible Moves : 1, 2
                                  """;

    private const string Input3 = """
                                  S1 : 0 -> 99 : FROM START TO END
                                  S2 : 8 -> 91 : FROM S1 TO S1
                                  S3 : 82 -> 91 : FROM S1 TO S1
                                  S4 : 90 -> 97 : FROM S2 TO S1
                                  S5 : 29 -> 74 : FROM S1 TO S1
                                  S6 : 87 -> 90 : FROM S3 TO S2
                                  S7 : 37 -> 71 : FROM S2 TO S1
                                  S8 : 88 -> 90 : FROM S6 TO S3
                                  S9 : 34 -> 37 : FROM S2 TO S5
                                  S10 : 13 -> 57 : FROM S1 TO S2
                                  
                                  Possible Moves : 1, 3, 5, 6
                                  """;

    [Fact]
    public void Part1_1() => Sut.Part1(Input1).Answer.Should().Be("6");
    
    [Fact]
    public void Part1_2() => Sut.Part1(Input2).Answer.Should().Be("13");

    [Fact]
    public void Part2_1() => Sut.Part2(Input1).Answer.Should().Be("17");
    
    [Fact]
    public void Part2_2() => Sut.Part2(Input2).Answer.Should().Be("102");

    [Fact]
    public void Part3_1() => Sut.Part3(Input1).Answer.Should().Be("S1_0-S2_2-S2_3-S1_5-S1_6");
    
    [Fact]
    public void Part3_2() => Sut.Part3(Input2).Answer.Should().Be("S1_0-S1_2-S2_3-S3_4-S3_5-S1_6");
    
    [Fact]
    public void Part3_3() => Sut.Part3(Input3).Answer.Should()
        .Be("S1_0-S1_6-S2_11-S2_17-S2_23-S2_29-S9_34-S9_37-S5_42-S5_48-S5_54-S5_60-S5_66-S5_72-S5_73-S5_74-S1_79-S3_84-S8_88-S8_89-S8_90-S3_90-S3_91-S1_96-S1_99");

    private static Codyssi202517 Sut => new();
}