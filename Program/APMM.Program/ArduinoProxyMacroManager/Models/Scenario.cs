namespace ArduinoProxyMacroManager.Models;

public class Scenario
{
    public string Port { get; set; } = "COM3";
    public string EscapeKey { get; set; } = "ESC";
    public string[] Commands { get; set; } = Array.Empty<string>();
}