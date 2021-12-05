using Core.Tools;

namespace ConsoleApp.Puzzles.Year2018.Day20
{
    public class RegexToExplore
    {
        public MatrixAddress StartAddress { get; }
        public string Path { get; }

        public RegexToExplore(MatrixAddress startAddress, string path)
        {
            StartAddress = startAddress;
            Path = path;
        }
    }
}