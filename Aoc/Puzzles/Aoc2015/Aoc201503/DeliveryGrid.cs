using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201503;

public class DeliveryGrid
{
    private readonly Grid<int> _grid = new();
    public int SantaDeliveryCount => _grid.Values.Count(o => o > 0);

    public void DeliverBySanta(string input) => DeliverAccordingToDirections(input.ToCharArray());

    public void DeliverBySantaAndRobot(string input)
    {
        var (santaDirections, robotDirections) = SplitDirections(input.ToCharArray());
        DeliverAccordingToDirections(santaDirections);
        _grid.MoveTo(_grid.StartAddress);
        DeliverAccordingToDirections(robotDirections);
    }

    private static (IEnumerable<char> santa, IEnumerable<char> robot) SplitDirections(char[] allDirections)
    {
        var santaDirections = new List<char>();
        var robotDirections = new List<char>();
        for (var i = 0; i < allDirections.Length; i += 2)
        {
            santaDirections.Add(allDirections[i]);
            robotDirections.Add(allDirections[i + 1]);
        }

        return (santaDirections, robotDirections);
    }

    private void DeliverAccordingToDirections(IEnumerable<char> directions)
    {
        DeliverPresent();
        foreach (var direction in directions)
        {
            Move(direction);
            DeliverPresent();
        }
    }

    private void DeliverPresent() => _grid.WriteValue(_grid.ReadValue() + 1);
    private void Move(char direction) => _grid.Move(GridDirection.Get(direction));
}