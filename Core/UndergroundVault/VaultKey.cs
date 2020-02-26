using Core.Tools;

namespace Core.UndergroundVault
{
    public class VaultKey
    {
        public char Id { get; }
        public MatrixAddress Address { get; }

        public VaultKey(char id, MatrixAddress address)
        {
            Id = id;
            Address = address;
        }
    }
}