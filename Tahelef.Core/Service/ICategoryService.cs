using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;

namespace Tahelef.Core.Service
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
