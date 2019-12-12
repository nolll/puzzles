using System.Linq;
using Core.Tools;

namespace Core.Boxes
{
    public class BoxChecksumPuzzle
    {
        public int Checksum { get; }

        public BoxChecksumPuzzle(string input)
        {
            var ids = StringListReader.Read(input);
            var idCharacteristics = ids.Select(o => new IdCharacteristics(o.Trim())).ToList();
            var doubleCount = idCharacteristics.Count(o => o.HasDoubleChars);
            var tripleCount = idCharacteristics.Count(o => o.HasTripleChars);
            Checksum = doubleCount * tripleCount;
        }
    }
}