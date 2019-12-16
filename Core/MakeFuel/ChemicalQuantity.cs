namespace Core.MakeFuel
{
    public class ChemicalQuantity
    {
        public string Name { get; }
        public long Quantity { get; }

        public ChemicalQuantity(string name, long quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}