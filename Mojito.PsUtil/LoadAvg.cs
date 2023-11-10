using System.Diagnostics;

namespace Mojito.PsUtil;

public static class LoadAvg
{
    // We use an exponentially weighted moving average, just like Unix systems do
    // https://en.wikipedia.org/wiki/Load_(computing)#Unix-style_load_calculation
    //
    // These constants serve as the damping factor and are calculated with
    // 1 / exp(sampling interval in seconds / window size in seconds)
    //
    // This formula comes from linux's include/linux/sched/loadavg.h
    // https://github.com/torvalds/linux/blob/345671ea0f9258f410eb057b9ced9cefbbe5dc78/include/linux/sched/loadavg.h#L20-L23
    private const double LoadAvgFactor01 = 0.9200444146293232478931553241;
    private const double LoadAvgFactor05 = 0.9834714538216174894737477501;
    private const double LoadAvgFactor15 = 0.9944598480048967508795473394;

    // The time interval in seconds between taking load counts, same as Unix.
    private const int SamplingInterval = 5;

    private static double loadAvg01m = 0;
    private static double loadAvg05m = 0;
    private static double loadAvg15m = 0;

    public static double LoadAvg01m { get => loadAvg01m; set => loadAvg01m = value; }
    public static double LoadAvg05m { get => loadAvg05m; set => loadAvg05m = value; }
    public static double LoadAvg15m { get => loadAvg15m; set => loadAvg15m = value; }

    private static readonly PlatformID platform = Environment.OSVersion.Platform;
    private static readonly PerformanceCounter? counter;
#pragma warning disable IDE0052 // Windows
    private static readonly Timer? timer;
#pragma warning restore IDE0052 // Windows


    static LoadAvg()
    {
        if (platform == PlatformID.Win32NT)
        {
#pragma warning disable CA1416 // Windows
            counter = new PerformanceCounter("System", "Processor Queue Length");
#pragma warning restore CA1416 // Windows
            timer = new Timer(_ => LoadAvgCallbackForWindows(counter), null, 0, SamplingInterval * 1000);
        }
    }

    private static void LoadAvgCallbackForWindows(PerformanceCounter counter)
    {
#pragma warning disable CA1416 // Windows
        var currentLoad = counter.NextValue();
#pragma warning restore CA1416 // Windows
        LoadAvg01m = LoadAvg01m * LoadAvgFactor01 + currentLoad * (1.0 - LoadAvgFactor01);
        LoadAvg05m = LoadAvg05m * LoadAvgFactor05 + currentLoad * (1.0 - LoadAvgFactor05);
        LoadAvg15m = LoadAvg15m * LoadAvgFactor15 + currentLoad * (1.0 - LoadAvgFactor15);
    }
}
