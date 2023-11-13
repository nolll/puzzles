namespace Puzzles.aoc.Puzzles.Aoc2020.Aoc202020;

public abstract class TileMatcher
{
    private readonly List<Action<JigsawTile>> _searchFlips = new()
    {
        (tile) => tile.FlipVertical(),
        (tile) => tile.FlipHorizontal(),
        (tile) => tile.FlipVertical(),
        (tile) => tile.FlipHorizontal()
    };

    protected abstract bool IsMatch(JigsawTile tile);

    public void TryAllRotations(JigsawTile tile)
    {
        foreach (var flip in _searchFlips)
        {
            flip(tile);
            for (var i = 0; i < 4; i++)
            {
                tile.RotateRight();

                if (IsMatch(tile)) 
                    return;
            }
        }
    }
}