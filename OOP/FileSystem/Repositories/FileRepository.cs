using BusinessLogic.Interfaces;
using Newtonsoft.Json;

namespace FileSystem.Repositories
{
    public class FileRepository : IDocumentRepository
    { 
        private string directory { get; set; }
        public FileRepository()
        {
            directory = $"{Directory.GetCurrentDirectory()}/data";
        }

        public async Task<T> GetDocument<T>(string name) where T : IDocument
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name");
            }

            using StreamReader r = new(name);
            string json = await r.ReadToEndAsync();
           
            var document = JsonConvert.DeserializeObject<T>(json);
           
            return document;
        }

        public string[] GetDocumentsDirectories(string name)
        {
            return Directory.GetFiles(directory, $"*{name}*");
        }
    }
}
