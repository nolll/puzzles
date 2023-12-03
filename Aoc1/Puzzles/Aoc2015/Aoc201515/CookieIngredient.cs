namespace Puzzles.Aoc.Puzzles.Aoc2015.Aoc201515;

public class CookieIngredient
{
    public string Name { get; }
    public int Capacity { get; }
    public int Durability { get; }
    public int Flavor { get; }
    public int Texture { get; }
    public int Calories { get; }

    public CookieIngredient(string name, int capacity, int durability, int flavor, int texture, int calories)
    {
        Name = name;
        Capacity = capacity;
        Durability = durability;
        Flavor = flavor;
        Texture = texture;
        Calories = calories;
    }
}