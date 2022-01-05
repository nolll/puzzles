using System;
using System.Collections.Generic;
using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2021.Day23;

public class Amphipods
{
    private readonly bool _isPrinterEnabled;
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

    public int Energy { get; private set; }

    public Amphipods(string input, bool isPrinterEnabled = false)
    {
        _isPrinterEnabled = isPrinterEnabled;
        _matrix = MatrixBuilder.BuildCharMatrix(input.Replace('.', ' ').Replace('#', '.'));
        _stepCosts = new Dictionary<char, int>
        {
            { 'A', 1 },
            { 'B', 10 },
            { 'C', 100 },
            { 'D', 1000 }
        };
    }

    public void ArrangePart1()
    {
        // Move right D to hallway
        Move(_roomD1, _hallwayCd);

        // Move right A to hallway
        Move(_roomD2, _hallwayD);

        // Move D to room
        Move(_hallwayCd, _roomD2);

        // Move other A to hallway
        Move(_roomC1, _hallwayA);

        // Move other D to room
        Move(_roomC2, _roomD1);

        // Move both Cs to room
        Move(_roomB1, _roomC2);
        Move(_roomB2, _roomC1);

        // Move both Bs to room
        Move(_roomA1, _roomB2);
        Move(_roomA2, _roomB1);

        // move both As to room
        Move(_hallwayA, _roomA2);
        Move(_hallwayD, _roomA1);
    }

    public void ArrangePart2()
    {
        Print();

        // Clear room C
        Move(_roomC1, _hallwayLeft);
        Move(_roomC2, _hallwayD);
        Move(_roomC3, _hallwayA);
        Move(_roomC4, _hallwayAb);

        // Move two Cs to room
        Move(_roomB1, _roomC4);
        Move(_roomB2, _roomC3);

        // Move B to hallway
        Move(_roomB3, _hallwayCd);

        // Move C to room
        Move(_roomB4, _roomC2);

        // Move two Bs to room
        Move(_hallwayCd, _roomB4);
        Move(_hallwayD, _roomB3);

        // Clear room D
        Move(_roomD1, _hallwayBc);
        Move(_roomD2, _hallwayRight);
        Move(_roomD3, _roomC1);
        Move(_roomD4, _hallwayD);

        // Move Ds and Bs to rooms
        Move(_hallwayBc, _roomD4);
        Move(_hallwayAb, _roomD3);
        Move(_roomA1, _roomB2);
        Move(_roomA2, _roomD2);
        Move(_roomA3, _roomD1);
        Move(_roomA4, _roomB1);

        // Move As to room
        Move(_hallwayA, _roomA4);
        Move(_hallwayLeft, _roomA3);
        Move(_hallwayD, _roomA2);
        Move(_hallwayRight, _roomA1);
    }

    public void TestArrange()
    {
        Move(_roomD1, _hallwayRight);
        Move(_roomD2, _hallwayLeft);
        Move(_roomC1, _hallwayD);
        Move(_roomC2, _hallwayCd);
        Move(_roomC3, _hallwayA);
        Move(_roomB1, _roomC3);
        Move(_roomB2, _roomC2);
        Move(_roomB3, _hallwayBc);
        Move(_roomB4, _hallwayAb);
        Move(_hallwayBc, _roomB4);
        Move(_hallwayCd, _roomB3);
        Move(_hallwayD, _roomB2);
        Move(_roomD3, _roomC1);
        Move(_roomD4, _hallwayD);
        Move(_hallwayAb, _roomD4);
        Move(_roomA1, _roomB1);
        Move(_roomA2, _roomD3);
        Move(_roomA3, _roomD2);
        Move(_hallwayA, _roomA3);
        Move(_hallwayLeft, _roomA2);
        Move(_hallwayD, _roomA1);
        Move(_hallwayRight, _roomD1);
    }

    private void Move(MatrixAddress from, MatrixAddress to)
    {
        _matrix.MoveTo(from);
        var c = _matrix.ReadValue();

        if (c == '.' || c == ' ')
            throw new Exception($"Read character was '{c}'. Must be a letter");

        if (_matrix.ReadValueAt(to) != ' ')
            throw new Exception($"Target character was '{c}'. Must be ' '");
        
        _matrix.WriteValue(' ');
        _matrix.MoveTo(to);
        _matrix.WriteValue(c);

        var stepCost = _stepCosts[c];
        var stepCount = 0;
        if (from.Y > 1 && to.Y > 1)
            stepCount += from.Y - 1 + new MatrixAddress(from.X, 1).ManhattanDistanceTo(to);
        else
            stepCount = from.ManhattanDistanceTo(to);

        var cost = stepCost * stepCount;
        Energy += cost;
        
        Print();
    }

    private void Print()
    {
        if (!_isPrinterEnabled)
            return;

        Console.WriteLine(_matrix.Print());
        Console.WriteLine($"Energy: {Energy}");
        Console.WriteLine();
    }
}