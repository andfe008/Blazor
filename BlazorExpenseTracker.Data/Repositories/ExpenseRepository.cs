using BlazorExpenseTracker.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExpenseTracker.Data.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {

        private SqlConfiguration _connecctionString;

        public ExpenseRepository(SqlConfiguration connecctionString)
        {
            _connecctionString = connecctionString;
        }

        protected SqlConnection dbconnection()
        {
            return new SqlConnection(_connecctionString.ConnectionString);
        }



        public async Task<bool> DeleteExpense(int id)
        {
            var db = dbconnection();
            var sql = @"delete Expenses where Id= @id";

            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

        public async Task<IEnumerable<Expense>> GetAllExpenses()
        {
            var db = dbconnection();
            var sql = @"  select e.Id, e.Amount,e.CategoriesId,e.ExpenseType,e.TransactionDate, c.id,c.Name from Expenses e inner join Categories c on e.CategoriesId = c.id";
                var result = await db.QueryAsync<Expense, Category, Expense>(sql, (
                (expense, category) =>
                {
                    expense.Category = category;
                    return expense;
                }), new { }, splitOn: "id");
                
            return result;
        }


        public async Task<Expense> GetExpenseDetails(int id)
        {
            var db = dbconnection();
            var sql = "SELECT e.id,e.Amount,e.CategoriesId as categoryId,e.ExpenseType,e.TransactionDate from Expenses e where Id = @id";
            var pru = await db.QueryFirstOrDefaultAsync<Expense>(sql, new { Id = id });
            return pru;
        }
        public async Task<bool> InsertExpense(Expense expense)
        {
            int result1 = 0;
            var db = dbconnection();
            var sql = @"INSERT INTO Expenses(Amount,CategoriesId,ExpenseType,TransactionDate)VALUES(@Amount,@CategoryId,@ExpenseType,@TransactionDate)";
                var result = await db.ExecuteAsync(sql, new
                {
                    expense.Amount,
                    expense.CategoryId,
                    expense.ExpenseType,
                    expense.TransactionDate
                });
                return result > 0;       
        }

        public async Task<bool> UpdateExpense(Expense expense)
        {
            var db = dbconnection();
            var sql = @"update  Expenses set Amount= @Amount, CategoriesId =@CategoryId, ExpenseType = @ExpenseType ,TransactionDate = @TransactionDate  where Id= @Id ";
           
                var result = await db.ExecuteAsync(sql, new
                {
                    expense.Id,
                    expense.Amount,
                    expense.CategoryId,
                    expense.ExpenseType,
                    expense.TransactionDate
                });
 
            return result > 0 ;
        }

      
    }
}
