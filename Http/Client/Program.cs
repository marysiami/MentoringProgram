using System.Net;

Console.WriteLine($"Running client....");
await Main();

static async Task Main()
{
    try
    {
        using var client = new HttpClient();

        //success
        var success = await client.GetAsync("http://localhost:8888/Success");
        Console.WriteLine($"Success content: {await success.Content.ReadAsStringAsync()}");
        Console.WriteLine($"Success status code: {success.StatusCode}");

        //GetName 
        var name = await client.GetAsync("http://localhost:8888/MyName");
        var body = await name.Content.ReadAsStringAsync();
        Console.WriteLine($"My name is {body}");

        //Redirection
        var redirection = await client.GetAsync("http://localhost:8888/Redirection");
        Console.WriteLine($"Redirection content: {await redirection.Content.ReadAsStringAsync()}");
        Console.WriteLine($"Redirection status code: {redirection.StatusCode}");

        //ClientError
        var clientError = await client.GetAsync("http://localhost:8888/ClientError");
        Console.WriteLine($"ClientError content: {await clientError.Content.ReadAsStringAsync()}");
        Console.WriteLine($"ClientError status code: {clientError.StatusCode}");

        //ServerError
        var serverError = await client.GetAsync("http://localhost:8888/ServerError");
        Console.WriteLine($"ServerError content: {serverError.Content.ReadAsStringAsync()}");
        Console.WriteLine($"ServerError status code: {serverError.StatusCode}");

        //Information
        var information = await client.GetAsync("http://localhost:8888/Information", HttpCompletionOption.ResponseHeadersRead);
        Console.WriteLine($"Information status code: {information.StatusCode}");

        //MyNameByHeader
        var nameByHeader = await client.GetAsync("http://localhost:8888/MyNameByHeader");
        var header = "X-MyName";
        IEnumerable<string> headerValues = nameByHeader.Headers.GetValues(header);
        var nameString = headerValues.FirstOrDefault();
        Console.WriteLine($"My Name By Header {header}: {nameString}");

        //MyNameByCookie
        CookieContainer cookies = new();
        HttpClientHandler handler = new()
        {
            CookieContainer = cookies
        };
        var cookieClient = new HttpClient(handler);
        var nameByCookie = await cookieClient.GetAsync("http://localhost:8888/MyNameByCookies");
        var responseCookies = cookies.GetCookies(new Uri("http://localhost:8888/MyNameByCookies"))
            .Cast<Cookie>()
            .Where(x=>x.Name == "MyName")
            .FirstOrDefault();

        Console.WriteLine($"My Name By Cookies: {responseCookies?.Value}");
    }
    catch (Exception e)
    { 
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);    
    }
}

