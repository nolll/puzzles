using Pzl.Tools.Combinatorics;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201611;

public class RadioisotopeSimulator
{
    private readonly HashSet<string> _previousFacilities = [];
    private readonly IsotopeNameProvider _isotopeNameProvider = new();
    private readonly AnonymousNameProvider _anonymousNameProvider = new();

    public int StepCount { get; }

    public RadioisotopeSimulator(string input)
    {
        var facility = ParseFacility(input);
        TrackVisit(facility);
        var finishedFacility = FindFinishedFacility(new List<RadioisotopeFacility> { facility });
        StepCount = finishedFacility?.IterationCount ?? 0;
    }

    private RadioisotopeFacility? FindFinishedFacility(IEnumerable<RadioisotopeFacility> facilities)
    {
        var newFacilities = new List<RadioisotopeFacility>();
        foreach (var facility in facilities)
        {
            if (facility.ShouldMoveUp)
            {
                var itemCombinations = CombinationGenerator.GetUniqueCombinationsMaxSize(facility.Floors[facility.ElevatorFloor].Items, 2);
                var oldFloor = facility.ElevatorFloor;
                var newFloor = oldFloor + 1;
                foreach (var combination in itemCombinations)
                {
                    var f = new RadioisotopeFacility(facility, newFloor, _isotopeNameProvider, _anonymousNameProvider);
                    foreach (var item in combination)
                    {
                        f.Floors[oldFloor].Items.Remove(item);
                        f.Floors[newFloor].Items.Add(item);
                    }

                    if (AlreadyVisited(f))
                        continue;
                    
                    TrackVisit(f);
                    if (f.IsValid) 
                        newFacilities.Add(f);
                }
            }

            if (facility.ShouldMoveDown)
            {
                var oldFloor = facility.ElevatorFloor;
                var newFloor = oldFloor - 1;

                foreach (var item in facility.Floors[facility.ElevatorFloor].Items)
                {
                    var f = new RadioisotopeFacility(facility, newFloor, _isotopeNameProvider, _anonymousNameProvider);
                    f.Floors[oldFloor].Items.Remove(item);
                    f.Floors[newFloor].Items.Add(item);

                    if (AlreadyVisited(f))
                        continue;
                    
                    TrackVisit(f);
                    if (f.IsValid) 
                        newFacilities.Add(f);
                }
            }
        }

        if (!newFacilities.Any())
            return null;

        var finishedFacility = newFacilities.FirstOrDefault(o => o.IsDone);
        return finishedFacility ?? FindFinishedFacility(newFacilities);
    }

    private bool AlreadyVisited(RadioisotopeFacility f) => _previousFacilities.Contains(f.AnonymizedId);
    private void TrackVisit(RadioisotopeFacility f) => _previousFacilities.Add(f.AnonymizedId);

    private RadioisotopeFacility ParseFacility(string input) => new(
        StringReader.ReadLines(input).Select(ParseFloor).ToList(), 0, _isotopeNameProvider, _anonymousNameProvider);

    private static RadioisotopeFloor ParseFloor(string s)
    {
        var parts = s.Replace(" microchip", "-microchip").Replace(" generator", "-generator").Replace(",", "").Replace(".", "").Split(" ");
        var items = parts
            .Where(o => o.EndsWith("microchip") || o.EndsWith("generator"))
            .Select(CreateItem)
            .ToList();
        return new RadioisotopeFloor(items);
    }

    private static RadioisotopeItem CreateItem(string s, int index)
    {
        var parts = s.Split('-');
        var name = parts.First();
        var type = parts.Last();
        if (type == "microchip")
            return new Microchip(name);
        return new Generator(name);
    }
}