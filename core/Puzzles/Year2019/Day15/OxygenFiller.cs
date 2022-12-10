using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems;
using Core.Common.CoordinateSystems.CoordinateSystem2D;

namespace Core.Puzzles.Year2019.Day15;

public class OxygenFiller
{
    private readonly DynamicMatrix<char> _matrix; 

    public OxygenFiller(string map)
    {
        _matrix = BuildMatrix(map.Replace(' ', '#'));
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
                _matrix.MoveTo(a);
                addressesToFill.AddRange(GetAddressesToFill());
            }

            recentlyFilledAddresses.Clear();
            foreach (var atf in addressesToFill)
            {
                _matrix.MoveTo(atf);
                _matrix.WriteValue('O');
                recentlyFilledAddresses.Add(atf);
            }

            iterations += 1;

            //Thread.Sleep(80);
            //Console.SetCursorPosition(0, 0);
            //Console.WriteLine(_matrix.Print(false, false));
        }
        return iterations;
    }

    private IList<MatrixAddress> GetAddressesToFill()
    {
        var unfilled = new List<MatrixAddress>();
        _matrix.MoveForward();
        var v = _matrix.ReadValue();
        if (v == '.')
            unfilled.Add(_matrix.Address);
        _matrix.MoveBackward();

        _matrix.TurnTo(MatrixDirection.Right);
        _matrix.MoveForward();
        v = _matrix.ReadValue();
        if (v == '.')
            unfilled.Add(_matrix.Address);
        _matrix.MoveBackward();

        _matrix.TurnTo(MatrixDirection.Down);
        _matrix.MoveForward();
        v = _matrix.ReadValue();
        if (v == '.')
            unfilled.Add(_matrix.Address);
        _matrix.MoveBackward();

        _matrix.TurnTo(MatrixDirection.Left);
        _matrix.MoveForward();
        v = _matrix.ReadValue();
        if (v == '.')
            unfilled.Add(_matrix.Address);
        _matrix.MoveBackward();

        _matrix.TurnTo(MatrixDirection.Up);
        return unfilled;
    }

    private DynamicMatrix<char> BuildMatrix(string map)
    {
        var matrix = new DynamicMatrix<char>(1, 1);
        var rows = map.Trim().Split('\n');
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.Trim().Trim('_').ToCharArray();
            foreach (var c in chars)
            {
                matrix.MoveTo(x, y);
                matrix.WriteValue(c);
                x += 1;
            }

            y += 1;
        }

        //Console.WriteLine(matrix.Print(false, false));
        return matrix;
    }
}