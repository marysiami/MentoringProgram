using BusinessLogic.Interfaces;

namespace BusinessLogic
{
    [Serializable]
    public class Patent : IDocument
    {
        public int Number { get; set; }
        public Guid Id { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
        public string? Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsCacheEnabled { get; set; } = true;
    }
}