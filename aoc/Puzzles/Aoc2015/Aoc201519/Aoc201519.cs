using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Aoc201519;

public class Aoc201519 : AocPuzzle
{
    public override string Name => "Medicine for Rudolph";

    protected override PuzzleResult RunPart1()
    {
        var machine = new MedicineMachine(InputFile);
        var molecules = machine.GetCalibrationMolecules(TargetMolecule);
        return new PuzzleResult(molecules.Count, 535);
    }

    protected override PuzzleResult RunPart2()
    {
        var machine = new MedicineMachine(InputFile);
        var steps = machine.StepsToMake(TargetMolecule);
        return new PuzzleResult(steps, 212);
    }

    private const string TargetMolecule = "CRnCaCaCaSiRnBPTiMgArSiRnSiRnMgArSiRnCaFArTiTiBSiThFYCaFArCaCaSiThCaPBSiThSiThCaCaPTiRnPBSiThRnFArArCaCaSiThCaSiThSiRnMgArCaPTiBPRnFArSiThCaSiRnFArBCaSiRnCaPRnFArPMgYCaFArCaPTiTiTiBPBSiThCaPTiBPBSiRnFArBPBSiRnCaFArBPRnSiRnFArRnSiRnBFArCaFArCaCaCaSiThSiThCaCaPBPTiTiRnFArCaPTiBSiAlArPBCaCaCaCaCaSiRnMgArCaSiThFArThCaSiThCaSiRnCaFYCaSiRnFYFArFArCaSiRnFYFArCaSiRnBPMgArSiThPRnFArCaSiRnFArTiRnSiRnFYFArCaSiRnBFArCaSiRnTiMgArSiThCaSiThCaFArPRnFArSiRnFArTiTiTiTiBCaCaSiRnCaCaFYFArSiThCaPTiBPTiBCaSiThSiRnMgArCaF";
}