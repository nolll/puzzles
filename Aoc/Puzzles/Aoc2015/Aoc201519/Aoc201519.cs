using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201519;

[Name("Medicine for Rudolph")]
public class Aoc201519(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var machine = new MedicineMachine(Input);
        var molecules = machine.GetCalibrationMolecules(TargetMolecule);
        return new PuzzleResult(molecules.Count, "77a78fac5dfd9115e594172b543d74fd");
    }

    protected override PuzzleResult RunPart2()
    {
        var machine = new MedicineMachine(Input);
        var steps = machine.StepsToMake(TargetMolecule);
        return new PuzzleResult(steps, "905da6933274380eec1c8efe61ee0350");
    }

    private const string TargetMolecule = "CRnCaCaCaSiRnBPTiMgArSiRnSiRnMgArSiRnCaFArTiTiBSiThFYCaFArCaCaSiThCaPBSiThSiThCaCaPTiRnPBSiThRnFArArCaCaSiThCaSiThSiRnMgArCaPTiBPRnFArSiThCaSiRnFArBCaSiRnCaPRnFArPMgYCaFArCaPTiTiTiBPBSiThCaPTiBPBSiRnFArBPBSiRnCaFArBPRnSiRnFArRnSiRnBFArCaFArCaCaCaSiThSiThCaCaPBPTiTiRnFArCaPTiBSiAlArPBCaCaCaCaCaSiRnMgArCaSiThFArThCaSiThCaSiRnCaFYCaSiRnFYFArFArCaSiRnFYFArCaSiRnBPMgArSiThPRnFArCaSiRnFArTiRnSiRnFYFArCaSiRnBFArCaSiRnTiMgArSiThCaSiThCaFArPRnFArSiRnFArTiTiTiTiBCaCaSiRnCaCaFYFArSiThCaPTiBPTiBCaSiThSiRnMgArCaF";
}