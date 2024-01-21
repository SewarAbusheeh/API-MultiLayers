using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahelef.Core.DTO;
using Tahelef.Core.Models;

namespace Tahelef.Core.Service
{
    public  interface IStudentCourseService
    {
        List<Stdcourse> GetAllStudentCourse();
        void CreateStudentCourse(Stdcourse studentCourse);
        void DeleteStudentCourse(int id);
        void UpdateStudentCourse(Stdcourse studentCourse);
        Stdcourse GetStudentCourseById(int id);
       
        List<Search> SearcheStudenCourse(Search search);
        public List<TotalStudents> TotalStudentInEachCourse();
    }
}
