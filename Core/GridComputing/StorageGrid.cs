using System.Linq;
using System.Text.RegularExpressions;
using Core.Tools;

namespace Core.GridComputing
{
    public class StorageGrid
    {
        private readonly Regex _whiteSpaceRegex = new Regex("[ ]{2,}", RegexOptions.None);
        private readonly Matrix<StorageNode> _storage;

        public StorageGrid(string input)
        {
            _storage = ParseGrid(input);
        }

        public int GetViablePairCount()
        {
            var pairCount = 0;

            for (var ya = 0; ya < _storage.Height; ya++)
            {
                for (var xa = 0; xa < _storage.Width; xa++)
                {
                    for (var yb = 0; yb < _storage.Height; yb++)
                    {
                        for (var xb = 0; xb < _storage.Width; xb++)
                        {
                            if (xa != xb || ya != yb)
                            {
                                var nodeA = _storage.ReadValueAt(xa, ya);
                                var nodeB = _storage.ReadValueAt(xb, yb);
                                var nodeAHasData = nodeA.Used > 0;
                                var nodeACanFitOnNodeB = nodeA.Used <= nodeB.Avail;
                                if (nodeAHasData && nodeACanFitOnNodeB)
                                    pairCount++;
                            }
                        }
                    }
                }
            }

            return pairCount;
        }

        private Matrix<StorageNode> ParseGrid(string input)
        {
            var rows = PuzzleInputReader.Read(input);
            var dataRows = rows.Skip(2);
            var matrix = new Matrix<StorageNode>();

            foreach (var row in dataRows)
            {
                var parts = RemoveExtraSpaces(row).Split(' ');

                var nodeName = parts[0];
                var lastPartOfName = nodeName.Split('/').Last();
                var coordParts = lastPartOfName.Split('-');
                var xString = coordParts[1].Replace("x", "");
                var yString = coordParts[2].Replace("y", "");
                var x = int.Parse(xString);
                var y = int.Parse(yString);

                var sizeString = parts[1].Replace("T", "");
                var usedString = parts[2].Replace("T", "");
                var availString = parts[3].Replace("T", "");
                var size = int.Parse(sizeString);
                var used = int.Parse(usedString);
                var avail = int.Parse(availString);

                matrix.MoveTo(x, y);
                matrix.WriteValue(new StorageNode(size, used, avail));
            }

            return matrix;
        }

        private string RemoveExtraSpaces(string s)
        {
            return _whiteSpaceRegex.Replace(s, " ");
        }
    }

    public class StorageNode
    {
        public int Size { get; }
        public int Used { get; }
        public int Avail { get; }

        public StorageNode(int size, int used, int avail)
        {
            Size = size;
            Used = used;
            Avail = avail;
        }
    }
}