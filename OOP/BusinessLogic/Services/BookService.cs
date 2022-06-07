using BusinessLogic.Interfaces;

namespace BusinessLogic.Services
{
    public class BookService : DocumentService<Book>
    {
        public BookService(IDocumentRepository documentRepository) : base(documentRepository)
        {
        }
    }
}
