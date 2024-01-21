using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tahelef.Core.Models;
using Tahelef.Core.Service;

namespace TahelefStudent.APIp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService StudentService;
        public StudentController(IStudentService StudentService)
        {
            this.StudentService = StudentService;
        }
        [HttpGet]
        [Route("GetAllStudent")]
        public List<Student> GetAllStudent()
        {
            return StudentService.GetAllStudent();
        }
        [HttpGet]
        [Route("GetByStudentId/{id}")]
        public Student GetByStudentId(int id)
        {
            return StudentService.GetStudentById(id);
        }
        [HttpPost]
        [Route("CreateStudent")]
        public void CreateStudent(Student Student)
        {
            StudentService.CreateStudent(Student);
        }
        [HttpPut]
        [Route("UpdateStudent")]
        public void UpdateStudent(Student Student)
        {
            StudentService.UpdateStudent(Student);
        }
        [HttpPost]
        [Route("DeleteStudent")]
        public void DeleteStudent(int id)
        {
            StudentService.DeleteStudent(id);
        }
    }
}
