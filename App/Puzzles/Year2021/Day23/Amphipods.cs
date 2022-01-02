using System;
using System.Collections.Generic;
using System.Threading;
using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2021.Day23;

public class Amphipods
{
    private readonly Matrix<char> _matrix;
    private readonly Dictionary<char, int> _stepCosts;

    private readonly MatrixAddress _hallwayLeft = new(1, 1);
    private readonly MatrixAddress _hallwayA = new(2, 1);
    private readonly MatrixAddress _hallwayAb = new(4, 1);
    private readonly MatrixAddress _hallwayBc = new(6, 1);
    private readonly MatrixAddress _hallwayCd = new(8, 1);
    private readonly MatrixAddress _hallwayD = new(10, 1);
    private readonly MatrixAddress _hallwayRight = new(11, 1);

    private readonly MatrixAddress _roomA1 = new(3, 2);
    private readonly MatrixAddress _roomA2 = new(3, 3);
    private readonly MatrixAddress _roomA3 = new(3, 4);
    private readonly MatrixAddress _roomA4 = new(3, 5);

    private readonly MatrixAddress _roomB1 = new(5, 2);
    private readonly MatrixAddress _roomB2 = new(5, 3);
    private readonly MatrixAddress _roomB3 = new(5, 4);
    private readonly MatrixAddress _roomB4 = new(5, 5);

    private readonly MatrixAddress _roomC1 = new(7, 2);
    private readonly MatrixAddress _roomC2 = new(7, 3);
    private readonly MatrixAddress _roomC3 = new(7, 4);
    private readonly MatrixAddress _roomC4 = new(7, 5);

    private readonly MatrixAddress _roomD1 = new(9, 2);
    private readonly MatrixAddress _roomD2 = new(9, 3);
    private readonly MatrixAddress _roomD3 = new(9, 4);
    private readonly MatrixAddress _roomD4 = new(9, 5);

    public Amphipods(string input)
    {
        _matrix = MatrixBuilder.BuildCharMatrix(input);
        _stepCosts = new Dictionary<char, int>
        {
            { 'A', 1 },
            { 'B', 10 },
            { 'C', 100 },
            { 'D', 1000 }
        };
    }

    public int GetResult()
    {
        // solved this by hand
        var energy = 0;

        // Move right D to hallway
        energy += Move(_roomD1, _hallwayCd);

        // Move right A to hallway
        energy += Move(_roomD2, _hallwayD);

        // Move D to room
        energy += Move(_hallwayCd, _roomD2);

        // Move other A to hallway
        energy += Move(_roomC1, _hallwayA);

        // Move other D to room
        energy += Move(_roomC2, _roomD1);

        // Move both Cs to room
        energy += Move(_roomB1, _roomC2);
        energy += Move(_roomB2, _roomC1);

        // Move both Bs to room
        energy += Move(_roomA1, _roomB2);
        energy += Move(_roomA2, _roomB1);

        // move both As to room
        energy += Move(_hallwayA, _roomA2);
        energy += Move(_hallwayD, _roomA1);
        
        return energy;
    }

    public int GetResult2()
    {
        return 0;
    }

    private int Move(MatrixAddress from, MatrixAddress to)
    {
        _matrix.MoveTo(from);
        var c = _matrix.ReadValue();

        if (c == '#' || c == '.')
            throw new Exception($"Read character was '{c}'");

        _matrix.WriteValue('.');
        _matrix.MoveTo(to);
        _matrix.WriteValue(c);

        var stepCost = _stepCosts[c];
        var stepCount = from.ManhattanDistanceTo(to);
        if (from.Y > 1 && to.Y > 1)
            stepCount += Math.Min(from.Y, to.Y);

        var cost = stepCost * stepCount;
        return cost;
    }
}