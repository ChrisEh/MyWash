using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NewApp.Services
{
    public static class HttpsValidation
    {
        //Call GenerateSSLpubklickey callback method and repalce here   
        static string PUBLIC_KEY = "MIIDDTCCAfWgAwIBAgIJAM/+jcyarIkIMA0GCSqGSIb3DQEBCwUAMBQxEjAQBgNVBAMTCWxvY2FsaG9zdDAeFw0yMDEwMDIxMjUxNTlaFw0yMTEwMDIxMjUxNTlaMBQxEjAQBgNVBAMTCWxvY2FsaG9zdDCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAKTQKMKNYLN+D5d80H+R//u0SD8m+18yDFC6z+Wd8H3mPO9Wy7Fq/Jf1+dCfURpeZc2I6xdukEhQNj8yUE2wZqZpaQD8pfDPt+PZ3q0jHpH4909gMwKQ3qh7OkX1n7jdmLNrh8VebeGLWDcoRZiXFNwE/ml0WUeDAuGzphineqxJKByDF545OLV4zM7R4oX00WvaRF1eD0Pe1XOWmo1zbDMwgcd7AYUcVmSqMPjNv2rqudFftu0xMnuoZR66H8YLwyFAVPZNaD1nT0Sdvk9x6+ecAzQRSXqsi21yKxjSYfR5o8ynjKOQYLcVDMitF83YJA0kqZYhweOHkVaSSev8GAECAwEAAaNiMGAwDAYDVR0TAQH/BAIwADAOBgNVHQ8BAf8EBAMCBaAwFgYDVR0lAQH/BAwwCgYIKwYBBQUHAwEwFwYDVR0RAQH/BA0wC4IJbG9jYWxob3N0MA8GCisGAQQBgjdUAQEEAQEwDQYJKoZIhvcNAQELBQADggEBAGxKZKjB2FNSjKuNSQbtuYF+UXCqD+n9Hy5kTvn1FnNiSLWGkHOt7X8cX+s76zRq5rRZIqwNeVBQ0a/s2IL2bTuwDoWU/Gw2eTPlRASlL1CA2o0aOjL7AXVm1ZsSs/ELXT7Nm0qkCPffAAhDAJUtHaOfoRzO4aSgYh/SLq0LQ6oR4OLOi11G4O0PQQZNa6HjqNJlEupusxuxaQLE+aAEyi6hBCHTAVhbMoO0LCut7ZFJ7X3SrocHkoTJuUS9br5LvMw3B44sxqyRqXSpMvi+6w/T7II1xqsVrNj7zJjtZGAECSEpO4cGsCK0vLoOJf8T0XqjX0uOwjzul7O7fDIAmSw=";
        public static void Initialize()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // ServicePointManager.ServerCertificateValidationCallback = OnValidateCertificate;  
            //Generate Public Key and replace publickey variable   
            //  ServicePointManager.ServerCertificateValidationCallback = GenerateSSLPublicKey;  
            ServicePointManager.ServerCertificateValidationCallback = OnValidateCertificate;
        }

        static bool OnValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            var certPublicString = certificate?.GetPublicKeyString();
            var keysMatch = PUBLIC_KEY == certPublicString;
            return keysMatch;
        }

        static string GenerateSSLPublicKey(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            string certPublicString = certificate?.GetPublicKeyString();
            return certPublicString;
        }
    }
}
