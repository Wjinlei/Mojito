using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
namespace Mojito;

public class Cert
{
    public X509Certificate2 Original { get; set; }

    /// <summary>
    /// Instantiate an Cert object
    /// </summary>
    /// <param name="certPem">Certificate pem string</param>
    /// <param name="keyPem">Key pem string</param>
    /// <exception cref="CryptographicException"></exception>
    private Cert(string certPem, string keyPem)
    {
        try
        {
            Original = X509Certificate2.CreateFromPem(certPem, keyPem);
        }
        catch (CryptographicException)
        {
            throw;
        }
    }

    /// <summary>
    /// Get Issuer
    /// </summary>
    /// <returns></returns>
    public string IssuerCN()
    {
        return Original.GetNameInfo(X509NameType.SimpleName, true);
    }

    /// <summary>
    /// Get Subject
    /// </summary>
    /// <returns></returns>
    public string Subject()
    {
        return Original.GetNameInfo(X509NameType.SimpleName, false);
    }

    /// <summary>
    /// Get all dns
    /// </summary>
    /// <returns></returns>
    public string[] DNSNames()
    {
        var ext = Original.Extensions["2.5.29.17"];

        if (ext is null)
            return new[] {
                Original.GetNameInfo(X509NameType.DnsName, false)
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
    public static Result<Cert> Create(string certPem, string keyPem)
    {
        try
        {
            return Result<Cert>.Ok(new Cert(certPem, keyPem));
        }
        catch (CryptographicException ex)
        {
            return Result<Cert>.Error(ex); ;
        }
    }
}
