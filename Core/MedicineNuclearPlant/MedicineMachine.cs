using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.MedicineNuclearPlant
{
    public class MedicineMachine
    {
        private readonly IEnumerable<MoleculeReplacement> _replacements;

        public MedicineMachine(string input)
        {
            _replacements = PuzzleInputReader.Read(input).Select(ParseReplacement);
        }

        public IList<string> GetMolecules(string startMolecule)
        {
            var molecules = new List<string>();
            foreach (var replacement in _replacements)
            {
                molecules.AddRange(replacement.FindMolecules(startMolecule));
            }
            return molecules.Distinct().ToList();
        }

        private MoleculeReplacement ParseReplacement(string s)
        {
            var parts = s.Split(" => ");
            var input = parts[0];
            var output = parts[1];
            return new MoleculeReplacement(input, output);
        }
    }
}