using System.Collections.Generic;

namespace ConsoleApp.Puzzles.Year2019.Puzzles.Day14
{
    public class Reaction
    {
        public ChemicalQuantity Output { get; }
        public IList<ChemicalQuantity> Inputs { get; }

        public Reaction(ChemicalQuantity output, IList<ChemicalQuantity> inputs)
        {
            Output = output;
            Inputs = inputs;
        }
    }
}