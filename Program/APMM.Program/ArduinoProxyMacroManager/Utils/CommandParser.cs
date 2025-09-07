namespace ArduinoProxyMacroManager.Utils;
public static class CommandParser
{
    private static readonly Random _rnd = new();

    public static (string finalCmd, int extraDelay) Prepare(string cmd)
    {
        cmd = cmd.Trim();

        if (cmd.StartsWith("RANDOM", StringComparison.OrdinalIgnoreCase))
        {
            var parts = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2 && parts[1].Contains('-'))
            {
                var range = parts[1].Split('-');
                if (int.TryParse(range[0], out int min) &&
                    int.TryParse(range[1], out int max))
                {
                    int value = _rnd.Next(min, max + 1);
                    return ($"DELAY {value}", value);
                }
            }
        }
        else if (cmd.StartsWith("DELAY", StringComparison.OrdinalIgnoreCase))
        {
            var parts = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2 && int.TryParse(parts[1], out int ms))
            {
                return ($"DELAY {ms}", ms);
            }
        }

        return (cmd, 0);
    }
}
