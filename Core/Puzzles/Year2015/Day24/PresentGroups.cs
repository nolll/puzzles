namespace Core.Puzzles.Year2015.Day24
{
    public class PresentGroups
    {
        public PresentGroup[] Groups { get; }
        public int Current { get; }

        public PresentGroups()
            : this(new PresentGroup(), new PresentGroup(), new PresentGroup())
        {
        }

        public PresentGroups(PresentGroup group1, PresentGroup group2, PresentGroup group3, int current = 0)
        {
            Current = 0;
            Groups = new PresentGroup[]
            {
                group1,
                group2,
                group3
            };
        }

        public PresentGroups Clone()
        {
            return new PresentGroups(Groups[0].Clone(), Groups[1].Clone(), Groups[2].Clone(), Current);
        }
    }
}