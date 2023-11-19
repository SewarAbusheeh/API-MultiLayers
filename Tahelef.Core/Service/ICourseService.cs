using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.Models;

namespace Tahelef.Core.Service
{
    public  interface ICourseService
    {
        List<Course> GetAllCourse();
        void CreateCourse(Course course);
        void DeleteCourse(int id);
         void UpdateCourse(Course course);
        Course GetByCourseId(int id);
    }
}
