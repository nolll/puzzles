namespace Core.MonorailCode
{
    public class CopyInstruction : MonorailInstruction
    {
        private readonly MonorailControl _control;
        private readonly char _source;
        private readonly char _target;

        public CopyInstruction(MonorailControl control, char source, char target)
        {
            _control = control;
            _source = source;
            _target = target;
        }

        public override void Execute()
        {
            _control.CopyValue(_source, _target);
        }
    }
}