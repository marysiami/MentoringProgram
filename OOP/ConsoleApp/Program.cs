using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using ConsoleApp;
using FileSystem.Repositories;
using FileSystem.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

var host = CreateHostBuilder(args).Build();

//PrepareData();

Logic(host);

static IHostBuilder CreateHostBuilder(string[] args)
{
    var hostBuilder = Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, builder) =>
        {
            builder.SetBasePath(Directory.GetCurrentDirectory());
        })
        .ConfigureServices((context, services) =>
        {
            services.AddSingleton<IDocumentRepository, FileRepository>();
            services.AddSingleton<IDocumentService, DocumentService>();
            services.AddSingleton<IRequestHandler, RequestHandler>();

        });

    return hostBuilder;
}

static void Logic(IHost host)
{
    var handler = host.Services.GetRequiredService<IRequestHandler>();

    Console.WriteLine("---- write document number ----");

    var number = Console.ReadLine();

    if (string.IsNullOrEmpty(number))
    {
        return;
    }

    var list = handler.GetDocuments(number);

    Console.Write($"---- Found {list.Length} documents ----  \n");
    if (list.Length > 0)
    {
        for (int i = 0; i < list.Length; i++)
        {
            Console.WriteLine($"[{i}] - {list[i]} \n");
        }



        Console.WriteLine("---- Choose document ID ----  \n");
        var id = Console.ReadLine();
        if (string.IsNullOrEmpty(id))
        {
            return;
        }

        var idNumber = int.Parse(id);
        var path = list[idNumber];
        var document = handler.GetDocumentInfo(path);

        Console.WriteLine("---- Document CARD details ----  \n");
        Console.WriteLine(document);
    }

    Console.WriteLine();
    Console.WriteLine("---- End ----");
}


void PrepareData()
{
    var book = new Book()
    {
        ISBN = "1234ABC",
        Number = 32154,
        Authors = new List<Author>() { new Author() { Name = "Jan", Surname = "Kowalski" } },
        NumberOfPages = 100,
        PublishedDate = DateTime.Now,
        Publisher = "AAA",
        Title = "Title1"
    };
    var localizedBook = new LocalizedBook()
    {
        ISBN = "AA1234ABC",
        Number = 1432,
        Authors = new List<Author>() { new Author() { Name = "Jan", Surname = "Kowalski" } },
        NumberOfPages = 120,
        PublishedDate = DateTime.Now,
        Publisher = "ABBB",
        Title = "Title2"
    };
    var patent = new Patent()
    {
        Authors = new List<Author>() { new Author() { Name = "Jan", Surname = "Kowalski" }, new Author() { Name = "Anna", Surname = "Nowak" } },
        Id = Guid.NewGuid(),
        ExpirationDate = DateTime.Now.AddDays(1),
        Number = 1432,
        PublishedDate = DateTime.Now,
        Title = "ABC"
    };

    var bookR = JsonConvert.SerializeObject(book);
    var dir = Directory.GetCurrentDirectory();
    string fileName = $"{dir}/data/{book.GetType().Name}_#{book.Number}.json";
    File.WriteAllText(fileName, bookR);

    var localizedBookR = JsonConvert.SerializeObject(localizedBook);
    fileName = $"{dir}/data/{localizedBook.GetType().Name}_#{localizedBook.Number}.json";
    File.WriteAllText(fileName, localizedBookR);

    var patentR = JsonConvert.SerializeObject(patent);
    fileName = $"{dir}/data/{patent.GetType().Name}_#{patent.Number}.json";
    File.WriteAllText(fileName, patentR);

}
    