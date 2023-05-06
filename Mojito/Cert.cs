using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace Mojito;

public class Cert
{
    public X509Certificate2 _cert;

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
            _cert = X509Certificate2.CreateFromPem(certPem, keyPem);
        }
        catch (CryptographicException)
        {
            throw;
        }
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
            return new Cert(certPem, keyPem);
        }
        catch (CryptographicException ex)
        {
            return ex;
        }
    }

    /// <summary>
    /// Get Issuer
    /// </summary>
    /// <returns></returns>
    public string GetIssuer()
    {
        return _cert.GetNameInfo(X509NameType.SimpleName, true);
    }

    /// <summary>
    /// Get Subject
    /// </summary>
    /// <returns></returns>
    public string GetSubject()
    {
        return _cert.GetNameInfo(X509NameType.SimpleName, false);
    }

    /// <summary>
    /// Get all dns
    /// </summary>
    /// <returns></returns>
    public string[] GetDNSNames()
    {
        var ext = _cert.Extensions["2.5.29.17"];

        if (ext is null)
            return new[] { _cert.GetNameInfo(X509NameType.DnsName, false) };

        return ext.Format(true).Replace("DNS Name=", "").Trim().Split(Environment.NewLine);
    }

    public static bool operator ==(Cert left, Cert right)
    {
        return left.GetSubject() == right.GetSubject();
    }

    public static bool operator !=(Cert left, Cert right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is Cert cert && this == cert;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetSubject());
    }
}
