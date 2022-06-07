using BusinessLogic.Interfaces;
using BusinessLogic.Models.Attributes;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace FileSystem.Repositories
{
    public class FileRepository : IDocumentRepository
    {
        private readonly string _directory;
        private readonly IMemoryCache _memoryCache;
        public FileRepository(IMemoryCache memoryCache)
        {
            _directory = $"{Directory.GetCurrentDirectory()}/data";
            _memoryCache = memoryCache;
        }

        public async Task<T> GetDocument<T>(string number) where T : IDocument
        {
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException("number");
            }

            var fileName = GetFileName<T>(number);

            var cacheSettings = GetCachingSettings<T>();

            if (cacheSettings.IsEnabled && _memoryCache.TryGetValue(fileName, out T documentFromCache))
            {
                return documentFromCache;
            }

            var filePath = GetFilePath(fileName);

            using StreamReader r = new(filePath);
            string json = await r.ReadToEndAsync();

            try
            {
                var document = JsonConvert.DeserializeObject<T>(json);

                if (cacheSettings.IsEnabled)
                {
                    _memoryCache.Set(fileName, document, cacheSettings.SlidingExpiration);
                }

                return document;
            }

            catch
            {
                throw;
            }
        }

        private CacheSettingsAttribute GetCachingSettings<T>()
        {
            var attribute = typeof(T).GetCustomAttributes(false).FirstOrDefault(x => x.GetType() == typeof(CacheSettingsAttribute));

            if (attribute == null)
            {
                return null;
            }

            var cacheSettingsAttribute = (CacheSettingsAttribute)attribute;

            return cacheSettingsAttribute;
        }

        private string GetFilePath(string fileName)
        {
            return $"{_directory}/{fileName}";
        }

        private string GetFileName<T>(string number)
        {
            var typeName = typeof(T).Name.ToLower();
            var fileName = $"{typeName}_#{number}.json";

            return fileName;
        }

        public string[] GetDocuments(string name)
        {
            var paths = Directory.GetFiles(_directory, $"*{name}*").Select(x => Path.GetFileName(x));
            return paths.ToArray();
        }
    }
}
