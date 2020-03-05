using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.MedicineNuclearPlant
{
    public class MedicineMachine
    {
        private readonly IEnumerable<MoleculeReplacement> _replacements;
        private readonly IDictionary<string, int> _depthCache = new Dictionary<string, int>();
        private readonly IDictionary<string, Molecule> _molecules = new Dictionary<string, Molecule>();
        private readonly IDictionary<string, IList<string>> _reduceCache = new Dictionary<string, IList<string>>();

        public MedicineMachine(string input)
        {
            _replacements = PuzzleInputReader.Read(input).Select(ParseReplacement);
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

        public int StepsToMake(string targetMolecule)
        {
            var steps = ApplyReplacements(1, targetMolecule);
            return steps ?? 0;
        }

        private int? ApplyReplacements(int depth, string molecule)
        {
            if (_depthCache.TryGetValue(molecule, out var result))
                return result;

            var depths = new List<int?>();
            foreach (var replacement in _replacements)
            {
                IList<string> newMolecules;
                var cacheKey = $"{molecule}|{replacement.Right}";
                if (_reduceCache.TryGetValue(cacheKey, out var reduceResult))
                {
                    newMolecules = reduceResult;
                }
                else
                {
                    newMolecules = replacement.Reduce(molecule);
                    if (!newMolecules.Any())
                    {
                        _reduceCache.Add(cacheKey, newMolecules);
                    }
                }
                
                if (newMolecules.Any(o => o == "e"))
                    return depth;

                depths.AddRange(newMolecules.Where(o => o != molecule).Select(o => ApplyReplacements(depth + 1, o)));
            }

            var minDepth = depths.Any() ? depths.Min() : null;
            if (minDepth != null)
                _depthCache.TryAdd(molecule, minDepth.Value);
            return minDepth;
        }

        private MoleculeReplacement ParseReplacement(string s)
        {
            var parts = s.Split(" => ");
            var input = parts[0];
            var output = parts[1];
            return new MoleculeReplacement(input, output);
        }
    }

    public class Molecule
    {
        public string Name { get; }
        public IList<string> Reduced { get; }

        public Molecule(string name, IList<string> reduced)
        {
            Name = name;
            Reduced = reduced;
        }
    }
}