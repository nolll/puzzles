using System.Collections.Generic;
using Core.Tools;

namespace Core.WhiteElephants
{
    public class WhiteElephantParty
    {
        public int Winner { get; }

        public WhiteElephantParty(in int elfCount)
        {
            var circle = new LinkedList<PartyElf>();
            for (var i = 1; i <= elfCount; i++)
            {
                circle.AddLast(new PartyElf(i));
            }

            var current = circle.First;

            while (circle.Count > 1)
            {
                var next = current.NextOrFirst();
                current.Value.PresentCount += next.Value.PresentCount;
                circle.Remove(next);
                current = current.NextOrFirst();
            }

            Winner = current.Value.Id;
        }
    }
}