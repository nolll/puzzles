namespace Core.Computer.Instructions
{
    public abstract class Parameter
    {
        public int Value { get; }

        protected Parameter(int value)
        {
            Value = value;
        }
    }
}