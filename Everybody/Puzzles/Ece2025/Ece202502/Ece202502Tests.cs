namespace Pzl.Everybody.Puzzles.Ece2025.Ece202502;

public class Ece202502Tests
{
    [Fact]
    public void Part1() => Sut.Part1("A=[25,9]").Should().Be("[357,862]");

    [Theory]
    [InlineData(35630, -64880)]
    [InlineData(35630, -64870)]
    [InlineData(35640, -64860)]
    [InlineData(36230, -64270)]
    [InlineData(36250, -64270)]
    public void ShouldBeEngraved(long x, long y) => Ece202502.ShouldBeEngraved(x, y).Should().BeTrue();
    
    [Theory]
    [InlineData(35460, -64910)]
    [InlineData(35470, -64910)]
    [InlineData(35480, -64910)]
    [InlineData(35680, -64850)]
    [InlineData(35630, -64830)]
    public void ShouldNotBeEngraved(long x, long y) => Ece202502.ShouldBeEngraved(x, y).Should().BeFalse();
    
    [Fact]
    public void Part2() => Sut.Part2("A=[35300,-64910]").Should().Be(4076);

    [Fact]
    public void Part3() => Sut.Part3("A=[35300,-64910]").Should().Be(406954);

    private static Ece202502 Sut => new();
}