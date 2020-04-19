namespace Core.AirDuct
{
    public class AirDuctPath
    {
        public int StepCount { get; }
        public AirDuctLocation Target { get; }

        public AirDuctPath(AirDuctLocation target, int stepCount)
        {
            Target = target;
            StepCount = stepCount;
        }
    }
}