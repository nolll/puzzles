using System.Text;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201519;

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