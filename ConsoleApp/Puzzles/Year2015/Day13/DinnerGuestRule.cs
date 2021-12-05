namespace ConsoleApp.Puzzles.Year2015.Day13
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