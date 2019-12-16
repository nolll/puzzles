using System;
using Core.Computer;
using Core.Tools;

namespace Core.OxygenSystem
{
    public enum DroidDirection
    {
        None = 0,
        North = 1,
        South = 2,
        West = 3,
        East = 4
    }

    public class RepairDroid
    {
        private readonly ComputerInterface _computer;
        private readonly Matrix<char> _matrix;
        private int _steps;
        private DroidDirection NextDirection => GetDroidDirection();
        private const int Size = 100;

        public RepairDroid(string program)
        {
            _computer = new ComputerInterface(program, ReadInput, WriteOutput);
            _matrix = new Matrix<char>(Size, Size);
            Console.WriteLine("...");
            Console.WriteLine(_matrix.Print());
            Console.WriteLine("---");
        }

        public int Run()
        {
            _steps = 0;
            const int startPOint = Size / 2 - 1;
            _matrix.MoveTo(startPOint, startPOint);
            _computer.Start();
            return _steps;
        }

        private long ReadInput()
        {
            return (int)NextDirection;
        }

        private void WriteOutput(long output)
        {
            if (output == 0)
            {
                var currentAddress = _matrix.Address;
                _matrix.MoveForward();
                _matrix.WriteValue('#');
                _matrix.MoveTo(currentAddress);
                _matrix.TurnRight();
                return;
            }

            if (output == 1)
            {
                _matrix.MoveForward();
                _matrix.WriteValue('.');
                return;
            }
            if (output == 2)
            {
                _matrix.MoveForward();
                _matrix.WriteValue('X');
                return;
            }

            Console.WriteLine(_matrix.Print());
        }

        private DroidDirection GetDroidDirection()
        {
            if (_matrix.Direction == MatrixDirection.Right)
                return DroidDirection.East;
            if (_matrix.Direction == MatrixDirection.Down)
                return DroidDirection.South;
            if (_matrix.Direction == MatrixDirection.Left)
                return DroidDirection.West;
            return DroidDirection.North;
        }
    }
}