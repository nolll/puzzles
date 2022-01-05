using System.Collections.Generic;

namespace App.Puzzles.Year2019.Day14;

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