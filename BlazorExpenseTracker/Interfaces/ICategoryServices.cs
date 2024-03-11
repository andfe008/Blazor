using BlazorExpenseTracker.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorExpenseTracker.Interfaces
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryDetails(int id);
        Task SaveCategory(Category category);
        Task DeleteCategory(int id);


    }
}
