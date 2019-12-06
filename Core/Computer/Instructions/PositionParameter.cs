namespace Core.Computer.Instructions
{
    public class PositionParameter : Parameter
    {
        public PositionParameter(int[] memory, int position)
            : base(memory[memory[position]])
        {
        }
    }
}