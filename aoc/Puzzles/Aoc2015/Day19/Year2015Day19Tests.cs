using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Day19;

public class Year2015Day19Tests
{
    [Test]
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

        Assert.That(molecules.Count, Is.EqualTo(4));
    }

    [TestCase("HOH", 3)]
    [TestCase("HOHOHO", 6)]
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

        Assert.That(stepCount, Is.EqualTo(steps));
    }
}