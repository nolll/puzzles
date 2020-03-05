using System;
using System.Collections.Generic;
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
            var circle = BuildCircle();
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
            var circle = BuildCircle();
            var current = circle.First;

            while (circle.Count > 1)
            {
                var next = current;
                var stepsToMove = (int)Math.Floor((double)circle.Count / 2);
                for (var i = 0; i < stepsToMove; i++)
                    next = next.NextOrFirst();
                    
                current.Value.PresentCount += next.Value.PresentCount;
                circle.Remove(next);
                current = current.NextOrFirst();
            }

            return current.Value.Id;
        }

        private LinkedList<PartyElf> BuildCircle()
        {
            var circle = new LinkedList<PartyElf>();
            for (var i = 1; i <= _elfCount; i++)
            {
                circle.AddLast(new PartyElf(i));
            }

            return circle;
        }
    }
}