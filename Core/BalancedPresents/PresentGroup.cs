namespace Core.BalancedPresents
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

    public class PresentGroup
    {
        public int Count { get; private set; }
        public int Sum { get; private set; }
        public int QuantumEntanglement { get; private set; }

        public PresentGroup() : this(0, 0, 1)
        {
        }

        private PresentGroup(int count, int sum, int quantumEntanglement)
        {
            Count = count;
            Sum = sum;
            QuantumEntanglement = quantumEntanglement;
        }

        public void Add(int i)
        {
            Count++;
            Sum += i;
            QuantumEntanglement *= i;
        }

        public PresentGroup Clone()
        {
            return new PresentGroup(Count, Sum, QuantumEntanglement);
        }
    }
}