namespace Core.MonorailCode
{
    public class DecrementInstruction : MonorailInstruction
    {
        private readonly MonorailControl _control;
        private readonly char _target;

        public DecrementInstruction(MonorailControl control, char target)
        {
            _control = control;
            _target = target;
        }

        public override void Execute()
        {
            _control.Decrement(_target);
        }
    }
}