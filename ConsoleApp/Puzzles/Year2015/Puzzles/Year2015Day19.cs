using Core.MedicineNuclearPlant;

namespace ConsoleApp.Puzzles.Year2015.Puzzles
{
    public class Year2015Day19 : Year2015Day
    {
        public override int Day => 19;

        public override PuzzleResult RunPart1()
        {
            var machine = new MedicineMachine(FileInput);
            var molecules = machine.GetCalibrationMolecules(TargetMolecule);
            return new PuzzleResult(molecules.Count, 535);
        }

        public override PuzzleResult RunPart2()
        {
            var machine = new MedicineMachine(FileInput);
            var steps = machine.StepsToMake(TargetMolecule);
            return new PuzzleResult(steps, 212);
        }

        private const string TargetMolecule = "CRnCaCaCaSiRnBPTiMgArSiRnSiRnMgArSiRnCaFArTiTiBSiThFYCaFArCaCaSiThCaPBSiThSiThCaCaPTiRnPBSiThRnFArArCaCaSiThCaSiThSiRnMgArCaPTiBPRnFArSiThCaSiRnFArBCaSiRnCaPRnFArPMgYCaFArCaPTiTiTiBPBSiThCaPTiBPBSiRnFArBPBSiRnCaFArBPRnSiRnFArRnSiRnBFArCaFArCaCaCaSiThSiThCaCaPBPTiTiRnFArCaPTiBSiAlArPBCaCaCaCaCaSiRnMgArCaSiThFArThCaSiThCaSiRnCaFYCaSiRnFYFArFArCaSiRnFYFArCaSiRnBPMgArSiThPRnFArCaSiRnFArTiRnSiRnFYFArCaSiRnBFArCaSiRnTiMgArSiThCaSiThCaFArPRnFArSiRnFArTiTiTiTiBCaCaSiRnCaCaFYFArSiThCaPTiBPTiBCaSiThSiRnMgArCaF";
    }
}