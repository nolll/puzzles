using System.Text;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("Medicine for Rudolph")]
public class Aoc201519 : AocPuzzle
{
    [Puzzle("77a78fac5dfd9115e594172b543d74fd")]
    public int Part1(string input) => GetCalibrationMoleculeCount(input, TargetMolecule);

    [Puzzle("905da6933274380eec1c8efe61ee0350")]
    public int Part2(string input) => StepsToMake(input, TargetMolecule);

    private const string TargetMolecule = "CRnCaCaCaSiRnBPTiMgArSiRnSiRnMgArSiRnCaFArTiTiBSiThFYCaFArCaCaSiThCaPBSiThSiThCaCaPTiRnPBSiThRnFArArCaCaSiThCaSiThSiRnMgArCaPTiBPRnFArSiThCaSiRnFArBCaSiRnCaPRnFArPMgYCaFArCaPTiTiTiBPBSiThCaPTiBPBSiRnFArBPBSiRnCaFArBPRnSiRnFArRnSiRnBFArCaFArCaCaCaSiThSiThCaCaPBPTiTiRnFArCaPTiBSiAlArPBCaCaCaCaCaSiRnMgArCaSiThFArThCaSiThCaSiRnCaFYCaSiRnFYFArFArCaSiRnFYFArCaSiRnBPMgArSiThPRnFArCaSiRnFArTiRnSiRnFYFArCaSiRnBFArCaSiRnTiMgArSiThCaSiThCaFArPRnFArSiRnFArTiTiTiTiBCaCaSiRnCaCaFYFArSiThCaPTiBPTiBCaSiThSiRnMgArCaF";
    
    public int GetCalibrationMoleculeCount(string input, string startMolecule)
    {
        var replacements = Parse(input);
            
        var molecules = new List<string>();
        foreach (var replacement in replacements)
        {
            molecules.AddRange(replacement.Expand(startMolecule));
        }
        return molecules.Distinct().Count();
    }

    private static MoleculeReplacement[] Parse(string input) => input.Split(LineBreaks.Single)
        .Select(ParseReplacement)
        .OrderByDescending(o => o.Right.Length)
        .ThenBy(o => o.Right)
        .ToArray();

    public int StepsToMake(string input, string molecule)
    {
        var replacements = Parse(input);
        var steps = 0;
        while (molecule != "e")
        {
            foreach (var replacement in replacements)
            {
                var pos = molecule.IndexOf(replacement.Right, StringComparison.InvariantCulture);
                if (pos < 0) 
                    continue;
                
                molecule = ReplaceFirst(molecule, replacement.Right, replacement.Left);
                steps++;
                break;
            }
        }

        return steps;
    }

    private static string ReplaceFirst(string text, string search, string replace)
    {
        var pos = text.IndexOf(search, StringComparison.InvariantCulture);
        return pos < 0 
            ? text 
            : string.Concat(text[..pos], replace, text[(pos + search.Length)..]);
    }

    private static MoleculeReplacement ParseReplacement(string s)
    {
        var (input, output) = s.Split(" => ");
        return new MoleculeReplacement(input, output);
    }

    private record MoleculeReplacement(string Left, string Right)
    {
        public IList<string> Expand(string inputMolecule)
        {
            var molecules = new List<string>();
            var staticParts = inputMolecule.Split(Left);
            if (staticParts.Length < 2)
                return new List<string>();

            var numberOfReplacements = staticParts.Length - 1;
            for (var i = 0; i < numberOfReplacements; i++)
            {
                var sb = new StringBuilder();
                for (var j = 0; j < numberOfReplacements; j++)
                {
                    sb.Append(staticParts[j]);
                    var replacement = i == j ? Right : Left;
                    sb.Append(replacement);
                }

                sb.Append(staticParts.Last());

                molecules.Add(sb.ToString());
            }

            return molecules;
        }
    }
}