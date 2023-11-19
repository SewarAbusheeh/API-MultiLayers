using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;

namespace Tahelef.Core.Repository
{
    public interface  ICategoryRepository
    {
        List<Category> GetAllCategory();
        Category GetByCategoryId(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
