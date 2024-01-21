using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tahelef.Core.Models;
using Tahelef.Core.Service;
using TahelefCourse.Infra.Repository;

namespace TahelefCourse.APIp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;
        public CourseController (ICourseService courseService)
        {
            this.courseService = courseService; 
        }
        [HttpGet]
        [Route("GetAllCourse")]
        public List<Course> GetAllCourse()
        {
            return courseService.GetAllCourse();
        }
        [HttpGet]
        [Route("GetByCourseId/{id}")]
        public Course GetByCourseId(int id)
        {
            return courseService.GetByCourseId(id);
        }
        [HttpPost]
        [Route("CreateCourse")]
        public void CreateCourse(Course course)
        {
            courseService.CreateCourse(course);
        }
        [HttpPut]
        [Route ("UpdateCourse")]
        public void UpdateCourse(Course course)
        {
            courseService.UpdateCourse(course);
        }
        [HttpPost]
        [Route("DeleteCourse")]
        public void DeleteCourse(int id)
        {
            courseService.DeleteCourse(id);
        }
        [HttpGet]
        [Route("GetAllCategoryCourse")]
        public Task<List<Category>> GetAllCategoryCourse()
        {
            return courseService.GetAllCategoryCourse();
        }
        [Route("uploadImage")]
        [HttpPost]
        public Course UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("F:\\Type Script Video\\TheLearningHub-FrontEnd\\src\\assets\\Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Course item = new Course();
            item.Imagename = fileName;
            return item;
        }
    }
}
