using System;
using System.Web;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace ConsoleApp2
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            string responseQRDataDetails = Upload().GetAwaiter().GetResult();
            Console.WriteLine(responseQRDataDetails);

            Console.ReadLine();
        }


        private static async Task<string> Upload()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://api.qrserver.com/v1/read-qr-code/");
            var content = new MultipartFormDataContent();
            byte[] byteArray = System.IO.File.ReadAllBytes("C:\\Scan\\file.PNG");
            content.Add(new ByteArrayContent(byteArray), "file", "file.PNG");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    }

    
}
