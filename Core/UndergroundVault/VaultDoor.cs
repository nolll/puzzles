using Core.Tools;

namespace Core.UndergroundVault
{
    public class VaultDoor
    {
        public char Id { get; }
        public MatrixAddress Address { get; }

        public VaultDoor(char id, MatrixAddress address)
        {
            Id = id;
            Address = address;
        }
    }
}