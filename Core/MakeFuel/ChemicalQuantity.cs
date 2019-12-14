namespace Core.MakeFuel
{
    public class ChemicalQuantity
    {
        public string Name { get; }
        public int Quantity { get; }

        public ChemicalQuantity(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}