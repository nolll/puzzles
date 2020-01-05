namespace Core.SantasSuit
{
    public class Claim
    {
        public int Id { get; }
        public int Left { get; }
        public int Top { get; }
        public int Width { get; }
        public int Height { get; }

        public Claim(int id, int left, int top, int width, int height)
        {
            Id = id;
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }
    }
}