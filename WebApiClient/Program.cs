using System;
using System.Net.Http;
using System.Threading.Tasks;

static async Task Main(string[] args) {

    Console.WriteLine("press any key to cont...");
    Console.ReadLine();

    using (HttpClient client = new HttpClient())
    {
        var response = await client.GetAsync("https://localhost:7295/values");
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
        }
        else
        {
            Console.WriteLine(response.StatusCode.ToString());
        }
    }

    Console.ReadLine();
}
