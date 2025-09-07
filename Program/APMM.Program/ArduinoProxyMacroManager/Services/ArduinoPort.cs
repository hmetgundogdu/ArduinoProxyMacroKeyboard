using System.IO.Ports;

namespace ArduinoProxyMacroManager.Services;
public class ArduinoPort : IDisposable
{
    private readonly SerialPort _port;

    public ArduinoPort(string portName, int baudRate = 9600)
    {
        _port = new SerialPort(portName, baudRate);
        _port.Open();
    }

    public void Send(string command)
    {
        if (!_port.IsOpen) return;
        _port.WriteLine(command);
    }

    public void Dispose()
    {
        if (_port.IsOpen) _port.Close();
        _port.Dispose();
    }
}
