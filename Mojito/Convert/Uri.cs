namespace Mojito.Convert;

public static class Uri
{
    public static Result<string> ToHost(string uri)
    {
        bool isValidUrl = System.Uri.TryCreate(uri, UriKind.Absolute, out System.Uri? uriResult);
        return isValidUrl && uriResult != null
            ? uriResult.Host
            : new UriFormatException(nameof(uri));
    }
}
