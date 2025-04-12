using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202514;

[Name("Crucial Crafting")]
public class Codyssi202514 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var data = input.Split(LineBreaks.Single).Select(Numbers.IntsFromString);
        var data2 = data.Select(o => (quality: o[1], cost: o[2], count: o[3]));
        data2 = data2.OrderByDescending(o => o.quality).ThenByDescending(o => o.cost);
        var top5Sum = data2.Take(5).Select(o => o.count).Sum();
        
        return new PuzzleResult(top5Sum, "43dd1272123cf25f4341c003d0fc6018");
    }

    public PuzzleResult Part2(string input)
    {
        var result = RunPart2And3(input, 30);
        return new PuzzleResult(result, "034d794512e58624f111ea6c90e4abcc");
    }
    
    public PuzzleResult Part3(string input, int unitCount = 300)
    {
        var result = RunPart2And3(input, unitCount);
        return new PuzzleResult(result, "3bafbd664e33fa504df74844376f1c19");
    }

    public int RunPart2And3(string input, int unitCount)
    {
        var items = input.Split(LineBreaks.Single)
            .Select(o => o.Replace(",", "").Split(' '))
            .Select(o => new Item(int.Parse(o[5]), int.Parse(o[8]), int.Parse(o[12]))).ToList();
        
        var grid = KnapsackSolve(items.ToArray(), unitCount);
        var optimalItems = grid[items.Count - 1, unitCount];
        var optimalValue = grid[items.Count - 1, unitCount].Value;
        var result = optimalValue * optimalItems.Items.Sum(o => o.Count);
        
        return result;
    }

    // Needed a little help for part 3. Found it here:
    // https://stackoverflow.com/questions/50393489/knapsack-c-sharp-implementation-task
    private static GridCell[,] KnapsackSolve(Item[] items, int maxCapacity)
    {
        var grid = new GridCell[items.Length, maxCapacity + 1];

        for (var row = 0; row < items.Length; row++)
        {
            for (var capacity = 0; capacity <= maxCapacity; capacity++)
            {
                if (row == 0)
                {
                    if (items[row].Cost <= capacity)
                        grid[row, capacity] = new GridCell(items[row].Quality, [items[row]]);
                    else
                        grid[row, capacity] = new GridCell(0, []);
                    continue;
                }
                
                if (items[row].Cost <= capacity)
                {
                    var item = items[row];
                    var valueInRemainingSpace = grid[row - 1, capacity - item.Cost].Value;
                    var valueIfTaken = item.Quality + valueInRemainingSpace;
                    var valueIfNotTaken = grid[row - 1, capacity].Value;
                    if (valueIfTaken > valueIfNotTaken)
                    {
                        var itemsInRemainingSpace = grid[row - 1, capacity - item.Cost].Items;
                        grid[row, capacity] = new GridCell(valueIfTaken, [..itemsInRemainingSpace, item]);
                        continue;
                    }
                }
                
                grid[row, capacity] = grid[row - 1, capacity];
            }
        }

        return grid;
    }
    
    private record GridCell(int Value, List<Item> Items);

    private class Item(int quality, int cost, int count)
    {
        public int Quality { get; } = quality;
        public int Cost { get; } = cost;
        public int Count { get; } = count;
    }
}