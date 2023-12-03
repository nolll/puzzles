namespace Puzzles.Aoc.Puzzles.Aoc2016.Aoc201611;

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

    private static IList<RadioisotopeFloor> CopyFloors(RadioisotopeFacility facility)
    {
        return facility.Floors.Select(CopyFloor).ToList();
    }

    private static RadioisotopeFloor CopyFloor(RadioisotopeFloor floor)
    {
        var items = floor.Items.Select(o => o).ToList();
        return new RadioisotopeFloor(items);
    }

    public string Print()
    {
        var strings = new List<string>();
        for (var i = Floors.Count - 1; i >= 0; i--)
        {
            var floorNumber = i + 1;
            var isElevetorOnThisFloor = i == ElevatorFloor;
            var elevator = isElevetorOnThisFloor ? 'E' : '.';
            var floor = Floors[i];
            var hg = floor.Items.Any(o => o.Id == "HG") ? "HG" : ". ";
            var hm = floor.Items.Any(o => o.Id == "HM") ? "HM" : ". ";
            var lg = floor.Items.Any(o => o.Id == "LG") ? "LG" : ". ";
            var lm = floor.Items.Any(o => o.Id == "LM") ? "LM" : ". ";
            var s = $"F{floorNumber} {elevator}  {hg} {hm} {lg} {lm}";
            strings.Add(s);
        }

        return string.Join(Environment.NewLine, strings);
    }

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