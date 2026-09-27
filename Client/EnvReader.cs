namespace Pzl.Client;

public static class EnvReader
{
    public static void Read()
    {
        var envPath = Path.Combine(AppContext.BaseDirectory, ".env");
        if (!File.Exists(envPath))
            return;
        
        foreach (var line in File.ReadAllLines(envPath))
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith('#'))
                continue;

            var parts = line.Split('=', 2);
            if (parts.Length == 2)
            {
                Environment.SetEnvironmentVariable(parts[0].Trim(), parts[1].Trim());
            }
        }
    }

}