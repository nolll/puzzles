namespace Data.Inputs
{
    public static class InputData
    {
        public static string ComputerProgramDay11 { get; }

        public static string Asteroids { get; }

        public static string ComputerProgramDay9 { get; }

        public static string ImageData { get; }

        public static string ComputerProgramDay7 { get; }

        public static string ComputerProgramDay5 { get; }

        public static int PasswordLowerbound { get; }
        public static int PasswordUpperbound { get; }

        public static string WirePathA { get; }
        public static string WirePathB { get; }

        public static string ComputerProgramDay2 { get; }

        public static string ModulesMasses { get; }

        public static string BoxIds { get; }

        public static string FrequencyChanges { get; }

        static InputData()
        {
            ComputerProgramDay11 = InputStrings.ComputerProgramDay11;

            Asteroids = InputStrings.Asteroids;

            ComputerProgramDay9 = InputStrings.ComputerProgramDay9;

            ImageData = InputStrings.ImageData;

            ComputerProgramDay7 = InputStrings.ComputerProgramDay7;

            ComputerProgramDay5 = InputStrings.ComputerProgramDay5;

            var passwordBounds = InputStrings.PasswordBounds.Split('-');
            PasswordLowerbound = int.Parse(passwordBounds[0]);
            PasswordUpperbound = int.Parse(passwordBounds[1]);

            var wirePaths = InputStrings.WirePaths.Split('\n');
            WirePathA = wirePaths[0].Trim();
            WirePathB = wirePaths[1].Trim();

            ComputerProgramDay2 = InputStrings.ComputerProgramDay2;

            ModulesMasses = InputStrings.ModulesMasses;

            FrequencyChanges = InputStrings.FrequencyChanges;
        }
    }
}