using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems;
using Core.Common.Strings;
using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day08;

public class TreeHouse
{
    private readonly StaticMatrix<int> _treeMatrix;
    private readonly StaticMatrix<char> _visibleMatrix;
    private readonly MatrixDirection[] _directions;

    public TreeHouse(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input, false);
        var patchWidth = lines[0].Length;
        var patchHeight = lines.Count;
        _treeMatrix = new StaticMatrix<int>(patchWidth, patchHeight);
        _visibleMatrix = new StaticMatrix<char>(patchWidth, patchHeight);
        _directions = new [] {MatrixDirection.Up, MatrixDirection.Right, MatrixDirection.Down, MatrixDirection.Left };
    }

    public int Part1()
    {
        foreach (var coord in _treeMatrix.Coords)
        {
            var visibility = new Dictionary<MatrixDirection, bool>
            {
                [MatrixDirection.Up] = true,
                [MatrixDirection.Right] = true,
                [MatrixDirection.Down] = true,
                [MatrixDirection.Left] = true
            };

            _treeMatrix.MoveTo(coord);
            var currentTreeHeight = _treeMatrix.ReadValue();

            foreach (var direction in _directions)
            {
                _treeMatrix.TurnTo(direction);
                while (_treeMatrix.TryMoveForward())
                {
                    if (_treeMatrix.ReadValue() <= currentTreeHeight)
                    {
                        visibility[direction] = false;
                        break;
                    }
                }
            }

            var v = visibility.Values.Count(o => o) > 0 ? '#' : '.';
            _visibleMatrix.WriteValueAt(coord, v);
        }

        Console.WriteLine(_visibleMatrix.Print());

        return _visibleMatrix.Values.Count(o => o == '#');
    }
}

public class Year2022Day08Tests
{
    [Test]
    public void Part1()
    {
        var treeHouse = new TreeHouse(Input);
        var result = treeHouse.Part1();

        Assert.That(result, Is.EqualTo(21));
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
    }

    private const string Input = @"
30373
25512
65332
33549
35390";
}