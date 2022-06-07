using BusinessLogic.Interfaces;

namespace BusinessLogic.Services
{
    public class GenericDocumentService : DocumentService<IDocument>
    {
        public GenericDocumentService(IDocumentRepository documentRepository) : base(documentRepository)
        {
        }
    }
}
