using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201519;

public class MedicineMachine
{
    private readonly IEnumerable<MoleculeReplacement> _replacements;

    public MedicineMachine(string input)
    {
        _replacements = StringReader.ReadLines(input).Select(ParseReplacement).OrderByDescending(o => o.Right.Length).ThenBy(o => o.Right);
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
                if (pos >= 0)
                {
                    molecule = ReplaceFirst(molecule, replacement.Right, replacement.Left);
                    steps++;
                    break;
                }
            }
        }

        return steps;
    }

    private string ReplaceFirst(string text, string search, string replace)
    {
        var pos = text.IndexOf(search, StringComparison.InvariantCulture);
        if (pos < 0)
            return text;
        return string.Concat(text.Substring(0, pos), replace, text.Substring(pos + search.Length));
    }

    private MoleculeReplacement ParseReplacement(string s)
    {
        var parts = s.Split(" => ");
        var input = parts[0];
        var output = parts[1];
        return new MoleculeReplacement(input, output);
    }
}