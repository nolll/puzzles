namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201523;

public class Aoc201523Tests
{
    [Fact]
    public void RegisterAContains2()
    {
        const string input = """
                             inc a
                             jio a, +2
                             tpl a
                             inc a
                             """;

        var computer = new ChristmasComputer();
        computer.Run(input.Trim());

        computer.RegisterA.Should().Be(2);
    }
}