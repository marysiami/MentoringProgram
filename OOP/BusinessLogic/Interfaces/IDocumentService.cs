namespace BusinessLogic.Interfaces
{
    public interface IDocumentService
    {
        string[] GetDocumentsNames(string number);
        T GetDocument<T>(string path) where T : IDocument;
        string GetDocumentType(string name);
    }
}
