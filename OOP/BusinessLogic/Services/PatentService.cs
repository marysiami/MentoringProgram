using BusinessLogic.Interfaces;

namespace BusinessLogic.Services
{
    public class PatentService : DocumentService<Patent>
    {
        public PatentService(IDocumentRepository documentRepository) : base(documentRepository)
        {
        }
    }
}
