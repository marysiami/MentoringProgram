using BusinessLogic.Interfaces;
using BusinessLogic.Models.Attributes;

namespace BusinessLogic

{
    [Serializable]
    [CacheSettings(true, CacheLifespan.OneHour)]
    public class Book : IDocument
    {
        public string? ISBN { get; set; }    
        public string? Title { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
        public int NumberOfPages { get; set; }
        public string? Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Number { get; set; }
        public bool IsCacheEnabled { get; set; } = true;
        public DateTime ExpirationDate { get; set; }
    }
}