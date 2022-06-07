using BusinessLogic.Interfaces;

namespace BusinessLogic
{
    public class Magazine : IDocument
    {
        public int Number { get; set; }
        public string? Title { get; set; }
        public string? Publisher { get; set; }
        public string? ReleaseNumber { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsCacheEnabled { get; set; } = false;
        public DateTime ExpirationDate { get; set; }
    }
}
