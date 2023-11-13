namespace Puzzles.common.Puzzles;

public interface IPuzzleRepository
{
    Puzzle? GetPuzzle(string id);
    IList<Puzzle> GetPuzzles();
}