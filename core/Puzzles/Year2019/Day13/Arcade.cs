using System;
using System.Linq;
using Core.Common.Computers.IntCode;
using Core.Common.CoordinateSystems.CoordinateSystem2D;

namespace Core.Puzzles.Year2019.Day13;

public class Arcade
{
    private readonly IntCodeComputer _computer;
    private readonly Matrix<char> _screen;
    private ArcadeMode _mode;
    private int _x = 0;
    private int _y = 0;
    private int _ballX = 0;
    private int _paddleX = 0;

    public int Score { get; private set; } = 0;

    public Arcade(string program)
    {
        _mode = ArcadeMode.X;

        _screen = new Matrix<char>();
        _computer = new IntCodeComputer(program, ReadInput, WriteOutput);
    }

    public void Play(int? startValue = null)
    {
        if(startValue != null)
            _computer.SetMemory(0, startValue.Value);
        _computer.Start();
    }

    public int NumberOfBlockTiles => _screen.Values.Count(o => o == ArcadeTiles.Block);

    private long ReadInput()
    {
        if (_ballX < _paddleX)
            return -1;
        if (_ballX > _paddleX)
            return 1;
        return 0;
    }

    private void WriteOutput(long output)
    {
        var value = (int) output;
        if (_mode == ArcadeMode.X)
        {
            _x = value;
            _mode = ArcadeMode.Y;
            return;
        }

        if (_mode == ArcadeMode.Y)
        {
            _y = value;
            _mode = ArcadeMode.Type;
            return;
        }

        if (_x == -1 && _y == 0)
        {
            Score = value;
        }
        else
        {
            WriteToScreen(_x, _y, value);
            var tile = ArcadeTiles.Chars[value];
            if (tile == ArcadeTiles.Ball)
            {
                _ballX = _x;
            }

            if (tile == ArcadeTiles.Paddle)
            {
                _paddleX = _x;
            }
        }
        _mode = ArcadeMode.X;
    }

    private void PrintScreen()
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.Write(_screen.Print());
    }

    private void PrintScore()
    {
        Console.WriteLine();
        Console.WriteLine($"Score: {Score}");
    }

    private void WriteToScreen(int x, int y, int tile)
    {
        _screen.MoveTo(new MatrixAddress(x, y));
        _screen.WriteValue(ArcadeTiles.Chars[tile]);
    }
}