namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202518;

public class Codyssi202518Tests
{
    private const string Input1 = """
                                  RULE 1: 8x+2y+3z+5a DIVIDE 9 HAS REMAINDER 4 | DEBRIS VELOCITY (0, -1, 0, 1)
                                  RULE 2: 4x+7y+10z+9a DIVIDE 5 HAS REMAINDER 4 | DEBRIS VELOCITY (0, 1, 0, 1)
                                  RULE 3: 6x+3y+7z+3a DIVIDE 4 HAS REMAINDER 1 | DEBRIS VELOCITY (-1, 0, 1, -1)
                                  RULE 4: 3x+11y+11z+3a DIVIDE 2 HAS REMAINDER 1 | DEBRIS VELOCITY (-1, 1, 0, -1)
                                  """;
    
    private const string Input2 = """
                                  RULE 1: 8x+10y+3z+5a DIVIDE 9 HAS REMAINDER 4 | DEBRIS VELOCITY (0, -1, 0, 1)
                                  RULE 2: 3x+7y+10z+9a DIVIDE 9 HAS REMAINDER 4 | DEBRIS VELOCITY (0, 1, 0, 1)
                                  RULE 3: 10x+3y+7z+3a DIVIDE 11 HAS REMAINDER 9 | DEBRIS VELOCITY (-1, 0, 1, -1)
                                  RULE 4: 5x+4y+9z+3a DIVIDE 7 HAS REMAINDER 2 | DEBRIS VELOCITY (0, -1, -1, -1)
                                  RULE 5: 3x+11y+11z+3a DIVIDE 3 HAS REMAINDER 1 | DEBRIS VELOCITY (-1, 1, 0, -1)
                                  RULE 6: 4x+6y+7z+3a DIVIDE 8 HAS REMAINDER 6 | DEBRIS VELOCITY (0, -1, 0, -1)
                                  RULE 7: 7x+4y+3z+7a DIVIDE 11 HAS REMAINDER 5 | DEBRIS VELOCITY (0, 1, 0, -1)
                                  RULE 8: 3x+6y+9z+9a DIVIDE 5 HAS REMAINDER 3 | DEBRIS VELOCITY (1, 1, -1, -1)
                                  """;

    [Fact]
    public void Part1_1() => Sut.Part1(Input1, 3, 3, 5).Answer.Should().Be("146");
    
    [Fact]
    public void Part1_2() => Sut.Part1(Input2).Answer.Should().Be("32545");

    [Fact]
    public void Part2_1() => Sut.Part2(Input1, 3, 3, 5).Answer.Should().Be("23");
    
    [Fact]
    public void Part2_2() => Sut.Part2(Input2).Answer.Should().Be("217");

    [Fact]
    public void Part3_1() => Sut.Part3(Input1, 3, 3, 5).Answer.Should().Be("8");
    
    [Fact]
    public void Part3_2() => Sut.Part3(Input2).Answer.Should().Be("166");

    private static Codyssi202518 Sut => new();
}