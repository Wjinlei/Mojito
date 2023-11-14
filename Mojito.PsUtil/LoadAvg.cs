using System.Diagnostics;
using System.Runtime.InteropServices;

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
    private const double loadAvgFactor01 = 0.9200444146293232478931553241;
    private const double loadAvgFactor05 = 0.9834714538216174894737477501;
    private const double loadAvgFactor15 = 0.9944598480048967508795473394;

    // The time interval in seconds between taking load counts, same as Unix.
    private const int samplingInterval = 5;

    public static double LoadAvg01m { get; set; } = 0;
    public static double LoadAvg05m { get; set; } = 0;
    public static double LoadAvg15m { get; set; } = 0;

    static LoadAvg()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            var counter = new PerformanceCounter("System", "Processor Queue Length");
            _ = new Timer(_ => Callback(counter), null, 0, samplingInterval * 1000);
        }
    }

    private static void Callback(PerformanceCounter counter)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            var currentLoad = counter.NextValue();
            LoadAvg01m = LoadAvg01m * loadAvgFactor01 + currentLoad * (1.0 - loadAvgFactor01);
            LoadAvg05m = LoadAvg05m * loadAvgFactor05 + currentLoad * (1.0 - loadAvgFactor05);
            LoadAvg15m = LoadAvg15m * loadAvgFactor15 + currentLoad * (1.0 - loadAvgFactor15);
        }
    }
}
