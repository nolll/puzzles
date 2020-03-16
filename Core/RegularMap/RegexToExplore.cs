using Core.Tools;

namespace Core.RegularMap
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