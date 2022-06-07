using BusinessLogic.Interfaces;
using Newtonsoft.Json;

namespace BusinessLogic.Services
{
    public class DocumentService<T> : IDocumentService<T> where T : IDocument
    {
        private IDocumentRepository _documentRepository;
        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<T> GetDocument(string number)
        {
            return await _documentRepository.GetDocument<T>(number);
        }

        public string SerializeDocumentInfo(T document)
        {
            return JsonConvert.SerializeObject(document);
        }  

        public List<Card> GetCards(string number)
        {
            var documents = _documentRepository.GetDocuments(number);
            var cards = new List<Card>();
            foreach(var document in documents)
            {
                var cardParams = document.Split("_#");
                cards.Add( new Card() { Number = cardParams[1].Replace(".json",""), Type = cardParams[0]} );
            }

            return cards;
        }

        public string GetDocumentType(string path)
        {
            var name = Path.GetFileName(path);
            return name.Split("_")[0];
        }

        public bool CanHandleDocument(string typeName)
        {
            var assembly = this.GetType().Assembly.GetName().Name;
            var type = Type.GetType($"{assembly}.{typeName}");
            var t_type = typeof(T);
            return type == t_type;
        }
    }
}
