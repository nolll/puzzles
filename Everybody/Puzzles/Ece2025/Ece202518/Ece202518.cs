using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202518;

[Name("When Roots Remember")]
// Thanks to HyperNeutrino for noticing the pattern in the input data.
// Branches with negative always have negativ thickness, and should be inactivated
// That is not true in the test input
public class Ece202518 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input) => new(ParsePlants(input).Last().Energy, "3c9317ed77a5948ad8c6ca11172055bd");

    public PuzzleResult Part2(string input)
    {
        var (plantstr, teststr) = input.Split(LineBreaks.Triple);
        var plants = ParsePlants(plantstr);
        var sum = teststr.Split(LineBreaks.Single).Select(ParseTestCase).Sum(o => ActivateAndGetEnergy(plants, o.ToArray()));

        return new PuzzleResult(sum, "810932c961238e78746d0d6f239e398d");
    }

    public PuzzleResult Part3(string input)
    {
        var (plantstr, teststr) = input.Split(LineBreaks.Triple);
        var plants = ParsePlants(plantstr);
        var optimal = GetOptimalEnergy(plants);
        var sum = teststr.Split(LineBreaks.Single)
            .Select(ParseTestCase)
            .Select(o => ActivateAndGetEnergy(plants, o))
            .Where(energy => energy > 0)
            .Sum(energy => optimal - energy);

        return new PuzzleResult(sum, "e784c3249103e09adf84a2ac82143826");
    }

    private static long GetOptimalEnergy(Plant[] plants)
    {
        var optimalActivation = plants.Where(o => o.IsFree)
            .Select(fbPlant => plants.Select(plant => plant.Branches.FirstOrDefault(o => o.Plant != null && o.Plant.Id == fbPlant.Id))
                .OfType<Branch>()
                .ToList()
                .All(o => o is { Energy: > 0 }))
            .ToArray();

        return ActivateAndGetEnergy(plants, optimalActivation);
    }
    
    private static long ActivateAndGetEnergy(Plant[] plants, bool[] activations)
    {
        for (var i = 0; i < activations.Length; i++) 
            plants[i].IsActive = activations[i];

        return plants.Last().Energy;
    }

    private static bool[] ParseTestCase(string input) => input.Split(' ').Select(o => int.Parse(o) == 1).ToArray();

    private static Plant[] ParsePlants(string input)
    {
        var sections = input.Split(LineBreaks.Double);
        List<Plant> plants = [];
        foreach (var section in sections)
        {
            var lines = section.Split(LineBreaks.Single);
            var plantNums = Numbers.IntsFromString(lines.First());
            var id = plantNums[0];
            var plantThickness = plantNums[1];
            var plant = new Plant(id, plantThickness);
            plants.Add(plant);
            foreach (var line in lines.Skip(1))
            {
                var branchNums = Numbers.IntsFromString(line);
                if (branchNums.Length == 1)
                {
                    plant.IsFree = true;
                    break;
                }

                var plantIndex = branchNums[0] - 1;
                var branchPlant = plants[plantIndex];
                plant.Branches.Add(new Branch(branchNums[1], branchPlant));
            }
        }

        return plants.ToArray();
    }

    private class Plant(int id, int thickness)
    {
        public int Id { get; } = id;
        public List<Branch> Branches { get; } = [];
        public bool IsActive { get; set; } = true;
        public bool IsFree { get; set; }
        
        public int Energy
        {
            get
            {
                if (IsFree)
                    return IsActive ? 1 : 0;
                
                var energy = Branches.Sum(o => o.Energy);
                return energy < thickness ? 0 : energy;
            }
        }
    }

    private class Branch(int thickness, Plant? plant)
    {
        public Plant? Plant { get; } = plant;
        
        public int Energy
        {
            get
            {
                if (Plant is null)
                    return thickness;

                var plantEnergy = Plant?.Energy ?? 1;
                return thickness * plantEnergy;
            }
        }
    }
}