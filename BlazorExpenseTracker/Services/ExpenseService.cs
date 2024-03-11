using BlazorExpenseTracker.Interfaces;
using BlazorExpenseTracker.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorExpenseTracker.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly HttpClient _httpClient;
        string Uri = "api/expense";
        public  ExpenseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteExpense(int id)
        {
            await _httpClient.DeleteAsync($"api/expense/{id}");
        }

        public async Task<IEnumerable<Expense>> GetAllExpense()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Expense>> (
                await _httpClient.GetStreamAsync($"api/expense"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

        public async Task<Expense> GetExpenseDetails(int id)
        {
            return await JsonSerializer.DeserializeAsync<Expense>(
                    await _httpClient.GetStreamAsync($"api/expense/{id}"),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task SaveExpense(Expense expense)
        {
            var expenseyJson = new StringContent(JsonSerializer.Serialize(expense), Encoding.UTF8, "application/json");
            if (expense.Id == 0)
            {
                await _httpClient.PostAsync(Uri, expenseyJson);
            }
            else
            {
                await _httpClient.PutAsync(Uri, expenseyJson);
            }
        }
    }
}
