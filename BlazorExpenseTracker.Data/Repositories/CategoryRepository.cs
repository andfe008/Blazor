using BlazorExpenseTracker.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExpenseTracker.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private SqlConfiguration _connecctionString;

        public CategoryRepository(SqlConfiguration connecctionString)
        {
            _connecctionString = connecctionString;
        }

        protected SqlConnection dbconnection()
        {
            return new SqlConnection(_connecctionString.ConnectionString);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var db = dbconnection();
            var sql = @"delete Categories where Id= @id";

            var result = await db.ExecuteAsync(sql, new { Id= id });
            return result > 0;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var db = dbconnection();
            var sql = @"select  Id, Name From Categories";

            return  await db.QueryAsync<Category>(sql, new { });
            
        }
        public async Task<Category> GetCategoryDetails(int id)
        {
            var db = dbconnection();
            var sql = @"select  Id, Name From Categories where Id = @id ";

            return await db.QueryFirstOrDefaultAsync<Category>(sql, new { Id = id});

        }

        public async Task<bool> InsertCategory(Category category)
        {

            try
            {
                var db = dbconnection();
                var sql = @" insert into Categories values(@Name);";

                var result = await db.ExecuteAsync(sql, new { category.Name });
                return result > 0;
            }
            catch (Exception e)
            {
               return false;

            }
           
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            var db = dbconnection();
            var sql = @"update  Categories set Name = @Name where Id=@Id";

            var result = await db.ExecuteAsync(sql, new { category.Name, category.Id });
            return result > 0;
        }
    }
}
