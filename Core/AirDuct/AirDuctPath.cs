using System.Collections.Generic;
using Core.Tools;

namespace Core.AirDuct
{
    public class AirDuctPath
    {
        public int StepCount { get; }
        public AirDuctLocation Target { get; }
        public IList<MatrixAddress> Coords { get; }

        public AirDuctPath(AirDuctLocation target, IList<MatrixAddress> coords)
        {
            Target = target;
            Coords = coords;
            StepCount = coords.Count;
        }
    }
}