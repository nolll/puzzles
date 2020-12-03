using System;
using Core.MedicineNuclearPlant;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day19 : Day2015
    {
        public Day19() : base(19)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var machine = new MedicineMachine(FileInput);
            var molecules = machine.GetCalibrationMolecules(TargetMolecule);
            Console.WriteLine($"Molecules: {molecules.Count}");

            WritePartTitle();
            var steps = machine.StepsToMake(TargetMolecule);
            Console.WriteLine($"Steps to make molecule: {steps}");
        }

        private const string TargetMolecule = "CRnCaCaCaSiRnBPTiMgArSiRnSiRnMgArSiRnCaFArTiTiBSiThFYCaFArCaCaSiThCaPBSiThSiThCaCaPTiRnPBSiThRnFArArCaCaSiThCaSiThSiRnMgArCaPTiBPRnFArSiThCaSiRnFArBCaSiRnCaPRnFArPMgYCaFArCaPTiTiTiBPBSiThCaPTiBPBSiRnFArBPBSiRnCaFArBPRnSiRnFArRnSiRnBFArCaFArCaCaCaSiThSiThCaCaPBPTiTiRnFArCaPTiBSiAlArPBCaCaCaCaCaSiRnMgArCaSiThFArThCaSiThCaSiRnCaFYCaSiRnFYFArFArCaSiRnFYFArCaSiRnBPMgArSiThPRnFArCaSiRnFArTiRnSiRnFYFArCaSiRnBFArCaSiRnTiMgArSiThCaSiThCaFArPRnFArSiRnFArTiTiTiTiBCaCaSiRnCaCaFYFArSiThCaPTiBPTiBCaSiThSiRnMgArCaF";
    }
}