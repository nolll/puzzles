namespace Console.Inputs
{
    public static class InputData
    {
        public static string WirePathA { get; }
        public static string WirePathB { get; }

        static InputData()
        {
            var wirePaths = InputStrings.WirePaths.Split('\n');
            WirePathA = wirePaths[0].Trim();
            WirePathB = wirePaths[1].Trim();
        }
    }
}