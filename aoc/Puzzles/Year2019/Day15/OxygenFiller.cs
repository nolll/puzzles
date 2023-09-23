using System.Collections.Generic;
using System.Linq;
using Common.CoordinateSystems.CoordinateSystem2D;

namespace Aoc.Puzzles.Year2019.Day15;

public class OxygenFiller
{
    private readonly Matrix<char> _matrix;

    public OxygenFiller(Matrix<char> matrix)
    {
        matrix.MoveTo(matrix.StartAddress);
        matrix.TurnTo(MatrixDirection.Up);
        _matrix = matrix;
    }

    public OxygenFiller(string map)
        : this(MatrixBuilder.BuildCharMatrix(map.Replace(' ', '#'), ' '))
    {
    }

    public int Fill()
    {
        var iterations = 0;
        var recentlyFilledAddresses = _matrix.FindAddresses('X');
        while (_matrix.Values.Any(o => o == '.'))
        {
            var addressesToFill = new List<MatrixAddress>();
            foreach (var a in recentlyFilledAddresses)
            {
                var validAddresses = _matrix.PerpendicularAdjacentCoordsTo(a).Where(o => _matrix.ReadValueAt(o) == '.');
                addressesToFill.AddRange(validAddresses);
            }

            recentlyFilledAddresses.Clear();
            foreach (var atf in addressesToFill)
            {
                _matrix.WriteValueAt(atf, 'O');
                recentlyFilledAddresses.Add(atf);
            }

            iterations += 1;
        }

        return iterations;
    }
}