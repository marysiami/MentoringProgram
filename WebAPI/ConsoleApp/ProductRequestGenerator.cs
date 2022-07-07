using MyWebApiApplication.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ConsoleApp
{
    public class ProductRequestGenerator
    {
        private HttpClient Client { get; set; }
        public ProductRequestGenerator()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7182/api/")
            };

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }      

        public async Task<string> GetAllProducts()
        {
            HttpResponseMessage response = Client.GetAsync("Products").Result;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task<string> GetFilteredProducts(int pageNumber, int pageSize, int categoyId)
        {
            HttpResponseMessage response = Client.GetAsync($"Products?pageNumber={pageNumber}&pageSize={pageSize}&categoyId={categoyId}").Result;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task<string> GetProductById(int id)
        {
            HttpResponseMessage response = Client.GetAsync($"Products/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task<string> CreateProduct(Product product)
        {
            HttpResponseMessage response = Client.PostAsJsonAsync($"Products", product).Result;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task<string> UpdateProduct(int id, Product product)
        {
            HttpResponseMessage response = Client.PutAsJsonAsync($"Products/{id}", product).Result;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task<string> DeleteProduct(int id)
        {
            HttpResponseMessage response = Client.DeleteAsync($"Products/{id}").Result;
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
