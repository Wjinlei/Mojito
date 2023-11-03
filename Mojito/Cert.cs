using System.Security.Cryptography.X509Certificates;

namespace Mojito;

public class Cert
{
    public X509Certificate2 _cert;

    /// <summary>
    /// Instantiate an Cert object
    /// </summary>
    /// <param name="certPem">Certificate pem string</param>
    /// <param name="keyPem">Key pem string</param>
    public Cert(string certPem, string keyPem)
    {
        _cert = X509Certificate2.CreateFromPem(certPem, keyPem);
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
    public string[] GetBinds()
    {
        var ext = _cert.Extensions["2.5.29.17"];
        if (ext is null)
            return new[] { _cert.GetNameInfo(X509NameType.DnsName, false) };

        return ext.Format(true).Replace("DNS Name=", "")
            .Trim().Split(Environment.NewLine);
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
