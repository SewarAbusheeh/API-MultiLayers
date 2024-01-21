using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Tahelef.Core.DTO;
using Tahelef.Core.Models;
using Tahelef.Core.Service;
using TahelefCourse.Core.Common;
using TahelefCourse.Infra.Service;

namespace TahelefCourse.APIp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StdCourseController : ControllerBase
    {
        private readonly IStudentCourseService StdCourseService;
        public StdCourseController(IStudentCourseService StdCourseService)
        {
            this.StdCourseService = StdCourseService;
        }
        [HttpGet]
        [Route("GetAllStdCourse")]
        public List<Stdcourse> GetAllStdCourse()
        {
            return StdCourseService.GetAllStudentCourse();
        }
        [HttpGet]
        [Route("GetByStdCourseId/{id}")]
        public Stdcourse GetByStdCourseId(int id)
        {
            return StdCourseService.GetStudentCourseById(id);
        }
        [HttpPost]
        [Route("CreateStdCourse")]
        public void CreateStdCourse(Stdcourse StdCourse)
        {
            StdCourseService.CreateStudentCourse(StdCourse);
        }
        [HttpPut]
        [Route("UpdateStdCourse")]
        public void UpdateStdCourse(Stdcourse StdCourse)
        {
            StdCourseService.UpdateStudentCourse(StdCourse);
        }
        [HttpPost]
        [Route("DeleteStdCourse")]
        public void DeleteStdCourse(int id)
        {
            StdCourseService.DeleteStudentCourse(id);
        }
        [HttpPost]
        [Route("SearchStudenCourse")]
        public List<Search> SearcheStudenCourse(Search search)
        {
            return StdCourseService.SearcheStudenCourse(search);
        }
        [HttpGet]
        [Route("TotalStudentInEachCourse")]
        public List<TotalStudents> TotalStudentInEachCourse()
        {
            return StdCourseService.TotalStudentInEachCourse();
        }
    }
}
