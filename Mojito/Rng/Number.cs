namespace Mojito.Rng;

public static class Number
{
    /// <summary>
    /// Get random numbers within a specified range (pseudo-random in cryptography terms)
    /// </summary>
    /// <param name="min">Min value</param>
    /// <param name="max">Max value</param>
    /// <returns>A random number within a specified range</returns>
    /// <exception cref="ArgumentException">min > max</exception>
    public static int Create(uint min, uint max)
    {
        var rnd = new Random();

        if (min > max)
            throw new ArgumentException("min cannot be greater than max");

        return rnd.Next((int)min, (int)max);
    }
}
