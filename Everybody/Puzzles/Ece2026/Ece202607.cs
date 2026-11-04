using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Explouding")]
[IsSlow]
[Comment("Part 3 takes a little over 200s")]
public class Ece202607 : EverybodyEventPuzzle
{
    [Puzzle("6d829c7e452abe9cf2163e18e220cdec")]
    public long Part1(string input) => SolvePart1And2(input, 5);

    [Puzzle("d9947c8758d5e170d1b42e81efbdcd8e")]
    public long Part2(string input) => SolvePart1And2(input, 10);

    [Puzzle("115f410b8f35901ce315f1a7e45442ae")]
    public long Part3(string input, int limit = 1_000_000)
    {
        var lines = input.Split(LineBreaks.Single);

        var bestResult = 0L;
        foreach (var cloudLine in lines)
        {
            var startCloud = Numbers.IntsFromString(cloudLine)[0];
            var result = RunFromCloud(lines, startCloud, limit);
            if (result > bestResult)
            {
                bestResult = result;
            }
        }
        
        return bestResult;
    }

    private long SolvePart1And2(string input, int startEnergy)
    {
        var clouds = ParseClouds(input);
        var startCloud = clouds.Values.MaxBy(o => o.Connections.Count)!.Id;
        SendImpulsePart1And2(clouds, startCloud, startEnergy);
        return clouds.Values.Sum(o => o.Energy);
    }

    private Dictionary<int, Cloud> ParseClouds(string input) => input.Split(LineBreaks.Single)
        .Select(Numbers.IntsFromString)
        .Select(numbers => new Cloud(numbers[0], numbers[1], [.. numbers.Skip(2)]))
        .ToDictionary(cloud => cloud.Id);

    private long RunFromCloud(string[] lines, int startCloud, int limit)
    {
        var clouds = new Dictionary<int, Cloud>();
        foreach (var line in lines)
        {
            var numbers = Numbers.IntsFromString(line);
            var cloud = new Cloud(numbers[0], numbers[1], [.. numbers.Skip(2)]);
            clouds.Add(cloud.Id, cloud);
        }

        const int startEnergy = 10;
        var impulses = new Dictionary<int, List<int>>();
        impulses.Add(startCloud, [startEnergy]);

        while (impulses.Count > 0)
        {
            var newImpulses = new Dictionary<int, List<int>>();
            var exploded = new HashSet<int>();
            foreach (var (id, energies) in impulses.OrderBy(o => o.Key))
            {
                if (!clouds.TryGetValue(id, out var cloud))
                    continue;
                
                cloud.Energy += energies.Sum();
                if (cloud.Energy < limit)
                    continue;
                
                foreach (var connectionId in cloud.Connections)
                {
                    newImpulses.TryAdd(connectionId, []);
                    newImpulses[connectionId].Add(10);
                }

                exploded.Add(cloud.Id);
            }
            
            foreach (var (id, energies) in impulses)
            {
                if (!clouds.TryGetValue(id, out var cloud))
                    continue;

                foreach (var energy in energies)
                {
                    var newEnergy = energy - 1;

                    if (newEnergy <= 0)
                        continue;
                    
                    foreach (var connectionId in cloud.Connections)
                    {
                        newImpulses.TryAdd(connectionId, []);
                        newImpulses[connectionId].Add(newEnergy);;
                    }
                }
            }

            foreach (var toRemove in exploded) 
                clouds.Remove(toRemove);
            
            impulses = newImpulses;
        }
        
        return clouds.Values.Sum(o => o.Energy);
    }
    
    private void SendImpulsePart1And2(Dictionary<int, Cloud> clouds, int id, int energy)
    {
        var cloud = clouds[id];
        cloud.Energy += energy;
        energy -= 1;
        if (energy <= 0)
            return;
        
        foreach (var connectionId in cloud.Connections) 
            SendImpulsePart1And2(clouds, connectionId, energy);
    }

    private class Cloud(int id, int energy, List<int> connections)
    {
        public int Id { get; } = id;
        public long Energy { get; set; } = energy;
        public List<int> Connections { get; } = connections;
    }
}