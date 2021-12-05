namespace ConsoleApp.Puzzles.Year2020.Puzzles.Day07
{
    public class SubBag
    {
        public Bag Bag { get; }
        public int Quantity { get; }

        public SubBag(Bag bag, int quantity)
        {
            Bag = bag;
            Quantity = quantity;
        }
    }
}