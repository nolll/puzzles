using System.Linq;

namespace Core.RoomValidation
{
    public class RoomValidator
    {
        public int GetSumOfIds(string input)
        {
            var rooms = input.Trim().Split('\n').Select(o => new Room(o.Trim()));
            return rooms.Where(o => o.IsValid).Sum(o => o.Id);
        }
    }
}