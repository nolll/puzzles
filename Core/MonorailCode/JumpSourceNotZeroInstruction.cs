namespace Core.MonorailCode
{
    public class JumpSourceNotZeroInstruction : MonorailInstruction
    {
        private readonly MonorailControl _control;
        private readonly char _source;
        private readonly int _steps;

        public JumpSourceNotZeroInstruction(MonorailControl control, char source, int steps)
        {
            _control = control;
            _source = source;
            _steps = steps;
        }

        public override void Execute()
        {
            _control.JumpSourceNotZero(_source, _steps);
        }
    }
}