namespace BusinessLogic.Interfaces
{
    public interface IRequestHandler
    {
        Card[] GetCards(string number);

        Task<string> GetDocumentInfo(Card card);
    }
}