namespace Mojito.Random;

public static class Number
{
    private static readonly System.Random Rnd = new();

    /// <summary>
    /// Get random numbers within a specified range (pseudo-random in cryptography terms)
    /// </summary>
    /// <param name="minValue">Min value</param>
    /// <param name="maxValue">Max value</param>
    /// <returns>Returns -1 on failure</returns>
    public static int Create(int minValue, int maxValue)
    {
        if (minValue < 0 || maxValue < 0)
            return -1;
        if (minValue > maxValue)
            return -1;

        return Rnd.Next(minValue, maxValue);
    }
}
