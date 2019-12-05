namespace Core.Computer.Instructions
{
    public class ImmediateParameter : Parameter
    {
        public override bool IsImmediate => true;

        public override int ReadValue(int[] memory, int position)
        {
            return memory[position];
        }
    }
}