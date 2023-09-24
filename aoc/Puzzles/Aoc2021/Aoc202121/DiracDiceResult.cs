namespace Aoc.Puzzles.Aoc2021.Day21;

public class DiracDiceResult
{
    public int MinScore { get; }
    public int Rolls { get; }
    public int Result => MinScore * Rolls;

    public DiracDiceResult(int minScore, int rolls)
    {
        MinScore = minScore;
        Rolls = rolls;
    }
}