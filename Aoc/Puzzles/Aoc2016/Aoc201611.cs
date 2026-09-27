using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Radioisotope Thermoelectric Generators")]
public class Aoc201611 : AocPuzzle
{
    [Puzzle("ad33c84632fce9c362c34badb2563b3e")]
    public int Part1(string input) => new RadioisotopeSimulator(Input1).StepCount;

    [Puzzle("19a0276a07d73a49e5bde8ad4f1ee6ee")]
    public int Part2(string input) => new RadioisotopeSimulator(Input2).StepCount;

    private const string Input1 = """
                                  The first floor contains a strontium generator, a strontium-compatible microchip, a plutonium generator, and a plutonium-compatible microchip.
                                  The second floor contains a thulium generator, a ruthenium generator, a ruthenium-compatible microchip, a curium generator, and a curium-compatible microchip.
                                  The third floor contains a thulium-compatible microchip.
                                  The fourth floor contains nothing relevant.
                                  """;

    private const string Input2 = """
                                  The first floor contains a strontium generator, a strontium-compatible microchip, a plutonium generator, a plutonium-compatible microchip, an elerium generator, an elerium-compatible microchip, a dilithium generator, and a dilithium-compatible microchip.
                                  The second floor contains a thulium generator, a ruthenium generator, a ruthenium-compatible microchip, a curium generator, and a curium-compatible microchip.
                                  The third floor contains a thulium-compatible microchip.
                                  The fourth floor contains nothing relevant.
                                  """;
    
    public class AnonymousNameProvider
    {
        private readonly Dictionary<int, string> _generatorCache = new();
        private readonly Dictionary<int, string> _microchipCache = new();

        public string GetGeneratorName(int counter)
        {
            if (_generatorCache.TryGetValue(counter, out var s))
                return s;
        
            s = string.Concat(counter, 'X');
            _generatorCache.Add(counter, s);

            return s;
        }

        public string GetMicrochipName(int counter)
        {
            if (_microchipCache.TryGetValue(counter, out var s))
                return s;
        
            s = string.Concat(counter, 'Y');
            _microchipCache.Add(counter, s);

            return s;
        }
    }
    
    public class IsotopeNameProvider
    {
        private readonly Dictionary<char, string> _generatorCache = new();
        private readonly Dictionary<char, string> _microchipCache = new();

        public string GetGeneratorName(char name)
        {
            if (_generatorCache.TryGetValue(name, out var s))
                return s;
        
            s = string.Concat(name, 'G');
            _generatorCache.Add(name, s);

            return s;
        }

        public string GetMicrochipName(char name)
        {
            if (_microchipCache.TryGetValue(name, out var s)) 
                return s;
        
            s = string.Concat(name, 'M');
            _microchipCache.Add(name, s);

            return s;
        }
    }
    
    public class Generator(string name) : RadioisotopeItem(name, RadioisotopeType.Generator);
    public class Microchip(string name) : RadioisotopeItem(name, RadioisotopeType.Microchip);

    public class RadioisotopeFacility
    {
        private readonly IsotopeNameProvider _isotopeNameProvider;
        private readonly AnonymousNameProvider _anonymousNameProvider;
        private string? _id;
        private string? _anonymizedId;

        public IList<RadioisotopeFloor> Floors { get; }
        private int ItemCount => Floors.Sum(o => o.Items.Count);
        private int TopFloorItemCount => Floors.Last().Items.Count;
        public bool IsDone => TopFloorItemCount == ItemCount;
        public int IterationCount { get; }
        public int ElevatorFloor { get; }
        private bool CanMoveUp => ElevatorFloor < 3;
        private bool CanMoveDown => ElevatorFloor > 0;
        public bool ShouldMoveUp => CanMoveUp;
        public bool ShouldMoveDown => CanMoveDown && NeedToMoveDown;
        public bool IsValid => Floors.All(o => o.IsValid);
        private string FloorIds => string.Join('|', Floors.Select(o => o.Id));

        public RadioisotopeFacility(
            IList<RadioisotopeFloor> floors,
            int elevatorFloor,
            IsotopeNameProvider isotopeNameProvider,
            AnonymousNameProvider anonymousNameProvider)
            : this(floors, elevatorFloor, 0, isotopeNameProvider, anonymousNameProvider)
        {
        }

        public RadioisotopeFacility(
            RadioisotopeFacility facility,
            int elevatorFloor,
            IsotopeNameProvider isotopeNameProvider,
            AnonymousNameProvider anonymousNameProvider)
            : this(CopyFloors(facility), elevatorFloor, facility.IterationCount + 1, isotopeNameProvider, anonymousNameProvider)
        {
        }

        private RadioisotopeFacility(
            IList<RadioisotopeFloor> floors,
            int elevatorFloor,
            int iterationCount,
            IsotopeNameProvider isotopeNameProvider,
            AnonymousNameProvider anonymousNameProvider)
        {
            _isotopeNameProvider = isotopeNameProvider;
            _anonymousNameProvider = anonymousNameProvider;
            Floors = floors;
            IterationCount = iterationCount;
            ElevatorFloor = elevatorFloor;
        }

        private static IList<RadioisotopeFloor> CopyFloors(RadioisotopeFacility facility) =>
            facility.Floors.Select(CopyFloor).ToList();

        private static RadioisotopeFloor CopyFloor(RadioisotopeFloor floor) =>
            new(floor.Items.Select(o => o).ToList());

        private bool NeedToMoveDown
        {
            get
            {
                for (var i = 0; i < ElevatorFloor; i++)
                {
                    if (Floors[i].Items.Any())
                        return true;
                }

                return false;
            }
        }

