using Core.Tools;

namespace ConsoleApp.Puzzles.Year2019.Puzzles.Day18
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