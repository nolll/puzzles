using Core.Tools;

namespace Core.AirDuct
{
    public class AirDuctDoor
    {
        public char Id { get; }
        public MatrixAddress Address { get; }

        public AirDuctDoor(char id, MatrixAddress address)
        {
            Id = id;
            Address = address;
        }
    }
}