namespace Puzzles.aquaq.Puzzles.Aquaq08;

public abstract class Product
{
    public int Amount { get; private set; }

    public Product(int amount)
    {
        Amount = amount;
    }

    public void Consume() => Amount -= 100;
}