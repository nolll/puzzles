using System;
using System.Collections.Generic;
using Core.Tools;

namespace ConsoleApp.Puzzles.Year2016.Puzzles
{
    public class Year2016Day19 : Year2016Day
    {
        public override int Day => 19;

        public override PuzzleResult RunPart1()
        {
            var party = new WhiteElephantParty(Input);
            var winner = party.StealFromNextElf();
            return new PuzzleResult(winner, 1_808_357);
        }

        public override PuzzleResult RunPart2()
        {
            var party = new WhiteElephantParty(Input);
            var winner = party.StealFromElfAcrossCircle();
            return new PuzzleResult(winner, 1_407_007);
        }

        private const int Input = 3001330;
    }

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
                circle.Remove(next);
                current = current.NextOrFirst();
            }

            return current.Value.Id;
        }

        public int StealFromElfAcrossCircle()
        {
            var circle = BuildCircle();
            var current = circle.First;
            var victim = circle.First;
            var halfWay = (int)Math.Floor((double)circle.Count / 2);
            for (var i = 0; i < halfWay; i++)
                victim = victim.NextOrFirst();

            var elvesLeft = _elfCount;
            while (circle.Count > 1)
            {
                var nextVictim = elvesLeft % 2 == 1 ? victim.NextOrFirst().NextOrFirst() : victim.NextOrFirst();
                circle.Remove(victim);
                current = current.NextOrFirst();
                victim = nextVictim;
                elvesLeft--;
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

    public class PartyElf
    {
        public int Id { get; }

        public PartyElf(int id)
        {
            Id = id;
        }
    }
}