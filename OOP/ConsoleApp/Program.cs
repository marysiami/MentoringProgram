using BusinessLogic;
using BusinessLogic.Handlers;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using FileSystem.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

var host = CreateHostBuilder(args).Build();

while (true)
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
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<IDocumentService<Book>, DocumentService<Book>>();
            services.AddSingleton<IDocumentService<LocalizedBook>, DocumentService<LocalizedBook>>();
            services.AddSingleton<IDocumentService<Patent>, DocumentService<Patent>>();
            services.AddSingleton<IDocumentService<Magazine>, DocumentService<Magazine>>();
            services.AddSingleton<IDocumentService<IDocument>, DocumentService<IDocument>>();
            services.AddSingleton<DocumentService<Book>, BookService>();
            services.AddSingleton<DocumentService<LocalizedBook>, LocalizedBookService>();
            services.AddSingleton<DocumentService<Patent>, PatentService>();
            services.AddSingleton<DocumentService<Magazine>, MagazineService>();
            services.AddSingleton<DocumentService<IDocument>, GenericDocumentService>();
            services.AddSingleton<BusinessLogic.Interfaces.IServiceProvider, BusinessLogic.Providers.ServiceProvider>();
            services.AddSingleton<IDocumentRepository, FileRepository>();
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

    var list = handler.GetCards(number);

    Console.Write($"---- Found {list.Length} documents ----  \n");
    if (list.Length > 0)
    {
        for (int i = 0; i < list.Length; i++)
        {
            Console.WriteLine($"[{i}] - {list[i].Type} - {list[i].Number} \n");
        }

        Console.WriteLine("---- Choose document ID ----  \n");
        var id = Console.ReadLine();
        if (string.IsNullOrEmpty(id))
        {
            return;
        }

        var idNumber = int.Parse(id);
        var card = list[idNumber];
        var document = handler.GetDocumentInfo(card).Result;

        Console.WriteLine("---- Document CARD details ----  \n");
        Console.WriteLine(document);
    }

    Console.ReadKey();
    Console.WriteLine();
    Console.WriteLine("---- End ----");
    Console.WriteLine();
}

