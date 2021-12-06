using System.Collections.Generic;
using System.Linq;
using Core.Combinatorics;
using Core.Strings;

namespace ConsoleApp.Puzzles.Year2016.Day11
{
    public class RadioisotopeSimulator
    {
        private readonly IDictionary<string, RadioisotopeFacility> _previousFacilities = new Dictionary<string, RadioisotopeFacility>();

        public int StepCount { get; }

        public RadioisotopeSimulator(string input)
        {
            var facility = ParseFacility(input);
            TrackVisit(facility);
            var finishedFacility = FindFinishedFacility(new List<RadioisotopeFacility> { facility });
            StepCount = finishedFacility?.IterationCount ?? 0;
        }

        private RadioisotopeFacility FindFinishedFacility(IList<RadioisotopeFacility> facilities)
        {
            var newFacilities = new List<RadioisotopeFacility>();
            foreach (var facility in facilities)
            {
                var distinctCombinations = new Dictionary<string, IList<RadioisotopeItem>>();
                var itemCombinations = PermutationGenerator.GetPermutations(facility.Floors[facility.ElevatorFloor].Items, 2).ToList();
                foreach (var c in itemCombinations)
                {
                    var sorted = c.OrderBy(o => o.Id).ToList();
                    var id = string.Join('-', sorted.Select(o => o.Id));
                    if(!distinctCombinations.ContainsKey(id))
                        distinctCombinations.Add(id, sorted.ToList());
                }

                var combinationsToUse = RemoveRedundantPairs(distinctCombinations.Values).ToList();

                if (facility.ShouldMoveUp)
                {
                    var oldFloor = facility.ElevatorFloor;
                    var newFloor = oldFloor + 1;
                    var movedTwo = false;
                    foreach (var combination in combinationsToUse)
                    {
                        var f = new RadioisotopeFacility(facility, newFloor);
                        foreach (var item in combination)
                        {
                            f.Floors[oldFloor].Items.Remove(item);
                            f.Floors[newFloor].Items.Add(item);
                        }

                        if (!AlreadyVisited(f) && f.IsValid)
                        {
                            newFacilities.Add(f);
                            TrackVisit(f);
                            movedTwo = true;
                        }
                    }

                    if (!movedTwo)
                    {
                        foreach (var item in facility.Floors[facility.ElevatorFloor].Items)
                        {

                            var f = new RadioisotopeFacility(facility, newFloor);
                            f.Floors[oldFloor].Items.Remove(item);
                            f.Floors[newFloor].Items.Add(item);

                            if (!AlreadyVisited(f) && f.IsValid)
                            {
                                newFacilities.Add(f);
                                TrackVisit(f);
                            }
                        }
                    }
                }

                if (facility.ShouldMoveDown)
                {
                    var oldFloor = facility.ElevatorFloor;
                    var newFloor = oldFloor - 1;
                    //var movedTwo = false;
                    //foreach (var combination in combinationsToUse)
                    //{
                    //    var f = new RadioisotopeFacility(facility, newFloor);
                    //    foreach (var item in combination)
                    //    {
                    //        f.Floors[oldFloor].Items.Remove(item);
                    //        f.Floors[newFloor].Items.Add(item);
                    //    }

                    //    if (!AlreadyVisited(f) && f.IsValid)
                    //    {
                    //        newFacilities.Add(f);
                    //        TrackVisit(f);
                    //        movedTwo = true;
                    //    }
                    //}

                    //if (!movedTwo)
                    //{
                        foreach (var item in facility.Floors[facility.ElevatorFloor].Items)
                        {
                            var f = new RadioisotopeFacility(facility, newFloor);
                            f.Floors[oldFloor].Items.Remove(item);
                            f.Floors[newFloor].Items.Add(item);

                            if (!AlreadyVisited(f) && f.IsValid)
                            {
                                newFacilities.Add(f);
                                TrackVisit(f);
                            }
                        }
                    //}
                }
            }

            if (!newFacilities.Any())
                return null;
            var finishedFacility = newFacilities.FirstOrDefault(o => o.IsDone);
            if (finishedFacility != null)
                return finishedFacility;
            var iterationCount = newFacilities.First().IterationCount;
            var facilityCount = newFacilities.Count;  
            return FindFinishedFacility(newFacilities);
        }

        private IEnumerable<IEnumerable<RadioisotopeItem>> RemoveRedundantPairs(IEnumerable<IList<RadioisotopeItem>> combinations)
        {
            var pairCount = 0;
            foreach (var combination in combinations)
            {
                var first = combination.First();
                var last = combination.Last();
                if (first.Type != last.Type && first.Name == last.Name)
                {
                    if (pairCount == 0)
                    {
                        pairCount++;
                        yield return combination;
                    }
                }
                else
                {
                    yield return combination;
                }
            }
        }

        private bool AlreadyVisited(RadioisotopeFacility f)
        {
            return _previousFacilities.ContainsKey(f.AnonymizedId);
        }

        private void TrackVisit(RadioisotopeFacility f)
        {
            _previousFacilities.Add(f.AnonymizedId, f);
        }

        private RadioisotopeFacility ParseFacility(string input)
        {
            var strFloors = PuzzleInputReader.ReadLines(input);
            return new RadioisotopeFacility(strFloors.Select(ParseFloor).ToList(), 0);
        }

        private RadioisotopeFloor ParseFloor(string s)
        {
            s = s.Replace(" microchip", "-microchip").Replace(" generator", "-generator").Replace(",", "").Replace(".", "");
            var parts = s.Split(" ");
            var items = parts
                .Where(o => o.EndsWith("microchip") || o.EndsWith("generator"))
                .Select(CreateItem)
                .ToList();
            return new RadioisotopeFloor(items);
        }

        private RadioisotopeItem CreateItem(string s)
        {
            var parts = s.Split('-');
            var name = parts.First();
            var type = parts.Last();
            if (type == "microchip")
                return new Microchip(name);
            return new Generator(name);
        }
    }
}