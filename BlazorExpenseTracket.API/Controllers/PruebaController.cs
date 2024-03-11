using BlazorExpenseTracker.Data.Repositories;
using BlazorExpenseTracker.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorExpenseTracket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public PruebaController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategory([FromBody] Category category)
        {
            if (category == null)
                return BadRequest();
            if (category.Name.Trim() == string.Empty)
            {
                ModelState.AddModelError("Name", "Category Name Shouldn´t be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var create = await _categoryRepository.InsertCategory(category);

            return Created("created", create);
        }
    }
}
