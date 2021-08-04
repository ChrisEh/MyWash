using System.Net.Http;

namespace NewApp.Models
{
    public static class AppSettings
    {
        // For some reason it is not possible to use localhost or 127.0.0.1, has to be local network ip.
        public static string ApiUrl = "https://192.168.0.8:44369/api/";

        public static HttpClient GetClient()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
    }
}