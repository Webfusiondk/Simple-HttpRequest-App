using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace HttpRequest
{
    class Program 
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main()
        {
            try
            {
                HttpResponseMessage respons = await client.GetAsync(@"https://ugenr.dk/");
                respons.EnsureSuccessStatusCode();
                string responsBody = await respons.Content.ReadAsStringAsync();

                Console.WriteLine(Regex.Replace(responsBody, "<[^>]*>", "Removed"));
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            Console.ReadKey();
        }
        
    }
}
