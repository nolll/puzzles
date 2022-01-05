using System.Collections.Generic;
using System.Linq;

namespace Core.Puzzles.Year2016.Day11;

public class RadioisotopeFloor
{
    public IList<RadioisotopeItem> Items { get; }
    public string Id => string.Join('-', Items.Select(o => o.Id).OrderBy(o => o));

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
            if (!generators.Any())
                return true;
            foreach (var microchip in microchips)
            {
                var matchingGenerator = generators.FirstOrDefault(o => o.Name == microchip.Name);
                if (matchingGenerator == null)
                    return false;
            }

            return true;
        }
    }
}