// See https://aka.ms/new-console-template for more information
using BusinessLogic.Interfaces;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
using ConsoleApp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = CreateHostBuilder(args).Build();

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

    Console.Write($"Found {list.Length} documents");

    for(int i = 0; i < list.Length; i++)
    {
        Console.WriteLine($"{i} - {list[i]}");
    }
       
    Console.WriteLine("Choose document ID");
    var id = Console.ReadLine();
    if(string.IsNullOrEmpty(id))
    {
        return;
    }

    var idNumber = int.Parse(id);
    var path = list[idNumber];
    var document = handler.GetDocumentInfo(path);

    Console.WriteLine(document);
    Console.WriteLine("---- End ----");


}