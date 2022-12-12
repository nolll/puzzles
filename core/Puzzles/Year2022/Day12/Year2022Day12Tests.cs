using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems.CoordinateSystem2D;
using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day12;

public class HillClimbing
{
    public int Part1(string input)
    {
        var matrix = MatrixBuilder.BuildStaticCharMatrix(input);
        var (from, to) = FindFromAndTo(matrix);
        var steps = HillClimbingPathFinder.StepCountTo(matrix, from, to);

        return steps;
    }

    public int Part2(string input)
    {
        var matrix = MatrixBuilder.BuildStaticCharMatrix(input);
        var (_, to) = FindFromAndTo(matrix);
        var startingPoints = FindStartingPoints(matrix);

        var stepCounts = new List<int>();
        foreach (var from in startingPoints)
        {
            var steps = HillClimbingPathFinder.StepCountTo(matrix, from, to);
            stepCounts.Add(steps);
        }
        

        return stepCounts.Where(o => o > 0).Min();
    }

    private List<MatrixAddress> FindStartingPoints(IMatrix<char> matrix)
    {
        var startingPositions = new List<MatrixAddress>();
        foreach (var coord in matrix.Coords)
        {
            if (matrix.ReadValueAt(coord) == 'a')
            {
                startingPositions.Add(coord);
            }
        }

        return startingPositions;
    }

    private (MatrixAddress from, MatrixAddress to) FindFromAndTo(IMatrix<char> matrix)
    {
        var from = new MatrixAddress(0, 0);
        var to = new MatrixAddress(0, 0);
        foreach (var coord in matrix.Coords)
        {
            if (matrix.ReadValueAt(coord) == 'S')
            {
                matrix.WriteValueAt(coord, 'a');
                from = coord;
            }
            if (matrix.ReadValueAt(coord) == 'E')
            {
                matrix.WriteValueAt(coord, 'z');
                to = coord;
            }
        }

        return (from, to);
    }
}

public class Year2022Day12Tests
{
    [Test]
    public void Part1()
    {
        var hillClimbing = new HillClimbing();
        var result = hillClimbing.Part1(Input);

        Assert.That(result, Is.EqualTo(31));
    }

    [Test]
    public void Part2()
    {
        var hillClimbing = new HillClimbing();
        var result = hillClimbing.Part2(Input);

        Assert.That(result, Is.EqualTo(29));
    }

    private const string Input = @"
Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi";
}