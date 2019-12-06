namespace Core.Computer.Instructions
{
    public class ImmediateParameter : Parameter
    {
        public ImmediateParameter(int[] memory, int position)
            : base(memory[position])
        {
        }
    }
}