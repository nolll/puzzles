namespace Core.LuggageRules
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