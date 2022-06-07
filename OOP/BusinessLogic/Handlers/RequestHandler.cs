using BusinessLogic.Interfaces;
using BusinessLogic.Services;

namespace BusinessLogic.Handlers
{
    public class RequestHandler : IRequestHandler
    {
        private IDocumentService[] _services;
        private readonly IDocumentService<IDocument> _genericDocumentService;

        public RequestHandler(
            IDocumentService<IDocument> genericDocumentService,
            BusinessLogic.Interfaces.IServiceProvider serviceProvider)
        {
            _genericDocumentService = genericDocumentService;
            _services = serviceProvider.GetServices();
        }

        public Card[] GetCards(string number)
        {
            var validNumber = int.TryParse(number, out int result);
            if (!validNumber)
            {
                return Array.Empty<Card>();
            }

            var cards = _genericDocumentService.GetCards(number);
            return cards.ToArray();
        }

        public async Task<string> GetDocumentInfo(Card card)
        {
            var handler = _services.FirstOrDefault(x => x.CanHandleDocument(card.Type));

            switch (handler)
            {
                case BookService bookService:
                    var resultBook = await bookService.GetDocument(card.Number);

                    return $"Book found: {resultBook.Title}";

                case LocalizedBookService localizedBookService:
                    var resultLocalizedBook = await localizedBookService.GetDocument(card.Number);

                    return $"Localized book found: {resultLocalizedBook.Title}";

                case PatentService patentService:
                    var resultPatent = await patentService.GetDocument(card.Number);

                    return $"Patent found: {resultPatent.Title}";

                case MagazineService magazineService:
                    var resultMagazine = await magazineService.GetDocument(card.Number);

                    return $"Magazine found: {resultMagazine.Title}";
                
                default:
                    return string.Empty; 
            }
        }
    }
}
