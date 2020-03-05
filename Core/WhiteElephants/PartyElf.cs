namespace Core.WhiteElephants
{
    public class PartyElf
    {
        public int Id { get; }
        public int PresentCount { get; set; }

        public PartyElf(int id)
        {
            Id = id;
            PresentCount = 1;
        }
    }
}