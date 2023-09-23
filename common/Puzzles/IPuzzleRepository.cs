namespace Common.Puzzles;

public interface IPuzzleRepository
{
    Puzzle? GetPuzzle(string id);
    IList<Puzzle> GetPuzzles();
}