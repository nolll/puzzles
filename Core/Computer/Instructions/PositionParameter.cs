namespace Core.Computer.Instructions
{
    public class PositionParameter : Parameter
    {
        public override bool IsImmediate => false;
        
        public override int ReadValue(int[] memory, int position)
        {
            return memory[memory[position]];
        }
    }
}