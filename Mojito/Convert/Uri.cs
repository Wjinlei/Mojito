namespace Mojito.Convert;

public static class Uri
{
    public static Result<string> ToHost(string uri)
    {
        var result = Parse(uri);
        return result.Success ? result.GetOk().Host : result.GetError();
    }

    public static int ToPort(string uri)
    {
        var result = Parse(uri);
        return result.Success ? result.GetOk().Port : -1;
    }

    private static Result<System.Uri> Parse(string uri)
    {
        bool isParseed = System.Uri.TryCreate(uri, UriKind.Absolute, out System.Uri? uriResult);

        return
            isParseed && uriResult != null
            ? uriResult
            : new UriFormatException(nameof(uri));
    }
}
