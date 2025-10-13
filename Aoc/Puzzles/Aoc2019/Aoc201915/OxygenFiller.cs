using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201915;

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
            var addressesToFill = new List<Coord>();
            foreach (var a in recentlyFilledAddresses)
            {
                var validAddresses = _matrix.OrthogonalAdjacentCoordsTo(a).Where(o => _matrix.ReadValueAt(o) == '.');
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