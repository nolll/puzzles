namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201519;

public class Aoc201519Tests
{
    [Fact]
    public void FindsDistinctMolecules()
    {
        const string startMolecule = "HOH";
        const string input = """
                             H => HO
                             H => OH
                             O => HH
                             """;

        var machine = new MedicineMachine(input.Trim());
        var molecules = machine.GetCalibrationMolecules(startMolecule);

        molecules.Count.Should().Be(4);
    }

    [Theory]
    [InlineData("HOH", 3)]
    [InlineData("HOHOHO", 6)]
    public void TimeToMakeMolecule(string molecule, int steps)
    {
        const string input = """
                             e => H
                             e => O
                             H => HO
                             H => OH
                             O => HH
                             """;

        var machine = new MedicineMachine(input.Trim());
        var stepCount = machine.StepsToMake(molecule);

        stepCount.Should().Be(steps);
    }
}