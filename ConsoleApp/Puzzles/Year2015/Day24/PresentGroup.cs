namespace ConsoleApp.Puzzles.Year2015.Day24
{
    public class PresentGroup
    {
        public int Count { get; private set; }
        public int Sum { get; private set; }
        public long QuantumEntanglement { get; private set; }

        public PresentGroup() : this(0, 0, 1)
        {
        }

        private PresentGroup(int count, int sum, long quantumEntanglement)
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