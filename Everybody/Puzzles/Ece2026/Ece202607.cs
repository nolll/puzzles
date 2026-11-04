using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Explouding")]
public class Ece202607 : EverybodyEventPuzzle
{
    [Puzzle("6d829c7e452abe9cf2163e18e220cdec")]
    public int Part1(string input) => SolvePart1And2(input, 5);

    [Puzzle("d9947c8758d5e170d1b42e81efbdcd8e")]
    public int Part2(string input) => SolvePart1And2(input, 10);

    [Puzzle("115f410b8f35901ce315f1a7e45442ae")]
    public int Part3(string input, int limit = 1_000_000) => input.Split(LineBreaks.Single)
        .Select(o => RunFromCloud(ParseClouds(input), Numbers.IntsFromString(o)[0], 10, limit))
        .Max();

    private static int SolvePart1And2(string input, int startEnergy)
    {
        var clouds = ParseClouds(input);
        var startCloud = clouds.Values.MaxBy(o => o.Connections.Count)!.Id;
        RunFromCloud(clouds, startCloud, startEnergy);
        return clouds.Values.Sum(o => o.Energy);
    }

    private static Dictionary<int, Cloud> ParseClouds(string input) => input.Split(LineBreaks.Single)
        .Select(Numbers.IntsFromString)
        .Select(numbers => new Cloud(numbers[0], numbers[1], [.. numbers.Skip(2)]))
        .ToDictionary(cloud => cloud.Id);

    private static int RunFromCloud(Dictionary<int, Cloud> clouds, int startCloud, int startEnergy, int? limit = null)
    {
        var impulses = new Dictionary<Impulse, int> { { new(startCloud, startEnergy), 1 } };

        while (impulses.Count > 0)
        {
            var newImpulses = new Dictionary<Impulse, int>();
            var exploded = new HashSet<int>();
            foreach (var (impulse, count) in impulses)
            {
                if (!clouds.TryGetValue(impulse.Id, out var cloud))
                    continue;
                
                cloud.Energy += impulse.Energy * count;
                if (limit == null || cloud.Energy < limit)
                    continue;
                
                foreach (var connectionId in cloud.Connections)
                {
                    newImpulses.TryAdd(new(connectionId, 10), 0);
                    newImpulses[new(connectionId, 10)] += 1;
                }

                exploded.Add(cloud.Id);
            }
            
            foreach (var (impulse, count) in impulses)
            {
                if (!clouds.TryGetValue(impulse.Id, out var cloud))
                    continue;
                
                var newEnergy = impulse.Energy - 1;

                if (newEnergy <= 0)
                    continue;
                
                foreach (var connectionId in cloud.Connections)
                {
                    newImpulses.TryAdd(new(connectionId, newEnergy), 0);
                    newImpulses[new(connectionId, newEnergy)] += count;
                }
            }

            foreach (var toRemove in exploded) 
                clouds.Remove(toRemove);
            
            impulses = newImpulses;
        }
        
        return clouds.Values.Sum(o => o.Energy);
    }

    private class Cloud(int id, int energy, List<int> connections)
    {
        public int Id { get; } = id;
        public int Energy { get; set; } = energy;
        public List<int> Connections { get; } = connections;
    }

    private record Impulse(int Id, int Energy);
}