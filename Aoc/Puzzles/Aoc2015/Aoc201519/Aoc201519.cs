using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201519;

[Name("Medicine for Rudolph")]
public class Aoc201519 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var machine = new MedicineMachine(input);
        var molecules = machine.GetCalibrationMolecules(TargetMolecule);
        return new PuzzleResult(molecules.Count, "77a78fac5dfd9115e594172b543d74fd");
    }

    public PuzzleResult RunPart2(string input)
    {
        var machine = new MedicineMachine(input);
        var steps = machine.StepsToMake(TargetMolecule);
        return new PuzzleResult(steps, "905da6933274380eec1c8efe61ee0350");
    }

    private const string TargetMolecule = "CRnCaCaCaSiRnBPTiMgArSiRnSiRnMgArSiRnCaFArTiTiBSiThFYCaFArCaCaSiThCaPBSiThSiThCaCaPTiRnPBSiThRnFArArCaCaSiThCaSiThSiRnMgArCaPTiBPRnFArSiThCaSiRnFArBCaSiRnCaPRnFArPMgYCaFArCaPTiTiTiBPBSiThCaPTiBPBSiRnFArBPBSiRnCaFArBPRnSiRnFArRnSiRnBFArCaFArCaCaCaSiThSiThCaCaPBPTiTiRnFArCaPTiBSiAlArPBCaCaCaCaCaSiRnMgArCaSiThFArThCaSiThCaSiRnCaFYCaSiRnFYFArFArCaSiRnFYFArCaSiRnBPMgArSiThPRnFArCaSiRnFArTiRnSiRnFYFArCaSiRnBFArCaSiRnTiMgArSiThCaSiThCaFArPRnFArSiRnFArTiTiTiTiBCaCaSiRnCaCaFYFArSiThCaPTiBPTiBCaSiThSiRnMgArCaF";
}