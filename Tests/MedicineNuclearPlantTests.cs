using Core.MedicineNuclearPlant;
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
    }
}