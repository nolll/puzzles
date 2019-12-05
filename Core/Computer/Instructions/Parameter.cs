namespace Core.Computer.Instructions
{
    public abstract class Parameter
    {
        public abstract int ReadValue(int[] memory, int position);
    }
}