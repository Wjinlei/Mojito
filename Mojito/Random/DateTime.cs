namespace Mojito.Random;

public static class DateTime
{
    private static readonly System.Random Rnd = new();

    /// <summary>
    /// Generate a random System.DateTime object
    /// </summary>
    /// <returns></returns>
    public static System.DateTime Create()
    {
        var maxYear = System.DateTime.Now.Year < 1970 ? 1970 : System.DateTime.Now.Year;
        var maxMonth = System.DateTime.Now.Month < 1 ? 1 : System.DateTime.Now.Month;
        var maxDay = System.DateTime.Now.Day < 1 ? 1 : System.DateTime.Now.Day;

        var year = Rnd.Next(1970, maxYear);
        var month = Rnd.Next(1, maxMonth);
        var day = Rnd.Next(1, maxDay);

        var hour = Rnd.Next(0, 24);
        var minute = Rnd.Next(0, 60);
        var second = Rnd.Next(0, 60);

        return System.Convert.ToDateTime($"{year}/{month}/{day} {hour}:{minute}:{second}");
    }
}
