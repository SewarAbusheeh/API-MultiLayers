using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;

namespace Tahelef.Core.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAllCourses();
        Course GetByCourseId(int id);
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
        Task<List<Category>> GetAllCategoryCourse();
    }
}
