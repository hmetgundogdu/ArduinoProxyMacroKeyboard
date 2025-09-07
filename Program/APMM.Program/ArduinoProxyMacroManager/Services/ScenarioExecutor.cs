using ArduinoProxyMacroManager.Utils;

namespace ArduinoProxyMacroManager.Services;
public class ScenarioExecutor
{
    private readonly ArduinoPort _arduino;
    private CancellationTokenSource? _cts;
    private bool _running = false;

    public ScenarioExecutor(ArduinoPort arduino)
    {
        _arduino = arduino;
    }

    public bool IsRunning => _running;

    public void Start(IEnumerable<string> commands)
    {
        if (_running) return;

        _cts = new CancellationTokenSource();
        _running = true;

        Task.Run(async () =>
        {
            Console.WriteLine("Scenario started.");
            while (!_cts!.IsCancellationRequested)
            {
                foreach (var cmd in commands)
                {
                    if (_cts.IsCancellationRequested) break;

                    var (finalCmd, extraDelay) = CommandParser.Prepare(cmd);

                    _arduino.Send(finalCmd);
                    Console.WriteLine($"> {finalCmd}");

                    if (extraDelay > 0)
                        await Task.Delay(extraDelay);
                    else
                        await Task.Delay(100);
                }
            }
            _running = false;
            Console.WriteLine("Scenario stoped.");
        }, _cts.Token);
    }

    public void Stop()
    {
        if (!_running) return;
        _cts?.Cancel();
        _running = false;
    }
}

