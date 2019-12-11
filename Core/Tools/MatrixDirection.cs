namespace Core.Tools
{
    public class MatrixDirection
    {
        public int X { get; }
        public int Y { get; }

        private MatrixDirection(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public static readonly MatrixDirection Up = new MatrixDirection(0, -1);
        public static readonly MatrixDirection Right = new MatrixDirection(1, 0);
        public static readonly MatrixDirection Down = new MatrixDirection(0, 1);
        public static readonly MatrixDirection Left = new MatrixDirection(-1, 0);
    }
}