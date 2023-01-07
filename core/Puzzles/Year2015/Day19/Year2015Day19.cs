using Core.Platform;

namespace Core.Puzzles.Year2015.Day19;

public class Year2015Day19 : Puzzle
{
    public override string Title => "Medicine for Rudolph";

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