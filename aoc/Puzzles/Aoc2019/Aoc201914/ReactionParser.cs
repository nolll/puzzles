namespace Puzzles.aoc.Puzzles.Aoc2019.Aoc201914;

public class ReactionParser
{
    public IList<Reaction> Parse(string input)
    {
        var rows = input.Trim().Split('\n').Select(o => o.Trim());
        var reactions = new List<Reaction>();
        foreach (var row in rows)
        {
            var parts = row.Trim().Split("=>").Select(o => o.Trim()).ToList();
            var inputPart = parts[0].Trim();
            var outputPart = parts[1].Trim();
            var inputQuantities = inputPart.Split(',').Select(ParseQuantity).ToList();
            var outputQuantity = ParseQuantity(outputPart);
            reactions.Add(new Reaction(outputQuantity, inputQuantities));
        }
        return reactions;
    }

    private ChemicalQuantity ParseQuantity(string input)
    {
        var parts = input.Trim().Split(' ').ToList();
        var quantity = int.Parse(parts[0].Trim());
        var name = parts[1].Trim();
        return new ChemicalQuantity(name, quantity);
    }
}