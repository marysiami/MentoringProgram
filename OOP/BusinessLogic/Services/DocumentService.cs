using BusinessLogic.Interfaces;
using Newtonsoft.Json;

namespace BusinessLogic.Services
{
    public class DocumentService : IDocumentService
    {
        private IDocumentRepository _documentRepository;
        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public T GetDocument<T>(string path) where T : IDocument
        {
            using StreamReader r = new StreamReader(path);
            string json = r.ReadToEnd();
            var result = JsonConvert.DeserializeObject<T>(json);  
            if(result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Cannot convert json to file");
            }
        }

        public string[] GetDocumentsNames(string number)
        {
           return _documentRepository.GetDocumentsDirectories(number);
        }

        public string GetDocumentType(string name)
        {
            return name.Split("_")[0];
        }
    }
}
