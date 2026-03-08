using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201519;

[Name("Medicine for Rudolph")]
public class Aoc201519 : AocPuzzle
{
    [Puzzle("77a78fac5dfd9115e594172b543d74fd")]
    public int Part1(string input) => new MedicineMachine(input).GetCalibrationMolecules(TargetMolecule).Count;

    [Puzzle("905da6933274380eec1c8efe61ee0350")]
    public int Part2(string input) => new MedicineMachine(input).StepsToMake(TargetMolecule);

    private const string TargetMolecule = "CRnCaCaCaSiRnBPTiMgArSiRnSiRnMgArSiRnCaFArTiTiBSiThFYCaFArCaCaSiThCaPBSiThSiThCaCaPTiRnPBSiThRnFArArCaCaSiThCaSiThSiRnMgArCaPTiBPRnFArSiThCaSiRnFArBCaSiRnCaPRnFArPMgYCaFArCaPTiTiTiBPBSiThCaPTiBPBSiRnFArBPBSiRnCaFArBPRnSiRnFArRnSiRnBFArCaFArCaCaCaSiThSiThCaCaPBPTiTiRnFArCaPTiBSiAlArPBCaCaCaCaCaSiRnMgArCaSiThFArThCaSiThCaSiRnCaFYCaSiRnFYFArFArCaSiRnFYFArCaSiRnBPMgArSiThPRnFArCaSiRnFArTiRnSiRnFYFArCaSiRnBFArCaSiRnTiMgArSiThCaSiThCaFArPRnFArSiRnFArTiTiTiTiBCaCaSiRnCaCaFYFArSiThCaPTiBPTiBCaSiThSiRnMgArCaF";
}