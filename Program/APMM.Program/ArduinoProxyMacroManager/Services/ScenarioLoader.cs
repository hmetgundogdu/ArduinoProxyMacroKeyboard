using System.Text.Json;
using ArduinoProxyMacroManager.Models;

namespace ArduinoProxyMacroManager.Services;
public static class ScenarioLoader
{
    public static Scenario Load(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"Scenario file not found: {path}");

        var json = File.ReadAllText(path);
        var scenario = JsonSerializer.Deserialize<Scenario>(json);

        if(scenario is null)
        {
            throw new JsonException("Scenario file not parsed");
        }

        return scenario;
    }
};
