using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Tahelef.Core.Models;
using Tahelef.Core.Service;
using TahelefCourse.Core.Common;

namespace TahelefCourse.APIp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService CategoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            this.CategoryService = CategoryService;
        }
        [HttpGet]
        [Route("GetAllCategory")]
        public List<Category> GetAllCategory()
        {
            return CategoryService.GetAllCategories();
        }
        [HttpGet]
        [Route("GetByCategoryId/{id}")]
        public Category GetByCategoryId(int id)
        {
            return CategoryService.GetCategoryById(id);
        }
        [HttpPost]
        [Route("CreateCategory")]
        public void CreateCategory(Category Category)
        {
            CategoryService.CreateCategory(Category);
        }
        [HttpPut]
        [Route("UpdateCategory")]
        public void UpdateCategory(Category Category)
        {
            CategoryService.UpdateCategory(Category);
        }
        [HttpPost]
        [Route("DeleteCategory")]
        public void DeleteCategory(int id)
        {
            CategoryService.DeleteCategory(id);
        }
    }
}
