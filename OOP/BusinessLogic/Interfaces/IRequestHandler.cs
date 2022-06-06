namespace BusinessLogic.Interfaces
{
    public interface IRequestHandler
    {
        string[] GetDocuments(string number);

        string GetDocumentInfo(string path);
    }
}
