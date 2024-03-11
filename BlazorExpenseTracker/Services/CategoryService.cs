using BlazorExpenseTracker.Interfaces;
using BlazorExpenseTracker.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorExpenseTracker.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        string Uri = "api/category";
        public async Task DeleteCategory(int id)
        {
            await _httpClient.DeleteAsync($"api/category/{id}");
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Category>>(
                   await _httpClient.GetStreamAsync($"api/category"),
                   new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Category> GetCategoryDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Category>(
                   await _httpClient.GetStreamAsync($"api/category/{id}"),
                   new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task SaveCategory(Category category)
        { 
            var categoryJson = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");
            if (category.Id == 0)
            {  
                   await _httpClient.PostAsync(Uri, categoryJson);
            }
            else {
               await _httpClient.PutAsync(Uri, categoryJson);
            }
        }
    }
}