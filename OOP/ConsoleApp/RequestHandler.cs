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
                    return $" Number: {book.Number}\n" +
                        $" Title: {book.Title}\n" +
                        $" Authors:{string.Join(" and ", book.Authors.Select(x => $"{x.Name} {x.Surname}"))}\n" +
                        $" ISBN: {book.ISBN}\n " +
                        $" Publisher: {book.Publisher}\n ";
                       
                case "LocalizedBook":
                    var localizedBook = _documentService.GetDocument<LocalizedBook>(name);
                    return $" Number: {localizedBook.Number}\n" +
                        $" Title: {localizedBook.Title}\n" +
                        $" Authors:{string.Join(" and ", localizedBook.Authors.Select(x => $"{x.Name} {x.Surname}"))}\n" +
                        $" ISBN: {localizedBook.ISBN}\n" +
                        $" Publisher: {localizedBook.Publisher}\n";

                case "Patent":
                    var patent = _documentService.GetDocument<Patent>(name);
                    return $" Number: {patent.Number}\n" +
                        $" Title: {patent.Title}\n" +
                        $" Authors:{string.Join(" and ", patent.Authors.Select(x => $"{x.Name} {x.Surname}"))}\n" +
                        $" ExpirationDate: {patent.ExpirationDate}\n" +
                        $" PublishedDate: {patent.PublishedDate}\n";

                case "Magazine":
                    var magazine = _documentService.GetDocument<Magazine>(name);
                    return $" Number: {magazine.Number}\n" +
                        $" Title: {magazine.Title}\n" +
                        $" PublishDate: {magazine.PublishDate}\n" +
                        $" ReleaseNumber: {magazine.ReleaseNumber}\n" +
                        $" Publisher: {magazine.Publisher}\n";
                default:
                    return String.Empty;
            };         
                
        }
    }
}
