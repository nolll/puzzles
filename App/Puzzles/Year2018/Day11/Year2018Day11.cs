using App.Platform;

namespace App.Puzzles.Year2018.Day11
{
    public class Year2018Day11 : Year2018Day
    {
        public override string Comment => "Power Grid Matrix";
        public override bool IsSlow => true;

        public override int Day => 11;

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