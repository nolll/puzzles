using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Puzzles.Year2016.Day11;

public class RadioisotopeFacility
{
    private string _id;
    private string _anonymizedId;

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

    public RadioisotopeFacility(IList<RadioisotopeFloor> floors, int elevatorFloor)
    {
        Floors = floors;
        IterationCount = 0;
        ElevatorFloor = elevatorFloor;
    }

    public RadioisotopeFacility(RadioisotopeFacility facility, int elevatorFloor)
    {
        Floors = CopyFloors(facility);
        IterationCount = facility.IterationCount + 1;
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

    public string AnonymizedAnonymizedId
    {
        get
        {
            if (_anonymizedId != null)
                return _anonymizedId;

            _anonymizedId = Id;
            var counter = 1;
            while (_anonymizedId.Contains('G'))
            {
                var n = _anonymizedId[_anonymizedId.IndexOf('G') - 1];
                _anonymizedId = _anonymizedId.Replace(string.Concat(n, 'G'), string.Concat(counter, 'X'))
                    .Replace(string.Concat(n, 'M'), string.Concat(counter, 'Y'));
                counter++;
            }

            return _anonymizedId;
        }
    }
}