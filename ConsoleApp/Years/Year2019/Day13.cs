using System;
using System.Linq;
using System.Threading;
using Core.Computer;
using Core.Tools;
using Data.Inputs;

namespace ConsoleApp.Years.Year2019
{
    public class Day13 : Day
    {
        public Day13() : base(13)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var arcade1 = new Arcade(InputData.ComputerProgramDay13);
            arcade1.Play();

            Console.WriteLine($"Number of block tiles: {arcade1.NumberOfBlockTiles}");

            WritePartTitle();
            var arcade2 = new Arcade(InputData.ComputerProgramDay13);
            arcade2.Play(2);
        }
    }

    public enum ArcadeMode
    {
        X,
        Y,
        Type
    }

    public class Arcade
    {
        private readonly ComputerInterface _computer;
        private readonly Matrix<int> _screen;
        private ArcadeMode _mode;
        private int _x = 0;
        private int _y = 0;

        public Arcade(string program)
        {
            _mode = ArcadeMode.X;

            _screen = new Matrix<int>(1, 1);
            _computer = new ComputerInterface(program, ReadInput, WriteOutput);
        }

        public void Play(int startValue = 0)
        {
            _computer.Start();
        }

        public int NumberOfBlockTiles => _screen.Values.Count(o => o == 2);

        private long ReadInput()
        {
            return 0;
        }

        private void WriteOutput(long output)
        {
            if (_mode == ArcadeMode.X)
            {
                _x = (int)output;
                _mode = ArcadeMode.Y;
                return;
            }

            if (_mode == ArcadeMode.Y)
            {
                _y = (int)output;
                _mode = ArcadeMode.Type;
                return;
            }

            WriteToScreen(_x, _y, (int)output);
            _mode = ArcadeMode.X;
        }

        private void WriteToScreen(int x, int y, int tile)
        {
            if (x == 0 && y == 0)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(_screen.Print());
                Thread.Sleep(50);
            }
            _screen.MoveTo(new MatrixAddress(x, y));
            _screen.WriteValue(tile);
        }
    }
}