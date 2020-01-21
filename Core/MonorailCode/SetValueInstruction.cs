namespace Core.MonorailCode
{
    public class SetValueInstruction : MonorailInstruction
    {
        private readonly MonorailControl _control;
        private readonly int _value;
        private readonly char _target;

        public SetValueInstruction(MonorailControl control, int value, char target)
        {
            _control = control;
            _value = value;
            _target = target;
        }

        public override void Execute()
        {
            _control.SetValue(_value, _target);
        }
    }
}