using ConsoleApp.Puzzles.Year2015.Day19;
using NUnit.Framework;

namespace Tests
{
    public class MedicineNuclearPlantTests
    {
        [Test]
        public void FindsDistinctMolecules()
        {
            const string startMolecule = "HOH";
            const string input = @"
H => HO
H => OH
O => HH";

            var machine = new MedicineMachine(input);
            var molecules = machine.GetCalibrationMolecules(startMolecule);

            Assert.That(molecules.Count, Is.EqualTo(4));
        }

        [TestCase("HOH", 3)]
        [TestCase("HOHOHO", 6)]
        public void TimeToMakeMolecule(string molecule, int steps)
        {
            const string input = @"
e => H
e => O
H => HO
H => OH
O => HH";

            var machine = new MedicineMachine(input);
            var stepCount = machine.StepsToMake(molecule);

            Assert.That(stepCount, Is.EqualTo(steps));
        }
    }
}