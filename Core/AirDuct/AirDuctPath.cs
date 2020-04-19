using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.AirDuct
{
    public class AirDuctPath
    {
        private readonly IList<char> _keysNeeded;
        
        public int StepCount { get; }
        public AirDuctKey Target { get; }
        public IList<MatrixAddress> Coords { get; }

        public AirDuctPath(AirDuctKey target, IList<MatrixAddress> coords)
        {
            Target = target;
            Coords = coords;
            StepCount = coords.Count;
        }

        public bool IsOpen(IList<AirDuctKey> collectedKeys)
        {
            return _keysNeeded.All(key => collectedKeys.Any(o => o.Id == key));
        }
    }
}