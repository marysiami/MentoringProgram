using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class Book : IDocument
    {
        public string? ISBN { get; set; }    
        public string? Title { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
        public int NumberOfPages { get; set; }
        public string? Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Number { get; set; }
    }
}