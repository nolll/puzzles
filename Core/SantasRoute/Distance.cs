namespace Core.SantasRoute
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