namespace ConsoleApp.Puzzles.Year2016.Puzzles.Day04
{
    public class CharacterCount
    {
        public char C { get; }
        public int Count { get; private set; }

        public CharacterCount(char c)
        {
            C = c;
            Count = 0;
        }

        public void Increment()
        {
            Count += 1;
        }
    }
}