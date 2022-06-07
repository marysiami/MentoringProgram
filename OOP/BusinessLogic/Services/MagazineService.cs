using BusinessLogic.Interfaces;
namespace BusinessLogic.Services
{
    public class MagazineService : DocumentService<Magazine>
    {
        public MagazineService(IDocumentRepository documentRepository) : base(documentRepository)
        {
        }
    }
}
