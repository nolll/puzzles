namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201611;

public class RadioisotopeFloor
{
    public IList<RadioisotopeItem> Items { get; }
    public string Id => string.Join(null, Items.Select(o => o.Id).OrderBy(o => o));

    public RadioisotopeFloor(IList<RadioisotopeItem> items)
    {
        Items = items;
    }

    public bool IsValid
    {
        get
        {
            var microchips = Items.Where(o => o.Type == RadioisotopeType.Microchip).ToList();
            var generators = Items.Where(o => o.Type == RadioisotopeType.Generator).ToList();
            return !generators.Any() || microchips.All(microchip => generators.Any(o => o.Name == microchip.Name));
        }
    }
}