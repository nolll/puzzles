using System.Collections.Generic;
using System.Linq;

namespace Core.RoomValidation
{
    public class RoomValidator
    {
        private readonly IList<Room> _rooms;
        private IList<Room> ValidRooms => _rooms.Where(o => o.IsValid).ToList();
        public int NorthpoleObjectStorageId => ValidRooms.First(o => o.Name == "northpole object storage").Id;

        public RoomValidator(string input)
        {
            _rooms = input.Trim().Split('\n').Select(o => new Room(o.Trim())).ToList();
        }

        public int SumOfIds
        {
            get { return ValidRooms.Sum(o => o.Id); }
        }
    }
}