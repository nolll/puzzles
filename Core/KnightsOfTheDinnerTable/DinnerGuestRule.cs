namespace Core.KnightsOfTheDinnerTable
{
    public class DinnerGuestRule
    {
        public string Name { get; }
        public int Happiness { get; }

        public DinnerGuestRule(string name, int happiness)
        {
            Name = name;
            Happiness = happiness;
        }
    }
}