namespace App.Puzzles.Year2021.Day21;

public class DiracDicePlayer
{
    public int Score { get; private set; }
    public int Pos { get; private set; }

    public DiracDicePlayer(int pos)
    {
        Pos = pos;
    }

    public int Move(int dice)
    {
        for (var i = 0; i < 3; i++)
        {
            dice++;
            Pos = (Pos + dice) % 10;
        }

        Score += Pos + 1;

        return dice;
    }
}