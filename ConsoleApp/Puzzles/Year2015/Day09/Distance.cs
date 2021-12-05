namespace ConsoleApp.Puzzles.Year2015.Day09
{
    public class Distance
    {
        public string From { get; }
        public string To { get; }
        public int Dist { get; }

        public Distance(string from, string to, int dist)
        {
            From = @from;
            To = to;
            Dist = dist;
        }
    }
}