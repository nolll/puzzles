namespace Core.TreeNavigation
{
    public class TreeTrajectory
    {
        public int Right { get; }
        public int Down { get; }

        public TreeTrajectory(int right, int down)
        {
            Right = right;
            Down = down;
        }
    }
}