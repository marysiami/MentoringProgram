using BusinessLogic.Interfaces;
using BusinessLogic.Services;

namespace BusinessLogic.Providers
{
    public class ServiceProvider : Interfaces.IServiceProvider
    {
        private readonly IDocumentService[] _services;
        public ServiceProvider(
            DocumentService<Book> bookService,
            DocumentService<LocalizedBook> localizedBookService,
            DocumentService<Magazine> magazineService,
            DocumentService<Patent> patentService)
        {
            _services = new IDocumentService[]
            {
                bookService,
                localizedBookService,
                magazineService,
                patentService
            };
        }

        public IDocumentService[] GetServices()
        {
            return _services;
        }
    }
}
