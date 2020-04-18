using Core.Tools;

namespace Core.AirDuct
{
    public class AirDuctRobot
    {
        public MatrixAddress Address { get; }

        public AirDuctRobot(MatrixAddress address)
        {
            Address = address;
        }
    }
}