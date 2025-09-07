using ArduinoProxyMacroManager.Utils;
using ArduinoProxyMacroManager.Models;
using ArduinoProxyMacroManager.Services;

Console.WriteLine("Arduino Proxy Macro Keyboard Runner");

Scenario scenario = ScenarioLoader.Load("scenario.json");

using var arduino = new ArduinoPort(scenario.Port);

var executor = new ScenarioExecutor(arduino);

Console.WriteLine("Scenario:");

foreach (var cmd in scenario.Commands)
    Console.WriteLine("  " + cmd);

Console.WriteLine($"\n[Space] for start scenario | [{scenario.EscapeKey}] Stop & Exit");

while (true)
{
    if (Console.KeyAvailable)
    {
        var keyInfo = Console.ReadKey(true);

        if (keyInfo.Key == ConsoleKey.Spacebar && !executor.IsRunning)
        {
            executor.Start(scenario.Commands);
        }
        else if (ProgramCommandHelper.IsEscapeKey(keyInfo, scenario.EscapeKey))
        {
            executor.Stop();
            break;
        }
    }

    await Task.Delay(50);
}
