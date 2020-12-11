using System;
using Core.MedicineNuclearPlant;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day19 : Day2015
    {
        public Day19() : base(19)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var machine = new MedicineMachine(FileInput);
            var molecules = machine.GetCalibrationMolecules(TargetMolecule);
            return new PuzzleResult($"Molecules: {molecules.Count}");
        }

        public override PuzzleResult RunPart2()
        {
            var machine = new MedicineMachine(FileInput);
            var steps = machine.StepsToMake(TargetMolecule);
            return new PuzzleResult($"Steps to make molecule: {steps}");
        }

        private const string TargetMolecule = "CRnCaCaCaSiRnBPTiMgArSiRnSiRnMgArSiRnCaFArTiTiBSiThFYCaFArCaCaSiThCaPBSiThSiThCaCaPTiRnPBSiThRnFArArCaCaSiThCaSiThSiRnMgArCaPTiBPRnFArSiThCaSiRnFArBCaSiRnCaPRnFArPMgYCaFArCaPTiTiTiBPBSiThCaPTiBPBSiRnFArBPBSiRnCaFArBPRnSiRnFArRnSiRnBFArCaFArCaCaCaSiThSiThCaCaPBPTiTiRnFArCaPTiBSiAlArPBCaCaCaCaCaSiRnMgArCaSiThFArThCaSiThCaSiRnCaFYCaSiRnFYFArFArCaSiRnFYFArCaSiRnBPMgArSiThPRnFArCaSiRnFArTiRnSiRnFYFArCaSiRnBFArCaSiRnTiMgArSiThCaSiThCaFArPRnFArSiRnFArTiTiTiTiBCaCaSiRnCaCaFYFArSiThCaPTiBPTiBCaSiThSiRnMgArCaF";
    }
}