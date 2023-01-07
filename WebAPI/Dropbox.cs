using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Dropbox
    {
        private string TOKEN = "sl.BWe8RDna7wjNZS8Rn7QlVCsA4K2Ax6GHwJnrck7Ll_qZoof0rjeyRvm6vaHlNTq1XYDNpPiVTEMnwUaZ--QW6dyq1LM_QV1m5NWDUgQ9Yj1RRxoxj6WP72XEiGbs-TK-X3o9mWWR71LN";
        private HttpClient client;

        public Dropbox()
        {
            client = new HttpClient();
        }

        public void PutFile(string filePath, string dropboxPath)
        {         
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://content.dropboxapi.com/2/files/upload"),
                Headers = {
                    { "Authorization", $"Bearer {TOKEN}" },
                    { "Dropbox-API-Arg", $"{{\"autorename\":false,\"mode\":\"overwrite\",\"mute\":false,\"path\":\"{dropboxPath}\",\"strict_conflict\":false}}" }
                },
                Content = new StreamContent(new FileStream(filePath, FileMode.Open)),
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            var response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to upload file");
            }
        }

        public JObject GetFileInfo(string dropboxPath)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.dropboxapi.com/2/files/get_metadata"),
                Headers = {
                    { "Authorization", $"Bearer {TOKEN}" }
                },
                Content = new StringContent($"{{\"path\": \"{dropboxPath}\"}}", Encoding.UTF8, "application/json")
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = client.SendAsync(request).Result;
            return JObject.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public void RemoveFile(string dropboxPath)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.dropboxapi.com/2/files/delete"),
                Headers = {
                    { "Authorization", $"Bearer {TOKEN}" }
                },
                Content = new StringContent($"{{\"path\": \"{dropboxPath}\"}}", Encoding.UTF8, "application/json")
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete file");
            }
        }
    }
}