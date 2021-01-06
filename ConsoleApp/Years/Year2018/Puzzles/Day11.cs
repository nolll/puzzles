using System;
using Core.FuelSquare;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day11 : Day2018
    {
        public override string Comment => "Power Grid Matrix";

        public Day11() : base(11)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var grid1 = new PowerGrid(300, Input);
            var maxCoords = grid1.GetMaxCoords();
            var strCoords = $"{maxCoords.X},{maxCoords.Y}";
            return new PuzzleResult(strCoords, "20,43");
        }

        public override PuzzleResult RunPart2()
        {
            var grid2 = new PowerGrid(300, Input);
            var (coords2, size2) = grid2.GetMaxCoordsAnySize();
            var strCoordsAndSize2 = $"{coords2.X},{coords2.Y},{size2}";
            return new PuzzleResult(strCoordsAndSize2, "233,271,13");
        }

        private const int Input = 1309;
    }
}