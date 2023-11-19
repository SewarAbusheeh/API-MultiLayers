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
            p.Add("categoryName", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
             dBContext.Connection.ExecuteAsync("Category_Package.Create_Category", p, commandType: CommandType.StoredProcedure);
        }

        public void  DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("categoryID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
             dBContext.Connection.ExecuteAsync("Category_Package.Delete_Category", p, commandType: CommandType.StoredProcedure);
        }

        public  List<Category> GetAllCategories()
        {
            IEnumerable<Category> result =  dBContext.Connection.Query<Category>("Category_Package.Display_All_Categories", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Category> GetAllCategory()
        {
            throw new NotImplementedException();
        }

        public Category GetByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int id)
        {
            var p = new DynamicParameters();
            p.Add("categoryID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result =  dBContext.Connection.Query<Category>("Category_Package.Get_Category_By_ID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    
        public void UpdateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("categoryID", category.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("categoryName", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            dBContext.Connection.ExecuteAsync("Category_Package.Update_Category", p, commandType: CommandType.StoredProcedure);
        }

      
    }
}
