using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;
using Tahelef.Core.Repository;
using Tahelef.Core.Service;

namespace TahelefCourse.Infra.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        public CategoryService(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        public void CreateCategory(Category Category)
        {
            _CategoryRepository.CreateCategory(Category);
        }

        public void DeleteCategory(int id)
        {
            _CategoryRepository.DeleteCategory(id);
        }

        public List<Category> GetAllCategories()
        {
          return   _CategoryRepository.GetAllCategory();
        }

        public List<Category> GetAllCategory()
        {
            return _CategoryRepository.GetAllCategory();
        }

        public Category GetCategoryById(int id)
        {
            return _CategoryRepository.GetByCategoryId(id);
        }

        public void UpdateCategory(Category Category)
        {
            _CategoryRepository.UpdateCategory(Category);
        }

    }
}
