using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201604;

public class RoomValidator
{
    private readonly IList<Room> _rooms;
    private IList<Room> ValidRooms => _rooms.Where(o => o.IsValid).ToList();
    public int NorthpoleObjectStorageId => ValidRooms.First(o => o.Name == "northpole object storage").Id;

    public RoomValidator(string input) => 
        _rooms = input.Trim().Split(LineBreaks.Single).Select(o => new Room(o.Trim())).ToList();

    public int SumOfIds => ValidRooms.Sum(o => o.Id);
}