namespace ArduinoProxyMacroManager.Utils;
static class ProgramCommandHelper
{
    public static bool IsEscapeKey(ConsoleKeyInfo keyInfo, string escapeKey)
    {
        if (string.IsNullOrWhiteSpace(escapeKey)) return false;

        escapeKey = escapeKey.Trim().ToUpper();

        if (escapeKey == "ESC" && keyInfo.Key == ConsoleKey.Escape)
            return true;

        if (escapeKey.Length == 1 &&
            char.ToUpperInvariant(keyInfo.KeyChar) == escapeKey[0])
            return true;

        return false;
    }
};
