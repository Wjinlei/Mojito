namespace Mojito.Convert;

public static class Uri
{
    /// <summary>
    /// Parse the URI string and get the Port part
    /// </summary>
    /// <param name="uri">Uri string</param>
    /// <returns></returns>
    public static Result<string> ToPort(string uri)
    {
        var result = Parse(uri);
        return result.Success ? result.GetOk().Port.ToString() : result.GetError();
    }

    /// <summary>
    /// Parse the URI string and get the Host part
    /// </summary>
    /// <param name="uri">Uri string</param>
    /// <returns></returns>
    public static Result<string> ToHost(string uri)
    {
        var result = Parse(uri);
        return result.Success ? result.GetOk().Host : result.GetError();
    }

    /// <summary>
    /// Parse URI string into a System.Uri object
    /// </summary>
    /// <param name="uri">Uri string</param>
    /// <returns></returns>
    private static Result<System.Uri> Parse(string uri)
    {
        bool isTrue = System.Uri.TryCreate(uri, UriKind.Absolute, out System.Uri? uriResult);

        return isTrue && uriResult != null
            ? uriResult : new UriFormatException(nameof(uri));
    }
}
