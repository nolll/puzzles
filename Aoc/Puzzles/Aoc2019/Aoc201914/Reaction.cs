namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201914;

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