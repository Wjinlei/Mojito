namespace Mojito.Rng;

public static class DateTime
{
    /// <summary>
    /// Generate a random System.DateTime object
    /// </summary>
    /// <returns></returns>
    public static System.DateTime Create()
    {
        var rnd = new Random();

        var maxYear = System.DateTime.Now.Year < 1970 ? 1970 : System.DateTime.Now.Year;
        var maxMonth = System.DateTime.Now.Month < 1 ? 1 : System.DateTime.Now.Month;
        var maxDay = System.DateTime.Now.Day < 1 ? 1 : System.DateTime.Now.Day;

        var year = rnd.Next(1970, maxYear);
        var month = rnd.Next(1, maxMonth);
        var day = rnd.Next(1, maxDay);

        var hour = rnd.Next(0, 24);
        var minute = rnd.Next(0, 60);
        var second = rnd.Next(0, 60);

        return System.Convert.ToDateTime($"{year}/{month}/{day} {hour}:{minute}:{second}");
    }
}
