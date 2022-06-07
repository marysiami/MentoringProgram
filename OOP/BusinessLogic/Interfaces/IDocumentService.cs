namespace BusinessLogic.Interfaces
{
    public interface IDocumentService<T>: IDocumentService where T: IDocument
    {
        List<Card> GetCards(string number);
        Task<T> GetDocument(string number);
        string GetDocumentType(string number);
        string SerializeDocumentInfo(T document);

    }
    public interface IDocumentService 
    { 
        bool CanHandleDocument(string type);
    }
}
