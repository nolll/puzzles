using System.Collections.Generic;
using System.Linq;
using Aoc.Common.Combinatorics;
using Aoc.Common.Strings;

namespace Aoc.Puzzles.Year2016.Day11;

public class RadioisotopeSimulator
{
    private readonly HashSet<string> _previousFacilities = new();

    public int StepCount { get; }

    public RadioisotopeSimulator(string input)
    {
        var facility = ParseFacility(input);
        TrackVisit(facility);
        var finishedFacility = FindFinishedFacility(new List<RadioisotopeFacility> { facility });
        StepCount = finishedFacility?.IterationCount ?? 0;
    }

    private RadioisotopeFacility FindFinishedFacility(IEnumerable<RadioisotopeFacility> facilities)
    {
        var newFacilities = new List<RadioisotopeFacility>();
        foreach (var facility in facilities)
        {
            if (facility.ShouldMoveUp)
            {
                var itemCombinations = CombinationGenerator.GetAllCombinationsMaxSize(facility.Floors[facility.ElevatorFloor].Items, 2);
                var oldFloor = facility.ElevatorFloor;
                var newFloor = oldFloor + 1;
                foreach (var combination in itemCombinations)
                {
                    var f = new RadioisotopeFacility(facility, newFloor);
                    foreach (var item in combination)
                    {
                        f.Floors[oldFloor].Items.Remove(item);
                        f.Floors[newFloor].Items.Add(item);
                    }

                    if (!AlreadyVisited(f))
                    {
                        TrackVisit(f);
                        if (f.IsValid) 
                            newFacilities.Add(f);
                    }
                }
            }

            if (facility.ShouldMoveDown)
            {
                var oldFloor = facility.ElevatorFloor;
                var newFloor = oldFloor - 1;

                foreach (var item in facility.Floors[facility.ElevatorFloor].Items)
                {
                    var f = new RadioisotopeFacility(facility, newFloor);
                    f.Floors[oldFloor].Items.Remove(item);
                    f.Floors[newFloor].Items.Add(item);

                    if (!AlreadyVisited(f))
                    {
                        TrackVisit(f);
                        if (f.IsValid)
                        {
                            newFacilities.Add(f);
                        }
                    }
                }
            }
        }

        if (!newFacilities.Any())
            return null;

        var finishedFacility = newFacilities.FirstOrDefault(o => o.IsDone);
        return finishedFacility ?? FindFinishedFacility(newFacilities);
    }

    private bool AlreadyVisited(RadioisotopeFacility f)
    {
        return _previousFacilities.Contains(f.AnonymizedAnonymizedId);
    }

    private void TrackVisit(RadioisotopeFacility f)
    {
        _previousFacilities.Add(f.AnonymizedAnonymizedId);
    }

    private RadioisotopeFacility ParseFacility(string input)
    {
        var strFloors = PuzzleInputReader.ReadLines(input);
        return new RadioisotopeFacility(strFloors.Select(ParseFloor).ToList(), 0);
    }

    private static RadioisotopeFloor ParseFloor(string s)
    {
        s = s.Replace(" microchip", "-microchip").Replace(" generator", "-generator").Replace(",", "").Replace(".", "");
        var parts = s.Split(" ");
        var items = parts
            .Where(o => o.EndsWith("microchip") || o.EndsWith("generator"))
            .Select(CreateItem)
            .ToList();
        return new RadioisotopeFloor(items);
    }

    private static RadioisotopeItem CreateItem(string s)
    {
        var parts = s.Split('-');
        var name = parts.First();
        var type = parts.Last();
        if (type == "microchip")
            return new Microchip(name);
        return new Generator(name);
    }
}