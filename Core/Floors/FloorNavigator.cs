namespace Core.Floors
{
    public class FloorNavigator
    {
        public int DestinationFloor { get; }

        public FloorNavigator(string input)
        {
            var instructions = input.ToCharArray();
            foreach (var c in instructions)
            {
                if (c == '(')
                    DestinationFloor++;
                if (c == ')')
                    DestinationFloor--;
            }
        }
    }
}