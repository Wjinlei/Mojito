﻿namespace TestMojito;

public class CertTest
{
    private const string PEM = @"
-----BEGIN CERTIFICATE-----
MIIFrTCCBJWgAwIBAgIQDJal+Yg6fIYXU13nGDHOGjANBgkqhkiG9w0BAQsFADBy
MQswCQYDVQQGEwJDTjElMCMGA1UEChMcVHJ1c3RBc2lhIFRlY2hub2xvZ2llcywg
SW5jLjEdMBsGA1UECxMURG9tYWluIFZhbGlkYXRlZCBTU0wxHTAbBgNVBAMTFFRy
dXN0QXNpYSBUTFMgUlNBIENBMB4XDTIwMDYxMTAwMDAwMFoXDTIxMDYxMjEyMDAw
MFowGzEZMBcGA1UEAxMQd3d3LmZ1eGlhbmxlaS5jbjCCASIwDQYJKoZIhvcNAQEB
BQADggEPADCCAQoCggEBAKZaN58fekHV97u3xVqb7fnHg7XY5qvaoqmYx6FEMby4
m/Ecx4FPJMSsI/fQ6e2Nv0mZUEiRI/JYOxO61+2kjaOQHKLFhSw9rChSg5AxuZgl
H9Zfnhm96wg+KKQq5+mZy+HKe3T5kX/r7cmdaBDMB8HZzOqpGatu9up0Fvwkc6DR
NYks7vWsD6ljdHSjzOTSEK+DVVNLgwOV5kOFLpAfxk15u/SOlKHbp9qbNIY6pwKh
p7SyqxM1lzNhyd/+0BGcrpD0BvZvUQ1v1oaxtq8VrtldWJAqdQctxeBrtXY5HWMa
wK7AvIl3cNEoxGql5r9gJFgX5fWL+lQpAXMAxtoXg/kCAwEAAaOCApQwggKQMB8G
A1UdIwQYMBaAFH/TmfOgRw4xAFZWIo63zJ7dygGKMB0GA1UdDgQWBBSHM2i00Kal
jU1bokAgKLgKKzKYAzApBgNVHREEIjAgghB3d3cuZnV4aWFubGVpLmNuggxmdXhp
YW5sZWkuY24wDgYDVR0PAQH/BAQDAgWgMB0GA1UdJQQWMBQGCCsGAQUFBwMBBggr
BgEFBQcDAjBMBgNVHSAERTBDMDcGCWCGSAGG/WwBAjAqMCgGCCsGAQUFBwIBFhxo
dHRwczovL3d3dy5kaWdpY2VydC5jb20vQ1BTMAgGBmeBDAECATCBkgYIKwYBBQUH
AQEEgYUwgYIwNAYIKwYBBQUHMAGGKGh0dHA6Ly9zdGF0dXNlLmRpZ2l0YWxjZXJ0
dmFsaWRhdGlvbi5jb20wSgYIKwYBBQUHMAKGPmh0dHA6Ly9jYWNlcnRzLmRpZ2l0
YWxjZXJ0dmFsaWRhdGlvbi5jb20vVHJ1c3RBc2lhVExTUlNBQ0EuY3J0MAkGA1Ud
EwQCMAAwggEEBgorBgEEAdZ5AgQCBIH1BIHyAPAAdgB9PvL4j/+IVWgkwsDKnlKJ
eSvFDngJfy5ql2iZfiLw1wAAAXKhgAEBAAAEAwBHMEUCIBUvHI9FOw2zHwrf0Ou5
luwh+nxpHEkHLlWlsvFdkre6AiEAgKVqRkh6AOs8dXQQRQFP66MbH7bNJi49PyfM
RJ0DGWIAdgBc3EOS/uarRUSxXprUVuYQN/vV+kfcoXOUsl7m9scOygAAAXKhgADR
AAAEAwBHMEUCIAyd5Qv4RZm8KnwyooyWwozKd3dZvCJa6yfOEk2OzxLTAiEAsHp0
rnX4xDUBfL4Gk/aVy/VNVHRuglpreCHsILt2ABYwDQYJKoZIhvcNAQELBQADggEB
AEf0Eb5DdLcAgO+V9gTryGtlkziPKp8zRdFuZZxelMpJ0I01/hF+o6X3BpypkSZY
tKrllTBoPq768JMRDmWvIzzkmfgPv58Pcl6pQ7Hg5CpT/Jvv6CTHl5mHRPvZkP/+
qxrEB/4Owo5kQ8xrTXysc3WQvFYI4BjGKlH46lepYhxL8rtCSRO6aUfypDiFeA5A
mengT1ZFRBE8GjUbvDXsZjCkyAIqoP6yAYcvyh4pJhs9UMLOA1+3rAyg2idDVnqa
/RogP0dvl2SaQFZ/9wpYD40uQVyRAl5kBQqo0rANvBRnxnq8N5Ao3+Afh1ZkLHaU
Tq5yn1ojsILNYidBgbhICOs=
-----END CERTIFICATE-----
-----BEGIN CERTIFICATE-----
MIIErjCCA5agAwIBAgIQBYAmfwbylVM0jhwYWl7uLjANBgkqhkiG9w0BAQsFADBh
MQswCQYDVQQGEwJVUzEVMBMGA1UEChMMRGlnaUNlcnQgSW5jMRkwFwYDVQQLExB3
d3cuZGlnaWNlcnQuY29tMSAwHgYDVQQDExdEaWdpQ2VydCBHbG9iYWwgUm9vdCBD
QTAeFw0xNzEyMDgxMjI4MjZaFw0yNzEyMDgxMjI4MjZaMHIxCzAJBgNVBAYTAkNO
MSUwIwYDVQQKExxUcnVzdEFzaWEgVGVjaG5vbG9naWVzLCBJbmMuMR0wGwYDVQQL
ExREb21haW4gVmFsaWRhdGVkIFNTTDEdMBsGA1UEAxMUVHJ1c3RBc2lhIFRMUyBS
U0EgQ0EwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCgWa9X+ph+wAm8
Yh1Fk1MjKbQ5QwBOOKVaZR/OfCh+F6f93u7vZHGcUU/lvVGgUQnbzJhR1UV2epJa
e+m7cxnXIKdD0/VS9btAgwJszGFvwoqXeaCqFoP71wPmXjjUwLT70+qvX4hdyYfO
JcjeTz5QKtg8zQwxaK9x4JT9CoOmoVdVhEBAiD3DwR5fFgOHDwwGxdJWVBvktnoA
zjdTLXDdbSVC5jZ0u8oq9BiTDv7jAlsB5F8aZgvSZDOQeFrwaOTbKWSEInEhnchK
ZTD1dz6aBlk1xGEI5PZWAnVAba/ofH33ktymaTDsE6xRDnW97pDkimCRak6CEbfe
3dXw6OV5AgMBAAGjggFPMIIBSzAdBgNVHQ4EFgQUf9OZ86BHDjEAVlYijrfMnt3K
AYowHwYDVR0jBBgwFoAUA95QNVbRTLtm8KPiGxvDl7I90VUwDgYDVR0PAQH/BAQD
AgGGMB0GA1UdJQQWMBQGCCsGAQUFBwMBBggrBgEFBQcDAjASBgNVHRMBAf8ECDAG
AQH/AgEAMDQGCCsGAQUFBwEBBCgwJjAkBggrBgEFBQcwAYYYaHR0cDovL29jc3Au
ZGlnaWNlcnQuY29tMEIGA1UdHwQ7MDkwN6A1oDOGMWh0dHA6Ly9jcmwzLmRpZ2lj
ZXJ0LmNvbS9EaWdpQ2VydEdsb2JhbFJvb3RDQS5jcmwwTAYDVR0gBEUwQzA3Bglg
hkgBhv1sAQIwKjAoBggrBgEFBQcCARYcaHR0cHM6Ly93d3cuZGlnaWNlcnQuY29t
L0NQUzAIBgZngQwBAgEwDQYJKoZIhvcNAQELBQADggEBAK3dVOj5dlv4MzK2i233
lDYvyJ3slFY2X2HKTYGte8nbK6i5/fsDImMYihAkp6VaNY/en8WZ5qcrQPVLuJrJ
DSXT04NnMeZOQDUoj/NHAmdfCBB/h1bZ5OGK6Sf1h5Yx/5wR4f3TUoPgGlnU7EuP
ISLNdMRiDrXntcImDAiRvkh5GJuH4YCVE6XEntqaNIgGkRwxKSgnU3Id3iuFbW9F
UQ9Qqtb1GX91AJ7i4153TikGgYCdwYkBURD8gSVe8OAco6IfZOYt/TEwii1Ivi1C
qnuUlWpsF1LdQNIdfbW3TSe0BhQa7ifbVIfvPWHYOu3rkg1ZeMo6XRU9B4n5VyJY
RmE=
-----END CERTIFICATE-----
";
    private const string KEY = @"
-----BEGIN RSA PRIVATE KEY-----
MIIEowIBAAKCAQEAplo3nx96QdX3u7fFWpvt+ceDtdjmq9qiqZjHoUQxvLib8RzH
gU8kxKwj99Dp7Y2/SZlQSJEj8lg7E7rX7aSNo5AcosWFLD2sKFKDkDG5mCUf1l+e
Gb3rCD4opCrn6ZnL4cp7dPmRf+vtyZ1oEMwHwdnM6qkZq2726nQW/CRzoNE1iSzu
9awPqWN0dKPM5NIQr4NVU0uDA5XmQ4UukB/GTXm79I6Uodun2ps0hjqnAqGntLKr
EzWXM2HJ3/7QEZyukPQG9m9RDW/WhrG2rxWu2V1YkCp1By3F4Gu1djkdYxrArsC8
iXdw0SjEaqXmv2AkWBfl9Yv6VCkBcwDG2heD+QIDAQABAoIBAAcDFYYhEwu0Y7ln
cSu1F+5n8Q7YwjxrPmEMvhl3oOsWEwiyUFyMg/3ATdHT3hBz4aTOEBrG929vNapK
vXBYd9n1qKdZ0RfAz8FxXPdWiT63DeUA6c6m+UHDMP5eiqEHqRbu7I5NOMteHAtc
Fbdjik4rCp63mwvlZQYT96YQOUmFhpMoJaSN/99HQgkL0Qy4vDAmf8SvVuVTsQTB
EClkwvGrkN9+VZe9sI/dnW4Dlj2U//Ec68UuiwqhAZeXQzCVRRcWI8no7nFPgf88
r8Kk4dOupQF2BxMAZq9jcjde5CbOT3rARs4oGy9rnmzSBIzF8yrvhk/nFbHarV4S
LFzWHQMCgYEA48xjom2G9zk3IF0tTt50uvBYdsAlMyBIeZr2WsTTURJdrXnYCXWU
6tOdFlgxn05pO/3HkfCCvbfshSFv1bD3ErrVHZiJydo4EhEixsrWIYHoczNHUzlk
sFEDsnzyMm+oWj8vxrptdcHO59ZxPMZDUjn+xQId7zgoDtLEoGmWgF8CgYEAuvJr
6A8mxTHu87u7zOIatrx2cvffIl8lutSRhcUwiHdYDmGUknykHxETxnS9nqWyAEzH
JzY5D5XdUOvjMFNaQJHw3cdJt7yPFIDM+svFLzrHK1GUFN+sSwD1+MwLVEB1emaB
2Yz5RLrau6/Tmr+Qkhfq9MzvZrgSQaZwp1eT+qcCgYEA1WiEqwW7HF8AsxQ3vxyO
9Rb3eYC3GPeUjkBLrWuZoOj40+1DJFGAiqJnFyjWjC00T1yIG8PbaAsnzO0vTV21
ill4EHr4Ex+Zyes9zkj2ZHvEnjAbEO/C0Z+EPDHr4K5UZP+vLZk3tMs1oGJ4wXvo
U987O6upCZRtir2QMcvZkDcCgYAZLTCvDetQv0rI9E10aDbkyTjCfvND88BnCt2W
QFoq5rerKCUUHUkVDf21yl8HEJWKSMzBUSIaITqu/TWZeoA7Fex0UbRx1CkIv9fb
JrolhCrygIgKz5yqdTSrDv+vlwa7Nzbhj4S6ZteyUxmSS54yrpnr4fWTxdJfmQSu
5LJ/HQKBgE0Kzt+3urhLU2fvXNUUv47u55lEMxRqgZKirBhCCyd83nkLQmuTA16I
Qm9dkDRF279tc0AFhZw+eiXMfoqQKTxzn7RdEkd/aYBnroIoYwt1BI0NBZL71Ffw
kaDWfDYlFo7G45IQCsMCnpMB07yU6WCYw3XYDUubcaeSKEFYY5Jy
-----END RSA PRIVATE KEY-----
";

    [Test]
    public void TestCreate()
    {
        var result = Mojito.Cert.Create(PEM, KEY);
        Assert.That(result.Success, Is.True);
    }

    [Test]
    public void TestGetIssuerCN()
    {
        var result = Mojito.Cert.Create(PEM, KEY);
        var issuer = Mojito.Cert.GetIssuerCN(result.GetOk());
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(issuer, Is.EqualTo("TrustAsia TLS RSA CA"));
        });
    }

    [Test]
    public void TestGetSubject()
    {
        var result = Mojito.Cert.Create(PEM, KEY);
        var subject = Mojito.Cert.GetSubject(result.GetOk());
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(subject, Is.EqualTo("www.fuxianlei.cn"));
        });
    }

    [Test]
    public void TestGetDNSNames()
    {
        var expect = new[] { "www.fuxianlei.cn", "fuxianlei.cn" };
        var result = Mojito.Cert.Create(PEM, KEY);
        var dns = Mojito.Cert.GetDNSNames(result.GetOk());
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(dns, Is.EqualTo(expect));
        });
    }
}
