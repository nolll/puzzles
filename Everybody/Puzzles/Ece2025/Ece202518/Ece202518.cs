using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202518;

[Name("When Roots Remember")]
public class Ece202518 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
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
                    plant.Branches.Add(new Branch(branchNums[0], null));
                }
                else
                {
                    var plantIndex = branchNums[0] - 1;
                    var branchPlant = plants[plantIndex];
                    plant.Branches.Add(new Branch(branchNums[1], branchPlant));   
                }
            }
        }
        
        return new PuzzleResult(plants.Last().Energy, "3c9317ed77a5948ad8c6ca11172055bd");
    }

    public PuzzleResult Part2(string input)
    {
        var (plantstr, teststr) = input.Split(LineBreaks.Triple);
        var sections = plantstr.Split(LineBreaks.Double);
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
                    plant.Branches.Add(new Branch(branchNums[0], null));
                }
                else
                {
                    var plantIndex = branchNums[0] - 1;
                    var branchPlant = plants[plantIndex];
                    plant.Branches.Add(new Branch(branchNums[1], branchPlant));   
                }
            }
        }

        var testLines = teststr.Split(LineBreaks.Single);
        var sum = 0L;
        foreach (var testLine in testLines)
        {
            var bools = testLine.Split(' ').Select(o => int.Parse(o) == 1).ToArray();
            for (var i = 0; i < bools.Length; i++)
            {
                plants[i].IsActive = bools[i];
            }

            sum += plants.Last().Energy;
        }
        
        return new PuzzleResult(sum, "810932c961238e78746d0d6f239e398d");
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }

    private class Plant(int id, int thickness)
    {
        public int Id { get; } = id;
        public List<Branch> Branches { get; } = [];
        public bool IsActive { get; set; } = true;
        
        public int Energy
        {
            get
            {
                if (!IsActive)
                    return 0;
                
                var energy = Branches.Sum(o => o.Energy);
                return energy < thickness ? 0 : energy;
            }
        }
    }

    private class Branch(int thickness, Plant? plant)
    {
        public int Energy
        {
            get
            {
                if (plant is null)
                    return thickness;

                var plantEnergy = plant?.Energy ?? 1;
                return thickness * plantEnergy;
            }
        }
    }
}