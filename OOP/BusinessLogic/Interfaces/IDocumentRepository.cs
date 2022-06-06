namespace BusinessLogic.Interfaces
{
    public interface IDocumentRepository
    {
        Task<T> GetDocument<T>(string name) where T : IDocument;
        string[] GetDocumentsDirectories(string name);
    }
}
