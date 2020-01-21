namespace Core.MonorailCode
{
    public class IncrementInstruction : MonorailInstruction
    {
        private readonly MonorailControl _control;
        private readonly char _target;

        public IncrementInstruction(MonorailControl control, char target)
        {
            _control = control;
            _target = target;
        }

        public override void Execute()
        {
            _control.Increment(_target);
        }
    }
}