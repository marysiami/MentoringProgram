using MyWebApiApplication.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ConsoleApp
{
    public class CategoryRequestGenerator
    {
        private HttpClient Client { get; set; }
        public CategoryRequestGenerator()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7182/api/")
            };

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetAllCategories()
        {
            HttpResponseMessage response = Client.GetAsync("Categories").Result;
            if (response.IsSuccessStatusCode)
            {
                var r = await response.Content.ReadAsStringAsync();
                return r;
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task<string> GetCategoryById(int id)
        {
            HttpResponseMessage response = Client.GetAsync($"Categories/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return string.Empty;
            }
        }


        public async Task<string> CreateCategory(Category category)
        {
            HttpResponseMessage response = Client.PostAsJsonAsync($"Categories", category).Result;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task<string> UpdateCategory(int id, Category category)
        {
            HttpResponseMessage response = Client.PutAsJsonAsync($"Categories/{id}", category).Result;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task<string> DeleteCategory(int id)
        {
            HttpResponseMessage response = Client.DeleteAsync($"Categories/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
