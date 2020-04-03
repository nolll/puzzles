using System.Linq;
using Core.Tools;

namespace Core.ModeMaze
{
    public class CaveSystem
    {
        private readonly long _depth;
        private Matrix<CaveRegion> _cave;
        private MatrixAddress _mouth;
        private MatrixAddress _target;

        public long TotalRiskLevel { get; }

        public CaveSystem(in long depth, in int targetX, in int targetY)
        {
            _depth = depth;
            _mouth = new MatrixAddress(0, 0);
            _target = new MatrixAddress(targetX, targetY);
            BuildCave(_target);
            TotalRiskLevel = _cave.Values.Sum(o => o.RiskLevel);
        }

        private void BuildCave(MatrixAddress target)
        {
            _cave = new Matrix<CaveRegion>();

            for (var y = 0; y <= target.Y; y++)
            {
                for (var x = 0; x <= target.X; x++)
                {
                    _cave.MoveTo(x, y);
                    var region = _cave.ReadValue() ?? new CaveRegion();
                    region.GeologicIndex = GetGeologicIndex(_cave.Address);
                    region.ErosionLevel = GetErosionLevel(region.GeologicIndex);
                    region.RiskLevel = GetRiskLevel(region.ErosionLevel);
                    region.Type = GetRegionType(region.RiskLevel);
                    _cave.WriteValue(region);
                }
            }
        }

        private long GetGeologicIndex(MatrixAddress address)
        {
            if (address.Equals(_mouth) || address.Equals(_target))
                return 0;

            if (address.Y == 0)
                return address.X * 16807;

            if (address.X == 0)
                return address.Y * 48271;

            var a = _cave.ReadValueAt(address.X - 1, address.Y);
            var b = _cave.ReadValueAt(address.X, address.Y - 1);

            return a.ErosionLevel * b.ErosionLevel;
        }

        private long GetErosionLevel(long geologicIndex)
        {
            return (geologicIndex + _depth) % 20183;
        }

        private long GetRiskLevel(long erosionLevel)
        {
            return erosionLevel % 3;
        }

        private CaveRegionType GetRegionType(long riskLevel)
        {
            return (CaveRegionType) riskLevel;
        }
    }
}