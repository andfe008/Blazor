using BlazorExpenseTracker.Data.Repositories;
using BlazorExpenseTracker.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorExpenseTracket.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : Controller
    {

        private IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllExpenses()
        {
            return Ok(await _expenseRepository.GetAllExpenses());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseDetails(int id)
        {
            return Ok(await _expenseRepository.GetExpenseDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult>InsertExpense([FromBody] Expense expense)
        {
            if (expense == null)
                return BadRequest();
            if (expense.Id < 0)
            {
                ModelState.AddModelError("Name", "Expense Name Shouldn´t be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var create = await _expenseRepository.InsertExpense(expense);

            return Created("created", create);
        }

        [HttpPut]
        public async Task<IActionResult>InsertCategory([FromBody] Expense expense)
        {
            if (expense == null)
                return BadRequest();
            if (expense.Id < 0)
            {
                ModelState.AddModelError("Name", "Expense Name Shouldn´t be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _expenseRepository.UpdateExpense(expense);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            if (id == 0)
                return BadRequest();
            await _expenseRepository.DeleteExpense(id);

            return NoContent();

        }





    }




}
