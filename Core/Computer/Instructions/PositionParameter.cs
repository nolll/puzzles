namespace Core.Computer.Instructions
{
    public class PositionParameter : Parameter
    {
        public override int ReadValue(int[] memory, int position)
        {
            return memory[memory[position]];
        }
    }
}