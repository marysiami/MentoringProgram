using BusinessLogic.Interfaces;
using BusinessLogic.Models;

namespace ConsoleApp
{
    public class RequestHandler : IRequestHandler
    {
        private IDocumentService _documentService;
        public RequestHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public string[] GetDocuments(string number)
        {
            var validNumber = int.TryParse(number, out int result);
            if (!validNumber)
            {
                return Array.Empty<string>();
            }

            return _documentService.GetDocumentsNames(number);
        }

        public string GetDocumentInfo(string name)
        {       
            var typeName = _documentService.GetDocumentType(name);

             switch (typeName)
            {
                case "Book":
                    var book = _documentService.GetDocument<Book>(name);
                    return $"Number: {book.Number}\n ISBN: {book.ISBN}\n Publisher: {book.Publisher}";
                case "LocalizedBook":
                    var localizedBook = _documentService.GetDocument<LocalizedBook>(name);
                    return $"Number: {localizedBook.Number} ISBN: {localizedBook.ISBN}\n Publisher: {localizedBook.Publisher}";
                case "Patent":
                    var patent = _documentService.GetDocument<Patent>(name);
                    return $"Number: {patent.Number} ExpirationDate: {patent.ExpirationDate}\n PublishedDate: {patent.PublishedDate}";
                default:
                    return String.Empty;
            };          
                
        }
    }
}
