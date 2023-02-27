using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
namespace Mojito;

public static class Cert
{
    /// <summary>
    /// Get Issuer
    /// </summary>
    /// <param name="cert" cref="X509Certificate2">Certificate object</param>
    /// <returns></returns>
    public static string GetIssuerCN(X509Certificate2 cert)
    {
        return cert.GetNameInfo(X509NameType.SimpleName, true);
    }

    /// <summary>
    /// Get Subject
    /// </summary>
    /// <param name="cert" cref="X509Certificate2">Certificate object</param>
    /// <returns></returns>
    public static string GetSubject(X509Certificate2 cert)
    {
        return cert.GetNameInfo(X509NameType.SimpleName, false);
    }

    /// <summary>
    /// Get all dns
    /// </summary>
    /// <param name="cert" cref="X509Certificate2">Certificate object</param>
    /// <returns></returns>
    public static string[] GetDNSNames(X509Certificate2 cert)
    {
        var ext = cert.Extensions["2.5.29.17"];

        if (ext is null)
            return new[] {
                cert.GetNameInfo(X509NameType.DnsName, false)
            };

        return ext.Format(true)
            .Replace("DNS Name=", "")
            .Trim()
            .Split(Environment.NewLine);
    }

    /// <summary>
    /// Parses and creates certificate objects using pem strings
    /// </summary>
    /// <param name="certPem">Certificate pem string</param>
    /// <param name="keyPem">Key pem string</param>
    /// <returns></returns>
    public static Result<X509Certificate2> Create(string certPem, string keyPem)
    {
        try
        {
            return Result<X509Certificate2>.Ok(X509Certificate2.CreateFromPem(certPem, keyPem));
        }
        catch (CryptographicException ex)
        {
            return Result<X509Certificate2>.Error(ex); ;
        }
    }
}
