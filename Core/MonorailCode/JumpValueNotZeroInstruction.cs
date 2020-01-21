namespace Core.MonorailCode
{
    public class JumpValueNotZeroInstruction : MonorailInstruction
    {
        private readonly MonorailControl _control;
        private readonly int _value;
        private readonly int _steps;

        public JumpValueNotZeroInstruction(MonorailControl control, int value, int steps)
        {
            _control = control;
            _value = value;
            _steps = steps;
        }

        public override void Execute()
        {
            _control.JumpValueNotZero(_value, _steps);
        }
    }
}