using System.Text;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("Medicine for Rudolph")]
public class Aoc201519 : AocPuzzle
{
    [Puzzle("77a78fac5dfd9115e594172b543d74fd")]
    public int Part1(string input) => new MedicineMachine(input).GetCalibrationMolecules(TargetMolecule).Count;

    [Puzzle("905da6933274380eec1c8efe61ee0350")]
    public int Part2(string input) => new MedicineMachine(input).StepsToMake(TargetMolecule);

    private const string TargetMolecule = "CRnCaCaCaSiRnBPTiMgArSiRnSiRnMgArSiRnCaFArTiTiBSiThFYCaFArCaCaSiThCaPBSiThSiThCaCaPTiRnPBSiThRnFArArCaCaSiThCaSiThSiRnMgArCaPTiBPRnFArSiThCaSiRnFArBCaSiRnCaPRnFArPMgYCaFArCaPTiTiTiBPBSiThCaPTiBPBSiRnFArBPBSiRnCaFArBPRnSiRnFArRnSiRnBFArCaFArCaCaCaSiThSiThCaCaPBPTiTiRnFArCaPTiBSiAlArPBCaCaCaCaCaSiRnMgArCaSiThFArThCaSiThCaSiRnCaFYCaSiRnFYFArFArCaSiRnFYFArCaSiRnBPMgArSiThPRnFArCaSiRnFArTiRnSiRnFYFArCaSiRnBFArCaSiRnTiMgArSiThCaSiThCaFArPRnFArSiRnFArTiTiTiTiBCaCaSiRnCaCaFYFArSiThCaPTiBPTiBCaSiThSiRnMgArCaF";
    
    public class MedicineMachine
    {
        private readonly IEnumerable<MoleculeReplacement> _replacements;

        public MedicineMachine(string input)
        {
            _replacements = input.Split(LineBreaks.Single)
                .Select(ParseReplacement)
                .OrderByDescending(o => o.Right.Length)
                .ThenBy(o => o.Right);
        }

        public IList<string> GetCalibrationMolecules(string startMolecule)
        {
            var molecules = new List<string>();
            foreach (var replacement in _replacements)
            {
                molecules.AddRange(replacement.Expand(startMolecule));
            }
            return molecules.Distinct().ToList();
        }

        public int StepsToMake(string molecule)
        {
            var steps = 0;
            while (molecule != "e")
            {
                foreach (var replacement in _replacements)
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
    }
    
    internal class MoleculeReplacement(string left, string right)
    {
        public string Left { get; } = left;
        public string Right { get; } = right;

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