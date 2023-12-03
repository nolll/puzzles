namespace Puzzles.Aoc.Puzzles.Aoc2020.Aoc202021;

public class Food
{
    public List<string> Ingredients { get; }
    public List<string> Allergens { get; }

    private Food(List<string> ingredients, List<string> allergens)
    {
        Ingredients = ingredients;
        Allergens = allergens;
    }

    public static Food Parse(string s)
    {
        var parts = s.Split('(');
        var ingredients = parts[0].Trim().Split(' ').Select(o => o.Trim()).ToList();
        var allergens = parts[1].Replace("contains", "").Trim(')').Split(',').Select(o => o.Trim()).ToList();

        return new Food(ingredients, allergens);
    }
}