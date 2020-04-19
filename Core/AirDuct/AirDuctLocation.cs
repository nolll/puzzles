using Core.Tools;

namespace Core.AirDuct
{
    public class AirDuctLocation
    {
        public char Id { get; }
        public MatrixAddress Address { get; }

        public AirDuctLocation(char id, MatrixAddress address)
        {
            Id = id;
            Address = address;
        }
    }
}