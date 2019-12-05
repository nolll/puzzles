namespace Core.Computer.Instructions
{
    public abstract class Parameter
    {
        public abstract bool IsImmediate { get; }
        public abstract int ReadValue(int[] memory, int position);
    }
}