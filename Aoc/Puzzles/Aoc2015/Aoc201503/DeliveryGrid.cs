using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201503;

public class DeliveryGrid
{
    private readonly Matrix<int> _matrix;
    public int SantaDeliveryCount => _matrix.Values.Count(o => o > 0);

    public DeliveryGrid()
    {
        _matrix = new Matrix<int>();
    }

    public void DeliverBySanta(string input)
    {
        var directions = input.ToCharArray();
        DeliverAccordingToDirections(directions);
    }

    public void DeliverBySantaAndRobot(string input)
    {
        var allDirections = input.ToCharArray();
        var santaDirections = new List<char>();
        var robotDirections = new List<char>();
        for (var i = 0; i < allDirections.Length; i++)
        {
            if (i % 2 == 0)
                santaDirections.Add(allDirections[i]);
            else
                robotDirections.Add(allDirections[i]);
        }

        DeliverAccordingToDirections(santaDirections);
        _matrix.MoveTo(_matrix.StartAddress);
        DeliverAccordingToDirections(robotDirections);
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

    private void DeliverPresent()
    {
        var oldVal = _matrix.ReadValue();
        _matrix.WriteValue(oldVal + 1);
    }

    private void Move(char direction)
    {
        if (direction == '^')
            _matrix.MoveUp();
        if (direction == '>')
            _matrix.MoveRight();
        if (direction == 'v')
            _matrix.MoveDown();
        if (direction == '<')
            _matrix.MoveLeft();
    }
}