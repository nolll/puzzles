using System.Collections.Generic;
using System.Linq;

namespace Core.Puzzles.Year2016.Day11;

public class RadioisotopeFacility
{
    public IList<RadioisotopeFloor> Floors { get; }
    public int ItemCount => Floors.Sum(o => o.Items.Count);
    public int TopFloorItemCount => Floors.Last().Items.Count;
    public bool IsDone => TopFloorItemCount == ItemCount;
    public int IterationCount { get; }
    public int ElevatorFloor { get; }
    public bool CanMoveUp => ElevatorFloor < 3;
    public bool CanMoveDown => ElevatorFloor > 0;
    public bool ShouldMoveUp => CanMoveUp;
    public bool ShouldMoveDown => CanMoveDown && NeedToMoveDown;
    public bool IsValid => Floors.All(o => o.IsValid);
    public string Id => $"{ElevatorFloor}:{FloorIds}";
    private string FloorIds => string.Join('|', Floors.Select(o => o.Id));

    public RadioisotopeFacility(List<RadioisotopeFloor> floors, int elevatorFloor)
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

            floors.Add(new RadioisotopeFloor(items));
        }

        return floors;
    }

    public bool NeedToMoveDown
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

    public string AnonymizedId
    {
        get
        {
            var id = Id;
            var counter = 1;
            while (id.Contains('G'))
            {
                var gPos = id.IndexOf('G');
                var n = id[gPos - 1];
                var generatorId = string.Concat(n, 'G');
                var newGeneratorId = string.Concat(counter, 'X');
                id = id.Replace(generatorId, newGeneratorId);
                var microchipId = string.Concat(n, 'M');
                var newMicrochipId = string.Concat(counter, 'Y');
                id = id.Replace(microchipId, newMicrochipId);
                counter++;
            }

            return id;
        }
    }
}