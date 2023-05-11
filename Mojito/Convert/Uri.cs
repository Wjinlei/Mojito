namespace Mojito.Convert;

public static class Uri
{
    private static Result<System.Uri> Parse(string uri)
    {
        bool isTrue = System.Uri.TryCreate(
            uri,
            UriKind.Absolute,
            out System.Uri? uriResult);

        return isTrue && uriResult != null
            ? uriResult
            : new UriFormatException(nameof(uri));
    }

    public static Result<string> ToHost(string uri)
    {
        var result = Parse(uri);
        return result.Success ? result.GetOk().Host : result.GetError();
    }

    public static Result<string> ToPort(string uri)
    {
        var result = Parse(uri);
        return result.Success
            ? result.GetOk().Port.ToString()
            : result.GetError();
    }
}
