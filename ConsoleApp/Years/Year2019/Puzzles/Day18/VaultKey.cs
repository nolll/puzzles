using Core.Tools;

namespace ConsoleApp.Years.Year2019.Puzzles.Day18
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