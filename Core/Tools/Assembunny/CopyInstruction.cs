namespace Core.Tools.Assembunny
{
    public class CopyInstruction : AssembunnyInstruction
    {
        private readonly AssembunnyComputer _control;
        private readonly char _source;
        private readonly char _target;

        public CopyInstruction(AssembunnyComputer control, char source, char target)
        {
            _control = control;
            _source = source;
            _target = target;
        }

        public override void Execute()
        {
            _control.CopyValue(_source, _target);
        }

        public override AssembunnyInstructionType Type => AssembunnyInstructionType.TwoArguments;
        public override string Name { get; };
    }
}