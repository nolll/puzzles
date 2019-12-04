namespace Console.Inputs
{
    public static class InputData
    {
        public static int PasswordLowerbound { get; }
        public static int PasswordUpperbound { get; }

        public static string WirePathA { get; }
        public static string WirePathB { get; }

        public static string IntCodeMemory { get; }

        public static string ModulesMasses { get; }

        static InputData()
        {
            var passwordBounds = InputStrings.PasswordBounds.Split('-');
            PasswordLowerbound = int.Parse(passwordBounds[0]);
            PasswordUpperbound = int.Parse(passwordBounds[1]);

            var wirePaths = InputStrings.WirePaths.Split('\n');
            WirePathA = wirePaths[0].Trim();
            WirePathB = wirePaths[1].Trim();

            IntCodeMemory = InputStrings.IntCodeMemory;

            ModulesMasses = InputStrings.ModulesMasses;
        }
    }
}