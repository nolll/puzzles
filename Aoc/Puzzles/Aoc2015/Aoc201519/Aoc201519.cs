using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201519;

public class Aoc201519 : AocPuzzle
{
    public override string Name => "Medicine for Rudolph";

    protected override PuzzleResult RunPart1()
    {
        var machine = new MedicineMachine(InputFile);
        var molecules = machine.GetCalibrationMolecules(TargetMolecule);
        return new PuzzleResult(molecules.Count, "77a78fac5dfd9115e594172b543d74fd");
    }

    protected override PuzzleResult RunPart2()
    {
        var machine = new MedicineMachine(InputFile);
        var steps = machine.StepsToMake(TargetMolecule);
        return new PuzzleResult(steps, "905da6933274380eec1c8efe61ee0350");
    }

    private const string TargetMolecule = "CRnCaCaCaSiRnBPTiMgArSiRnSiRnMgArSiRnCaFArTiTiBSiThFYCaFArCaCaSiThCaPBSiThSiThCaCaPTiRnPBSiThRnFArArCaCaSiThCaSiThSiRnMgArCaPTiBPRnFArSiThCaSiRnFArBCaSiRnCaPRnFArPMgYCaFArCaPTiTiTiBPBSiThCaPTiBPBSiRnFArBPBSiRnCaFArBPRnSiRnFArRnSiRnBFArCaFArCaCaCaSiThSiThCaCaPBPTiTiRnFArCaPTiBSiAlArPBCaCaCaCaCaSiRnMgArCaSiThFArThCaSiThCaSiRnCaFYCaSiRnFYFArFArCaSiRnFYFArCaSiRnBPMgArSiThPRnFArCaSiRnFArTiRnSiRnFYFArCaSiRnBFArCaSiRnTiMgArSiThCaSiThCaFArPRnFArSiRnFArTiTiTiTiBCaCaSiRnCaCaFYFArSiThCaPTiBPTiBCaSiThSiRnMgArCaF";
}