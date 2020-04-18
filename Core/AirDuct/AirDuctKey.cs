using Core.Tools;

namespace Core.AirDuct
{
    public class AirDuctKey
    {
        public char Id { get; }
        public MatrixAddress Address { get; }

        public AirDuctKey(char id, MatrixAddress address)
        {
            Id = id;
            Address = address;
        }
    }
}