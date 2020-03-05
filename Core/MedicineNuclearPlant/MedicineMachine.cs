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
            var molecules = new List<string> { targetMolecule };
            var steps = 0;
            while (molecules.All(o => o != "e"))
            {
                var newMolecules = new List<string>();
                foreach (var molecule in molecules)
                {
                    foreach (var replacement in _replacements)
                    {
                        newMolecules.AddRange(replacement.Reduce(molecule));
                    }
                }

                steps++;
                molecules = newMolecules;
            }

            return steps;
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