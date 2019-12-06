namespace ConsoleApp.Inputs
{
    public static class InputData
    {
        public static string IntCodeMemoryDay5 { get; }

        public static int PasswordLowerbound { get; }
        public static int PasswordUpperbound { get; }

        public static string WirePathA { get; }
        public static string WirePathB { get; }

        public static string IntCodeMemoryDay2 { get; }

        public static string ModulesMasses { get; }

        static InputData()
        {
            IntCodeMemoryDay5 = InputStrings.IntCodeMemoryDay5;

            var passwordBounds = InputStrings.PasswordBounds.Split('-');
            PasswordLowerbound = int.Parse(passwordBounds[0]);
            PasswordUpperbound = int.Parse(passwordBounds[1]);

            var wirePaths = InputStrings.WirePaths.Split('\n');
            WirePathA = wirePaths[0].Trim();
            WirePathB = wirePaths[1].Trim();

            IntCodeMemoryDay2 = InputStrings.IntCodeMemoryDay2;

            ModulesMasses = InputStrings.ModulesMasses;
        }
    }
}