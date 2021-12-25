using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace requestapp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // based on the recommendation by @maxfire (https://community.dotnetos.org/t/discussions-module-1-lesson-8-homework/327/25)
            // The code page 852 is required to make the bell ring
            const int CP = 852;

            // By default, .NET Core does not make available any code page encodings other than code page 28591
            // and the Unicode encodings, such as UTF-8 and UTF-16. However, you can add the code page encodings
            // found in standard Windows apps that target .NET to your app.
            var encoder = CodePagesEncodingProvider.Instance.GetEncoding(CP);
            Console.OutputEncoding = encoder;

            using var client = new HttpClient();

            var resp = await client.GetAsync("https://asyncexpert.com/");

            Console.WriteLine(await resp.Content.ReadAsStringAsync());
        }
    }
}
