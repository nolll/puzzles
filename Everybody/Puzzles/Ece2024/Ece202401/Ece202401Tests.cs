namespace Pzl.Everybody.Puzzles.Ece2024.Ece202401;

public class Ece202401Tests
{
    [Fact]
    public void OneCreature()
    {
        const string input = "ABBAC";
        var result = Sut.RunPart1(input);

        result.Answer.Should().Be("5");
    }
    
    [Fact]
    public void TwoCreatures()
    {
        const string input = "AxBCDDCAxD";
        var result = Sut.RunPart2(input);

        result.Answer.Should().Be("28");
    }
    
    [Fact]
    public void ThreeCreatures()
    {
        const string input = "xBxAAABCDxCC";
        var result = Sut.RunPart3(input);

        result.Answer.Should().Be("30");
    }
    
    private static Ece202401 Sut => new();
}