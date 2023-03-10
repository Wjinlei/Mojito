namespace Mojito;

/// <summary>
/// This Uri class resolves only the host and port fields from the Uri
/// </summary>
public class Uri
{
    public string _host = "";
    public int _port = -1;

    public string Host { get => _host; }
    public int Port { get => _port; }

    public Uri(string uriString)
    {
        uriString = uriString.Trim().Trim(':');

        // If you have a scheme part, remove it
        var scheme = "://";
        if (uriString.Contains(scheme))
            uriString = uriString[(uriString.LastIndexOf(scheme) + 3)..];

        var parts = uriString.Split(new char[] { ':', '/' });

        if (parts.Length >= 2)
            _host = parts[0];

        var index = parts.Length > 2 ? 1 : parts.Length - 1;
        if (!int.TryParse(parts[index], out _port))
            _host = parts[0];

        if (_port == 0)
            _port = -1;
    }
}
