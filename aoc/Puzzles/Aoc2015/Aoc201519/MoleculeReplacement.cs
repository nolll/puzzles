using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aoc.Puzzles.Aoc2015.Day19;

internal class MoleculeReplacement
{
    public string Left { get; }
    public string Right { get; }

    public MoleculeReplacement(string left, string right)
    {
        Left = left;
        Right = right;
    }

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

    public IList<string> Reduce(string inputMolecule)
    {
        var molecules = new List<string>();
        var staticParts = inputMolecule.Split(Right);
        if (staticParts.Length < 2)
            return new List<string>();

        var numberOfReplacements = staticParts.Length - 1;
        for (var i = 0; i < numberOfReplacements; i++)
        {
            var sb = new StringBuilder();
            for (var j = 0; j < numberOfReplacements; j++)
            {
                sb.Append(staticParts[j]);
                var replacement = i == j ? Left : Right;
                sb.Append(replacement);
            }

            sb.Append(staticParts.Last());

            molecules.Add(sb.ToString());
        }

        return molecules.Distinct().ToList();
    }
}