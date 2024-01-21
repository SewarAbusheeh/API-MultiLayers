using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;
using Tahelef.Core.Repository;
using Tahelef.Core.Service;
using TahelefCourse.Core.Common;

namespace TahelefCourse.Infra.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        public CourseService(ICourseRepository _courseRepository)
        {
            this.courseRepository = _courseRepository;
        }
        public List<Course> GetAllCourse()
        {
            return courseRepository.GetAllCourses();
        }
        public void CreateCourse(Course course)
        {
            courseRepository.CreateCourse(course);
        }
        public void UpdateCourse(Course course)
        {
            courseRepository.UpdateCourse(course);
        }
        public void DeleteCourse(int id)
        {
            courseRepository.DeleteCourse(id);
        }
        public Course GetByCourseId(int id)
        {
            return courseRepository.GetByCourseId(id);
        }
        public  Task<List<Category>> GetAllCategoryCourse()
        {
            return  courseRepository.GetAllCategoryCourse();
        }

    }
}
