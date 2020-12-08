namespace Core.HandheldGameConsole
{
    public class GameConsoleExit
    {
        public ExitStatus Status { get; }
        public int ExitValue { get; }

        public GameConsoleExit(ExitStatus status, int exitValue)
        {
            Status = status;
            ExitValue = exitValue;
        }
    }
}