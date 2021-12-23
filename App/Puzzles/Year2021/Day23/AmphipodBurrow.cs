using System;
using System.Collections.Generic;
using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2021.Day23;

public class AmphipodBurrow
{
    private Matrix<char> _matrix;

    public AmphipodBurrow(string input)
    {
        _matrix = MatrixBuilder.BuildCharMatrix(input);
    }

    public int Arrange()
    {
        var energyUsed = 0;

        var pods = new List<Amphipod>();
        foreach (var coord in _matrix.Coords)
        {
            var v = _matrix.ReadValueAt(coord);
            if (v != '.' && v != '#')
            {
                _matrix.MoveTo(coord);
                _matrix.WriteValue('.');
                var pod = new Amphipod(v, coord);
                pods.Add(pod);
            }
        }

        return energyUsed;
    }
}

public class Amphipod
{
    public char Type { get; }
    public MatrixAddress Coord { get; }

    public Amphipod(char type, MatrixAddress coord)
    {
        Type = type;
        Coord = coord;
    }
}