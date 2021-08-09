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
                //Sending http request to website
                HttpResponseMessage respons = await client.GetAsync(@"https://ugenr.dk/");
                respons.EnsureSuccessStatusCode();
                //Reading the response from website
                string responsBody = await respons.Content.ReadAsStringAsync();

                //Writing the response and replacing all HTML to text "Removed"
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
