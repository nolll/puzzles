namespace Puzzles.aquaq.Puzzles.Aquaq08;

public abstract class AgeingProduct : Product
{
    public int Age { get; private set; }

    public AgeingProduct(int amount) : base(amount)
    {
        Age = 0;
    }

    public void IncreaseAge() => Age++;
}