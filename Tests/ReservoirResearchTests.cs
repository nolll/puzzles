using System.Collections.Generic;
using System.Linq;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class ReservoirResearchTests
    {
        [Test]
        public void NumberOfWaterTilesIsCorrect()
        {
            const string input = @"
x=495, y=2..7
y=7, x=495..501
x=501, y=3..7
x=498, y=2..4
x=506, y=1..2
x=498, y=10..13
x=504, y=10..13
y=13, x=498..504";

            var filler = new ReservoirFiller(input);
            filler.Fill();

            Assert.That(filler.WaterTileCount, Is.EqualTo(57));
        }
    }

    public class ReservoirFiller
    {
        private Matrix<char> _matrix;
        private int _xMin = int.MaxValue;
        private int _xMax = int.MinValue;
        private int _yMin = int.MaxValue;
        private int _yMax = int.MinValue;
        private readonly MatrixAddress _source = new MatrixAddress(500, 0);
        private List<MatrixAddress> _openAddresses;

        public int WaterTileCount => 0;

        public ReservoirFiller(string input)
        {
            BuildMatrix(input);
        }

        private void BuildMatrix(string input)
        {
            _matrix = new Matrix<char>(1, 1, '.');
            _matrix.MoveTo(_source);
            _matrix.WriteValue('+');

            var rows = PuzzleInputReader.Read(input);

            foreach (var row in rows)
            {
                var parts = row.Split(',');
                var parts2 = parts[0].Split('=');
                if (parts2[0].First() == 'x')
                {
                    var x = int.Parse(parts2[1]);
                    var yValues = parts[1].Split('=')[1].Split("..").Select(int.Parse).ToList();
                    var startY = yValues[0];
                    var endY = yValues[1];
                    for (var y = startY; y <= endY; y++)
                    {
                        WriteWall(x, y);
                    }
                }
                else
                {
                    var y = int.Parse(parts2[1]);
                    var xValues = parts[1].Split('=')[1].Split("..").Select(int.Parse).ToList();
                    var startX = xValues[0];
                    var endX = xValues[1];
                    for (var x = startX; x <= endX; x++)
                    {
                        WriteWall(x, y);
                    }
                }
            }
        }

        private void WriteWall(in int x, in int y)
        {
            _matrix.MoveTo(x, y);
            _matrix.WriteValue('#');
            SetMinAndMax(x, y);
        }

        private void SetMinAndMax(in int x, in int y)
        {
            if (x < _xMin)
                _xMin = x;
            if (x > _xMax)
                _xMax = x;
            if (y < _yMin)
                _yMin = y;
            if (y > _yMax)
                _yMax = y;

        }

        public void Fill()
        {
            _openAddresses = new List<MatrixAddress> { new MatrixAddress(_source.X, _source.Y + 1) };
            while (_openAddresses.Any())
            {
                var current = _openAddresses.First();
                var addressBelow = new MatrixAddress(current.X, current.Y + 1);
                var valueBelow = _matrix.ReadValueAt(addressBelow);
                if (valueBelow == '.' || valueBelow == '|')
                {
                    _matrix.MoveDown();
                }
                else
                {

                }
            }
        }
    }
}