        public string Id
        {
            get
            {
                if (_id != null)
                    return _id;

                _id = $"{ElevatorFloor}:{FloorIds}";
                return _id;
            }
        }

        public string AnonymizedId
        {
            get
            {
                if (_anonymizedId != null)
                    return _anonymizedId;

                _anonymizedId = Id;
                var counter = 1;
                var i = _anonymizedId.IndexOf('G');

                while (i > -1)
                {
                    var n = _anonymizedId[i - 1];

                    _anonymizedId = _anonymizedId
                        .Replace(_isotopeNameProvider.GetGeneratorName(n), _anonymousNameProvider.GetGeneratorName(counter))
                        .Replace(_isotopeNameProvider.GetMicrochipName(n), _anonymousNameProvider.GetMicrochipName(counter));
                    counter++;
                    i = _anonymizedId.IndexOf('G');
                }

                return _anonymizedId;
            }
        }
    }
    
    public class RadioisotopeFloor(IList<RadioisotopeItem> items)
    {
        public IList<RadioisotopeItem> Items { get; } = items;
        public string Id => string.Join(null, Items.Select(o => o.Id).OrderBy(o => o));

        public bool IsValid
        {
            get
            {
                var microchips = Items.Where(o => o.Type == RadioisotopeType.Microchip).ToList();
                var generators = Items.Where(o => o.Type == RadioisotopeType.Generator).ToList();
                return !generators.Any() || microchips.All(microchip => generators.Any(o => o.Name == microchip.Name));
            }
        }
    }
    
    public abstract class RadioisotopeItem
    {
        public string Name { get; }
        public RadioisotopeType Type { get; }
        public string Id { get; }

        protected RadioisotopeItem(string name, RadioisotopeType type)
        {
            Name = name;
            Type = type;
            Id = BuildId();
        }
    
        private string BuildId()
        {
            var n = Name.ToUpper().First();
            var t = Type.ToString().ToUpper().First();
            return string.Concat(n, t);
        }
    }

    public class RadioisotopeSimulator
    {
        private readonly HashSet<string> _previousFacilities = [];
        private readonly IsotopeNameProvider _isotopeNameProvider = new();
        private readonly AnonymousNameProvider _anonymousNameProvider = new();

        public int StepCount { get; }

        public RadioisotopeSimulator(string input)
        {
            var facility = ParseFacility(input);
            TrackVisit(facility);
            var finishedFacility = FindFinishedFacility(new List<RadioisotopeFacility> { facility });
            StepCount = finishedFacility?.IterationCount ?? 0;
        }

        private RadioisotopeFacility? FindFinishedFacility(IEnumerable<RadioisotopeFacility> facilities)
        {
            var newFacilities = new List<RadioisotopeFacility>();
            foreach (var facility in facilities)
            {
                if (facility.ShouldMoveUp)
                {
                    var itemCombinations = CombinationGenerator.GetUniqueCombinationsMaxSize(facility.Floors[facility.ElevatorFloor].Items, 2);
                    var oldFloor = facility.ElevatorFloor;
                    var newFloor = oldFloor + 1;
                    foreach (var combination in itemCombinations)
                    {
                        var f = new RadioisotopeFacility(facility, newFloor, _isotopeNameProvider, _anonymousNameProvider);
                        foreach (var item in combination)
                        {
                            f.Floors[oldFloor].Items.Remove(item);
                            f.Floors[newFloor].Items.Add(item);
                        }

                        if (AlreadyVisited(f))
                            continue;

                        TrackVisit(f);
                        if (f.IsValid)
                            newFacilities.Add(f);
                    }
                }

                if (facility.ShouldMoveDown)
                {
                    var oldFloor = facility.ElevatorFloor;
                    var newFloor = oldFloor - 1;

                    foreach (var item in facility.Floors[facility.ElevatorFloor].Items)
                    {
                        var f = new RadioisotopeFacility(facility, newFloor, _isotopeNameProvider, _anonymousNameProvider);
                        f.Floors[oldFloor].Items.Remove(item);
                        f.Floors[newFloor].Items.Add(item);

                        if (AlreadyVisited(f))
                            continue;

                        TrackVisit(f);
                        if (f.IsValid)
                            newFacilities.Add(f);
                    }
                }
            }

            if (!newFacilities.Any())
                return null;

            var finishedFacility = newFacilities.FirstOrDefault(o => o.IsDone);
            return finishedFacility ?? FindFinishedFacility(newFacilities);
        }

        private bool AlreadyVisited(RadioisotopeFacility f) => _previousFacilities.Contains(f.AnonymizedId);
        private void TrackVisit(RadioisotopeFacility f) => _previousFacilities.Add(f.AnonymizedId);

        private RadioisotopeFacility ParseFacility(string input) => new(
            input.Split(LineBreaks.Single).Select(ParseFloor).ToList(), 0, _isotopeNameProvider, _anonymousNameProvider);

        private static RadioisotopeFloor ParseFloor(string s)
        {
            var parts = s.Replace(" microchip", "-microchip").Replace(" generator", "-generator").Replace(",", "").Replace(".", "").Split(" ");
            var items = parts
                .Where(o => o.EndsWith("microchip") || o.EndsWith("generator"))
                .Select(CreateItem)
                .ToList();
            return new RadioisotopeFloor(items);
        }

        private static RadioisotopeItem CreateItem(string s, int index)
        {
            var parts = s.Split('-');
            var name = parts.First();
            var type = parts.Last();
            if (type == "microchip")
                return new Microchip(name);
            return new Generator(name);
        }
    }

    public enum RadioisotopeType
    {
        Microchip,
        Generator
    }
}