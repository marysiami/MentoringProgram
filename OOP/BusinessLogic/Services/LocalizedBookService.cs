using BusinessLogic.Interfaces;

namespace BusinessLogic.Services
{
    public class LocalizedBookService : DocumentService<LocalizedBook>
    {
        public LocalizedBookService(IDocumentRepository documentRepository) : base(documentRepository)
        {
        }
    }
}
