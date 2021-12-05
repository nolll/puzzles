namespace ConsoleApp.Puzzles.Year2020.Day07
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