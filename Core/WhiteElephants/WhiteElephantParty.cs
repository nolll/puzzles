using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.WhiteElephants
{
    public class WhiteElephantParty
    {
        private readonly int _elfCount;

        public WhiteElephantParty(in int elfCount)
        {
            _elfCount = elfCount;
        }

        public int StealFromNextElf()
        {
            var circle = BuildLinkedCircle();
            var current = circle.First;

            while (circle.Count > 1)
            {
                var next = current.NextOrFirst();
                current.Value.PresentCount += next.Value.PresentCount;
                circle.Remove(next);
                current = current.NextOrFirst();
            }

            return current.Value.Id;
        }

        public int StealFromElfAcrossCircle()
        {
            var circle = BuildListCircle();
            var current = 0;

            while (circle.Count > 1)
            {
                var stepsToMove = (int)Math.Floor((double)circle.Count / 2);
                var next = current + stepsToMove;
                if (next > circle.Count - 1)
                    next -= circle.Count;
                
                circle[current].PresentCount += circle[next].PresentCount;
                circle.RemoveAt(next);
                current++;
                if (current > circle.Count - 1)
                    current -= circle.Count;
            }

            return circle.First().Id;
        }

        private LinkedList<PartyElf> BuildLinkedCircle()
        {
            var circle = new LinkedList<PartyElf>();
            for (var i = 1; i <= _elfCount; i++)
            {
                circle.AddLast(new PartyElf(i));
            }

            return circle;
        }

        private IList<PartyElf> BuildListCircle()
        {
            var circle = new List<PartyElf>();
            for (var i = 1; i <= _elfCount; i++)
            {
                circle.Add(new PartyElf(i));
            }

            return circle;
        }
    }
}