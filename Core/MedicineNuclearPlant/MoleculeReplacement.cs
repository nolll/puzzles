using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.MedicineNuclearPlant
{
    internal class MoleculeReplacement
    {
        public string Input { get; }
        public string Output { get; }

        public MoleculeReplacement(string input, string output)
        {
            Input = input;
            Output = output;
        }

        public IList<string> FindMolecules(string inputMolecule)
        {
            var molecules = new List<string>();
            var staticParts = inputMolecule.Split(Input);
            if (staticParts.Length < 2)
                return new List<string>();

            var numberOfReplacements = staticParts.Length - 1;
            for (var i = 0; i < numberOfReplacements; i++)
            {
                var sb = new StringBuilder();
                for (var j = 0; j < numberOfReplacements; j++)
                {
                    sb.Append(staticParts[j]);
                    var replacement = i == j ? Output : Input;
                    sb.Append(replacement);
                }

                sb.Append(staticParts.Last());

                molecules.Add(sb.ToString());
            }

            return molecules;
        }
    }
}