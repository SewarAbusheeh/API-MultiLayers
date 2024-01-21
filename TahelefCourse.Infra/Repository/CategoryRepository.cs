using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;
using Tahelef.Core.Repository;
using TahelefCourse.Core.Common;

namespace TahelefCourse.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext dBContext;
        public CategoryRepository(IDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void CreateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("p_categoryName", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
             dBContext.Connection.ExecuteAsync("Category_Package.CreateCategory", p, commandType: CommandType.StoredProcedure);
        }

        public void  DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_categoryId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
             dBContext.Connection.ExecuteAsync("Category_Package.DeleteCategory", p, commandType: CommandType.StoredProcedure);
        }

       
        public List<Category> GetAllCategory()
        {
            IEnumerable<Category> result = dBContext.Connection.Query<Category>("Category_Package.GetAllCategories", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Category GetByCategoryId(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_categoryId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.Query<Category>("Category_Package.GetCategoryById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

      
    
        public void UpdateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("p_categoryId", category.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_categoryName", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            dBContext.Connection.ExecuteAsync("Category_Package.UpdateCategory", p, commandType: CommandType.StoredProcedure);
        }

      
    }
}
