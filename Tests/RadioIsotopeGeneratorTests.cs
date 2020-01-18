using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class RadioIsotopeGeneratorTests
    {
        [Test]
        public void StepCountIsCorrect()
        {
            const string input = @"
The first floor contains a hydrogen-compatible microchip and a lithium-compatible microchip.
The second floor contains a hydrogen generator.
The third floor contains a lithium generator.
The fourth floor contains nothing relevant.";

            var simulator = new RadioisotopeSimulator(input);

            Assert.That(simulator.StepCount, Is.EqualTo(11));
        }
    }

    public class RadioisotopeSimulator
    {
        public int StepCount { get; }
        private int _currentFloor = 0;
        private IList<RadioisotopeFloor> _floors;

        public RadioisotopeSimulator(string input)
        {
            var facility = ParseFacility(input);
            var iterations = MoveElevator(facility);
        }

        private int? MoveElevator(RadioisotopeFacility facility)
        {
            return null;
        }

        private bool CanMoveUp()
        {
            return _currentFloor < _floors.Count - 1;
        }

        private bool CanMoveDown()
        {
            return _currentFloor > 0;
        }

        private IList<RadioisotopeFloor> ParseFloors(string input)
        {
            var strFloors = PuzzleInputReader.Read(input);
            return strFloors.Select(ParseFloor).ToList();
        }

        private RadioisotopeFacility ParseFacility(string input)
        {
            var strFloors = PuzzleInputReader.Read(input);
            return new RadioisotopeFacility(strFloors.Select(ParseFloor).ToList());
        }

        private RadioisotopeFloor ParseFloor(string s)
        {
            s = s.Replace(" microchip", "-microchip").Replace(" generator", "-generator").Replace(",", "").Replace(".", "");
            var parts = s.Split(" ");
            var items = parts
                .Where(o => o.EndsWith("microchip") || o.EndsWith("generator"))
                .Select(CreateItem)
                .ToList();

            var microchips = parts
                .Where(o => o.EndsWith("microchip"))
                .Select(o => o.Split('-').First())
                .ToList();
            return new RadioisotopeFloor(items);
        }

        private RadioisotopeItem CreateItem(string s)
        {
            var parts = s.Split('-');
            var name = parts.First();
            var type = parts.Last();
            if(type == "microchip")
                return new Microchip(name);
            return new Generator(name);
        }
    }

    public class RadioisotopeFacility
    {
        public IList<RadioisotopeFloor> Floors { get; }
        public int ItemCount { get; }
        public int TopFloorItemCount => Floors.Last().Items.Count;
        public bool IsDone => TopFloorItemCount == ItemCount;
        public int IterationCount { get; }

        public RadioisotopeFacility(List<RadioisotopeFloor> floors)
        {
            Floors = floors;
            IterationCount = 0;
        }

        public RadioisotopeFacility(RadioisotopeFacility facility, int iterationCount)
        {
            Floors = CopyFloors(facility);
            IterationCount = iterationCount;
        }

        private IList<RadioisotopeFloor> CopyFloors(RadioisotopeFacility facility)
        {
            var floors = new List<RadioisotopeFloor>();
            foreach (var floor in facility.Floors)
            {
                var items = new List<RadioisotopeItem>();
                foreach (var item in floor.Items)
                {
                    items.Add(item);
                }

                var newFloor = new RadioisotopeFloor(items);
            }

            return floors;
        }
    }

    public class RadioisotopeFloor
    {
        public IList<RadioisotopeItem> Items { get; }

        public RadioisotopeFloor(IList<RadioisotopeItem> items)
        {
            Items = items;
        }
    }

    public class Generator : RadioisotopeItem
    {
        public override RadioisotopeType Type => RadioisotopeType.Generator;

        public Generator(string name) : base(name)
        {
        }
    }

    public class Microchip : RadioisotopeItem
    {
        public override RadioisotopeType Type => RadioisotopeType.Microchip;

        public Microchip(string name) : base(name)
        {
        }
    }

    public abstract class RadioisotopeItem
    {
        public string Name { get; }
        public abstract RadioisotopeType Type { get; }

        protected RadioisotopeItem(string name)
        {
            Name = name;
        }
    }

    public enum RadioisotopeType
    {
        Microchip,
        Generator
    }
}