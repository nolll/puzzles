using App.Platform;

namespace App.Puzzles.Year2021.Day16
{
    public class Year2021Day16 : Puzzle
    {
        public override PuzzleResult RunPart1()
        {
            var packet = BitsPacket.FromHex(FileInput);
            var result = packet.VersionSum;

            return new PuzzleResult(result, 879);
        }

        public override PuzzleResult RunPart2()
        {
            var packet = BitsPacket.FromHex(FileInput);
            var result = packet.Value;

            return new PuzzleResult(result, 539051801941);
        }
    }
}