using System;

namespace TrackUp;

public class TrackItUp
{
    private readonly string _name;
    private readonly Action<string> _logWriter;
    private readonly bool _fallbackToConsole;
    private int _counter = 0;

    public TrackItUp(string trackName, Action<string>? logWriter = null, bool fallbackToConsole = true)
    {
        _name = trackName;
        _logWriter = logWriter?? Console.WriteLine;
        _fallbackToConsole = fallbackToConsole;
    }

    public void Track()
    {
        var message = $"Tracking {_name} {++_counter}th times";
        try
        {
            _logWriter(message);
        }
        catch
        {
            if (_fallbackToConsole)
            {
                Console.WriteLine(message);
            }
            else
            {
                throw;
            }
        }
    }
}
