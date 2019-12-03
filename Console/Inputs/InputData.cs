namespace Console.Inputs
{
    public static class InputData
    {
        public static string WirePathA { get; }
        public static string WirePathB { get; }

        public static string IntCodeMemory { get; }

        public static string ModulesMasses { get; }

        static InputData()
        {
            var wirePaths = InputStrings.WirePaths.Split('\n');
            WirePathA = wirePaths[0].Trim();
            WirePathB = wirePaths[1].Trim();

            IntCodeMemory = InputStrings.IntCodeMemory;

            ModulesMasses = InputStrings.ModulesMasses;
        }
    }
}