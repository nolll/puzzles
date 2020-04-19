using Core.Tools;

namespace Core.UndergroundVault
{
    public class VaultRobot
    {
        public MatrixAddress Address { get; }

        public VaultRobot(MatrixAddress address)
        {
            Address = address;
        }
    }
}