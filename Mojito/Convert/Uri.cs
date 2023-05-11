namespace Mojito.Convert;

public static class Uri
{
    public static string ToHost(string uri)
    {
        var result = Parse(uri);
        return result.Success ? result.GetOk().Host : "";
    }

    public static int ToPort(string uri)
    {
        var result = Parse(uri);
        return result.Success ? result.GetOk().Port : -1;
    }

    private static Result<System.Uri> Parse(string uri)
    {
        bool isTrue = System.Uri.TryCreate(uri, UriKind.Absolute, out System.Uri? uriResult);
        return
            isTrue && uriResult != null
            ? uriResult
            : new UriFormatException(nameof(uri));
    }
}
