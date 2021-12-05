using Core.LineDance;

namespace ConsoleApp.Puzzles.Year2017.Puzzles
{
    public class Year2017Day16 : Year2017Day
    {
        public override int Day => 16;

        public override PuzzleResult RunPart1()
        {
            var dancingPrograms1 = new DancingPrograms();
            dancingPrograms1.Dance(FileInput, 1);
            return new PuzzleResult(dancingPrograms1.Programs, "ehdpincaogkblmfj");
        }

        public override PuzzleResult RunPart2()
        {
            var dancingPrograms2 = new DancingPrograms();
            dancingPrograms2.Dance(FileInput, 1_000_000_000);
            return new PuzzleResult(dancingPrograms2.Programs, "bpcekomfgjdlinha");
        }
    }
}